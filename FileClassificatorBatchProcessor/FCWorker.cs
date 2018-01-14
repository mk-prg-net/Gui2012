using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;

namespace DMS.FC.BP
{
    public class FCWorker : DMS.IWorker
    {
        // Mit dem writer werden in den Jobs die ContentVecTabelle im results Feld beim Scannen aufgebaut
        DMS.FC.ContentVectorDataTableWriter writer = new DMS.FC.ContentVectorDataTableWriter();
        public FCWorker(mko.Log.LogServer log)
        {
            this.log = log;
            server = new DMS.FC.FileClassificatorServer(new DMS.FC.StandardFileClassificator(), writer);
            Debug.WriteLine("Der FCWorker wurde in AppDomain " + AppDomain.CurrentDomain.FriendlyName + " instanziiert");
            log.Log(mko.Log.RC.CreateMsg("Der FCWorker wurde in AppDomain " + AppDomain.CurrentDomain.FriendlyName + " instanziiert"));
        }

        mko.Log.LogServer log;
        DMS.FC.FileClassificatorServer server;
        Job cjob;

        #region IWorker Member

        bool DMS.IWorker.setup(DMS.Job currentJob)
        {
            try
            {
                // ContentVec- Tabelle dem writer bekanntmachen
                writer.SetContentVecTab(((Job)currentJob).results);
                server.reset();
                Debug.WriteLine("Job " + currentJob.JobId + " in AppDomain " + AppDomain.CurrentDomain.FriendlyName + " wird gestartet");
                log.Log(mko.Log.RC.CreateMsg("Job " + currentJob.JobId + " in AppDomain " + AppDomain.CurrentDomain.FriendlyName + " wird gestartet"));
                return true;
            }
            catch (InvalidCastException)
            {
                Trace.Fail("FCWorker/InvalidCastException");
                return false;
            }
            catch (Exception ex)
            {
                Trace.Fail(string.Format("FCWorker/setup/Exception: {0}", ex.Message));
                return false;
            }
        }

        void DMS.IWorker.doIt(DMS.Job currentJob)
        {
            try
            {

                cjob = (Job)currentJob;
                Debug.WriteLine("Job " + currentJob.JobId + " in AppDomain " + AppDomain.CurrentDomain.FriendlyName + " wird ausgeführt");

                if (server.scanDir(cjob.dir))
                {
                    cjob.CountDirs = server.DirCount;
                    cjob.CountFiles = server.FileCount;                    
                    return;
                }
                else
                {
                    Trace.WriteLine(string.Format("FCWorker/doIt/scanner.scanDir({0}): mit false geendet", cjob.dir));
                    return;
                }
            }
            catch (Exception ex)
            {
                Trace.Fail(string.Format("FCWorker/doIt/Exception: {0}", ex.Message));
                return;
            }
        }

        DMS.JobProgressInfo DMS.IWorker.GetProgressInfo(DMS.Job job)
        {
            try
            {
                FileClassificatorProgressInfo pinfo = null;
                if (job.JobId == cjob.JobId)
                {
                    pinfo = new FileClassificatorProgressInfo(job.JobId, job.JobState, server.DirCount, server.FileCount, cjob.results.Rows.Count);
                }
                else
                {
                    Job tjob = (Job)job;
                    pinfo = new FileClassificatorProgressInfo(tjob.JobId, tjob.JobState, tjob.CountDirs, tjob.CountFiles, tjob.results.Rows.Count);
                }

                return pinfo;
            }
            catch (InvalidCastException)
            {
                Trace.Fail("FCWorker/GetProgressInfo/InvalidCastException");
                return null;
            }
            catch (Exception ex)
            {
                Trace.Fail(string.Format("FCWorker/GetProgressInfo/Exception: {0}", ex.Message));
                return null;
            }
        }

        #endregion
    }
}
