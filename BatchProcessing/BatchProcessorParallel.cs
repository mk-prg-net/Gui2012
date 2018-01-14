//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 29.11.2011
//
//  Projekt.......: Stapelverarbeitung
//  Name..........: BatchProcessorParallel
//  Aufgabe/Fkt...: Generischer Stapelverarbeitungsprozess, der einen parallele Verarbeitung der 
//                  Jobs erlaubt.
//                  Zu verarbeitende Jobs müssen von der Klasse DMS.Job abgeleitet sein.
//                  Das den Job ausführende Objekt muß die Klasse DMS.IWorker implementieren.
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: Server 2008
//  Betriebssystem: Windows 7 mit .NET 4.0
//  Werkzeuge.....: Visual Studio 2010
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;

using TPL = System.Threading.Tasks;

using mko.Log;

namespace DMS
{
    [Serializable]
    public class BatchProcessorParallel<TWorker> : MarshalByRefObject, IBatchProcessing
        where TWorker : DMS.IWorker
    {
        // Protokollierung 
        [NonSerialized]
        protected mko.Log.LogServer log;

        [NonSerialized]
        TraceSwitch ts;


        [NonSerialized]
        Queue<TWorker> workerIdle;

        [NonSerialized]
        TWorker oneWorker;

        // Referenz auf in Bearbeitung befindlichen Jobs. Jeder Job ist unter der  
        // Id der Task hinterlegt, die ihn bearbeitet
        [NonSerialized]
        Dictionary<int, Tuple<DMS.Job, TWorker>> ActiveWorker;

        // Zuletzt vergebene JobId
        static int lastJobId = 0;

        // Wenn alle Worker belegt sind, dann wird busy auf true gesetzt,
        // sonst ist busy false
        bool busy
        {
            get
            {
                lock (workerIdle)
                {
                    return workerIdle.Count == 0;
                }
            }
        }

        // Wenn true, dann wird die Jobverarbeitung angehalten
        bool _pause = false;

        // Konstruktoren
        public BatchProcessorParallel(mko.Log.LogServer log, TWorker[] worker)
        {
            this.log = log;
            Debug.Assert(worker.Length > 0);
            oneWorker = worker[0];

            foreach (var w in worker)
            {
                workerIdle.Enqueue(w);
            }

            JobFertigEvent = new System.Threading.AutoResetEvent(false);

            ts = new TraceSwitch("TraceBatchProcessor", "Diagnoseprotokolle des Batchprocessors");
        }

        // Implementierung des Stapleverarbeitungsprozesses
        #region IBatchProcessing Member

        Queue<Job> JobQueue = new Queue<Job>();
        Dictionary<int, Job> JobStorage = new Dictionary<int, Job>();

        // Semaphore zum signalisieren, das ein Job fertiggestellt wurde
        [NonSerialized]
        System.Threading.AutoResetEvent JobFertigEvent;

        object lastJobIdlock = null;
        int IBatchProcessing.NewJobId()
        {
            lock (lastJobIdlock)
            {
                lastJobId += 1;
                return lastJobId;
            }
        }

        void IBatchProcessing.pushJob(Job job)
        {
            try
            {
                lock (JobQueue)
                {
                    lock (JobStorage)
                    {
                        JobStorage.Add(job.JobId, job);
                        JobQueue.Enqueue(job);
                        job.SetWaiting();
                        Trace.WriteLineIf(ts.TraceInfo, string.Format("Job id= {0:D} in Warteschlange gestellt", job.JobId));
                    }
                    // Wenn der Server ohne Arbeite ist, wird sofort die Bearbeitung eines neuen 
                    // Jobs gestartet
                    if (!busy)
                    {
                        ProcessNextJob();
                    }
                }
            }
            catch (Exception ex)
            {

                log.Log(RC.CreateError("PushJob: " + ex.Message));
                Trace.Fail("PushJob: " + ex.Message);
            }
        }


        /// <summary>
        /// 2011.05.09, mko
        /// In vorausgegangenen Versionen wurde der Fall nicht berücksichtigt, das ein auf die
        /// Verarbeitung wartender Job bereits abgebrochen werden kann. Durch eine Schleife,
        /// die alle bereits abgebrochenen Jobs überspringt, wurde dies jetzt korrigiert
        /// </summary>
        private void ProcessNextJob()
        {
            lock (JobStorage)
            {
                // Sind weitere Jobs in der Job-Queue, dann wird die Arbeit mit dem nächsten Job
                // aus der Queue unmittelbar fortgesetzt. Vorausgesetzt, es gibt noch freie Worker
                while (!busy && JobQueue.Count > 0 && !_pause)
                {
                    // Alle abgebrochenen Jobs überspringen
                    Job nextJob = null;

                    do
                    {
                        nextJob = JobQueue.Dequeue();
                        if (nextJob.JobState == Job.JobStates.aborted)
                        {
                            if (nextJob.OneWay)
                            {
                                JobStorage.Remove(nextJob.JobId);
                            }
                            nextJob = null;
                        }
                    } while (JobQueue.Count > 0 && nextJob == null);

                    if (nextJob != null)
                    {
                        nextJob.SetProcessing();

                        // nächsten freien Worker holen
                        var worker = workerIdle.Dequeue();

                        // Worker initialisieren und laufen lassen
                        if (worker.setup(nextJob))
                        {

                            // Task zur Ausführung des Workers erzeugen
                            var t = new TPL.Task(() => worker.doIt(nextJob));

                            Action<TPL.Task> tSuccess = new Action<TPL.Task>(
                                (task) =>
                                {
                                    JobFinished(task.Id);
                                }
                            );
                            t.ContinueWith(tSuccess, TPL.TaskContinuationOptions.OnlyOnRanToCompletion);

                            Action<TPL.Task> tFail = new Action<TPL.Task>(
                                (task) =>
                                {
                                    JobFinished(task.Id);
                                }
                            );
                            t.ContinueWith(tFail, TPL.TaskContinuationOptions.OnlyOnFaulted);


                            // neuen, in Bearbeitung befindlichen Job verzeichnen
                            ActiveWorker.Add(t.Id, new Tuple<Job, TWorker>(nextJob, worker));

                            // Ausführung des Jobs starten
                            t.Start();
                        }
                        else
                        {
                            // Job abbrechen 
                            nextJob.SetAborted();

                            // worker wieder in Warteschlange der freien worker zurückstellen
                            workerIdle.Enqueue(worker);

                        }
                    }
                }
            }

        }

        // 2011.05.09, mko : Parameterlose Version, um nach einem Abort eines Jobs zu reagieren
        void JobFinished(int taskId)
        {
            try
            {
                lock (JobStorage)
                {
                    // Worker zur Wiederverwendung freigeben
                    workerIdle.Enqueue(ActiveWorker[taskId].Item2);

                    // 2011.05.09, mko: Abgebrochene Jobs werden hier nicht mehr gelöscht !
                    var finishedJob = ActiveWorker[taskId].Item1;
                    if (finishedJob.JobState != Job.JobStates.aborted)
                    {
                        finishedJob.SetFinished();
                        Trace.WriteLineIf(ts.TraceInfo, string.Format("Job id= {0:N0} fertiggestellt", finishedJob.JobId));
                    }

                    // OneWay Jobs automatisch löschen. Nicht OneWay Jobs verbleiben
                    // bis zur Auslieferung im JobStorage
                    // 2011.05.09, mko: Unabhängig vom Zustand werden (z.B. Finished od. aborted)
                    // werden One- Way Jobs gelöscht (vorher nur Finished Jobs. Aborted wurden immer 
                    // gelöscht)
                    if (finishedJob.OneWay)
                    {
                        JobStorage.Remove(finishedJob.JobId);
                    }

                    // Verzeichnis der aktuelle bearbeiteten Jobs bereinigen
                    ActiveWorker.Remove(taskId);

                    // Signalisieren an WaitUntilJobFinished, das ein Job fertiggestellt wurde
                    JobFertigEvent.Set();

                } // End Lock

                lock (JobQueue)
                {
                    // Nächste arbeitsbereite Jobs zur Ausführung bringen
                    ProcessNextJob();
                }

            }
            catch (Exception ex)
            {
                log.Log(RC.CreateError("BatchProcessing.JobFinished: " + ex.Message));
                Trace.Fail("BatchProcessing.JobFinished: " + ex.Message);
            }
        }


        JobProgressInfo IBatchProcessing.GetProgressInfo(int JobId)
        {
            lock (JobStorage)
            {
                if (JobStorage.ContainsKey(JobId))
                {
                    Job aJob = JobStorage[JobId];

                    JobProgressInfo pinfo = oneWorker.GetProgressInfo(aJob);
                    return pinfo;

                }
            }
            return null;
        }

        bool IBatchProcessing.WaitUntilJobFinished(int jobId, int timeout)
        {
            bool contain = false;
            try
            {
                System.Threading.Monitor.Enter(JobStorage);

                contain = JobStorage.ContainsKey(jobId);
                if (contain)
                {
                    Job ajob = null;
                    ajob = JobStorage[jobId];

                    if (ajob.JobState == Job.JobStates.finished)
                        return true;
                    else
                    {

                        int i = timeout;
                        while (i > 0 || timeout == -1)
                        {

                            // Warten, bis der nächste Job beendet wurde, und nachschauen, ob 
                            // dies unser Job war
                            System.Threading.Monitor.Exit(JobStorage);
                            JobFertigEvent.WaitOne(100, false);
                            System.Threading.Monitor.Enter(JobStorage);

                            if (ajob.JobState == Job.JobStates.finished)
                                return true;

                            i -= 100;
                        } //End While

                    }// End If
                } // End If
            }
            finally
            {
                System.Threading.Monitor.Exit(JobStorage);
            }

            return false;
        }

        bool IBatchProcessing.DeliverFinishedJob(int JobId, out Job job)
        {
            lock (JobStorage)
            {

                if (JobStorage.ContainsKey(JobId))
                {
                    if (JobStorage[JobId].JobState == Job.JobStates.finished)
                    {
                        job = JobStorage[JobId];
                        JobStorage.Remove(JobId);
                        return true;
                    }
                }
            }

            // Undefinierten Job ausgeben
            job = new DMS.Job(-1);
            Trace.WriteLineIf(ts.TraceWarning, string.Format("BatchProcessor.DeliverFinishedJob: Zur JobId {0:D} existiert kein Job", JobId));
            return false;
        }

        bool IBatchProcessing.RemoveFinishedOrAbortedJob(int JobId)
        {
            lock (JobStorage)
            {
                if (JobStorage.ContainsKey(JobId))
                {
                    var job = JobStorage[JobId];
                    if (job.JobState == Job.JobStates.finished || job.JobState == Job.JobStates.aborted)
                    {
                        // Befindet sich der Job noch in der Warteaschlange, dann wird er zum Löschen 
                        // markiert. Sonst wird der Job sofort gelöscht
                        lock (JobQueue)
                        {
                            if (job.JobState == Job.JobStates.aborted && JobQueue.Contains(job))
                                job.OneWay = true;
                            else
                                JobStorage.Remove(JobId);
                            return true;
                        }
                    }
                    return false;
                }
                else
                    return false;
            }
        }

        bool IBatchProcessing.Abort(int JobId)
        {
            lock (JobStorage)
            {
                if (JobStorage.ContainsKey(JobId))
                {
                    // Falls der Job in Bearbeitung ist, dann wird die Bearbeitung gestoppt
                    if (JobStorage[JobId].JobState != Job.JobStates.finished)
                    {
                        JobStorage[JobId].SetAborted();
                        return true;
                    }
                    else
                    {
                        // Job wird gelöscht                        
                        JobStorage.Remove(JobId);
                    }
                }
            } //End SyncLock
            Trace.WriteLineIf(ts.TraceWarning, string.Format("BatchProcessor.Abort: Die Bearbeitung des Jobs {0:D} konnte nicht abgebrochen werden", JobId));
            return false;
        }

        bool IBatchProcessing.Pause()
        {
            _pause = true;
            return true;
        }

        bool IBatchProcessing.Resume()
        {
            try
            {
                lock (JobQueue)
                {
                    _pause = false;
                    // Sind weitere Jobs in der Job-Queue, dann wird die Arbeit mit dem nächsten Job
                    // aus der Queue unmittelbar fortgesetzt
                    ProcessNextJob();

                } // End Lock
                return true;
            }

            catch (Exception ex)
            {
                log.Log(RC.CreateError("BatchProcessing.JobFinished: " + ex.Message));
                Trace.Fail("BatchProcessing.JobFinished: " + ex.Message);
                return false;
            }
        }

        bool IBatchProcessing.Idle()
        {
            lock (JobQueue)
            {
                if (JobQueue.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        int[] IBatchProcessing.AllJobs()
        {
            lock (JobStorage)
            {
                if (JobStorage.Count > 0)
                {
                    int[] JobIDs = new int[JobStorage.Count];

                    int i = 0;
                    foreach (int JobId in JobStorage.Keys)
                    {
                        JobIDs[i] = JobId;
                        i++;
                    }
                    return JobIDs;
                }
                else return null;
            }
        }

        #endregion

        // Initialisierungen nach dem Deserialisierungsprozess
        [OnDeserialized]
        void InitAutomatic(StreamingContext ctx)
        {
            // Wiederherstellen des Delegaten für den Workerprozess
            ts = new TraceSwitch("TraceBatchProcessor", "Diagnoseprotokolle des Batchprocessors");

            JobFertigEvent = new System.Threading.AutoResetEvent(false);
        }

        public void InitAfterDeserialization(mko.Log.LogServer log, TWorker[] worker)
        {
            // Verweisen auf die Objekte aus dem Kontext
            this.log = log;
            Debug.Assert(worker.Length > 0);
            oneWorker = worker[0];

            foreach (var w in worker)
            {
                workerIdle.Enqueue(w);
            }
                  
        }

    }
}
