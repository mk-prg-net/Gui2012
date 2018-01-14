using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Security.Permissions;
using System.Xml;
using System.Diagnostics;

namespace FileClassificatorClient
{
    public partial class Form1 :  WinFormTemplates.WinFormTemplate1
    {
        // Zentrales System zur Behandlung von Fehler- und Statusmeldungen
        mko.Log.WinFormStatusStripLogHnd hndStatusStripLog;

        // FindFile- Prozessor
        DMS.FC.BP.BatchProcessor FCBatchProzessor;
        DMS.IBatchProcessing ibp;
        //FCWorker _Worker;


        // Liste aller vom Client erstellter Jobs
        Dictionary<int, DMS.FC.BP.Job> allFinishedJobs = new Dictionary<int, DMS.FC.BP.Job>();


        public Form1()
        {
            InitializeComponent();

            Text = "[" + System.Net.Dns.GetHostName() + "]  "
                    + this.Text
                    + " ver "
                    + this.GetType().Assembly.GetName().Version.Major.ToString()
                    + "."   
                    + this.GetType().Assembly.GetName().Version.Minor.ToString()
                    + "."   
                    + this.GetType().Assembly.GetName().Version.Build.ToString();

            hndStatusStripLog = new mko.Log.WinFormStatusStripLogHnd(this.statusStrip1, "toolStripStatusLabel1");
            log.registerLogHnd(hndStatusStripLog);

            // Stapelverarbeitung für Dateiscanns anlegen
            //_Worker = new FCWorker(log);
            DMS.FC.BP.BatchProcessor.logServer = log;
            FCBatchProzessor = new DMS.FC.BP.BatchProcessor();
            ibp = (DMS.IBatchProcessing)FCBatchProzessor;

            log.Log(mko.Log.RC.CreateMsg(string.Format("erfolgreich gestartet um {0:s}", DateTime.Now)));

        }

        private void btnNewJobPush_Click(object sender, EventArgs e)
        {
            try
            {
                // Neuen Job definieren 
                DMS.FC.BP.Job job = new DMS.FC.BP.Job();

                job.JobId = ibp.NewJobId();
                job.dir = tbxNewJobDir.Text;

                //if(tbxNewJobFileType.Text != ".*")
                //    job.filter.FileType = tbxNewJobFileType.Text;
                //if(tbxNewJobRegEx.Text != ".*")
                //    job.filter.regExPath = tbxNewJobRegEx.Text;
                //job.filter.SizeMin = Convert.ToInt64(tbxNewJobMinSize.Text);
                //job.filter.SizeMax = Convert.ToInt64(tbxNewJobMaxSize.Text);

                // Job an Stapelverarbeitung übergeben
                ibp.pushJob(job);

                timerUpdateActiveJobsView.Enabled = true;

                log.Log(mko.Log.RC.CreateMsg("Neuen Job in die Verarbeitungsqueue gestellt"));
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError(string.Format("Beim Erzeugen eines neuen Jobs: {0}", ex.Message)));
            }
        }

        private void timerUpdateActiveJobsView_Tick(object sender, EventArgs e)
        {
            try
            {
                dsFilesClassification.ActiveJobs.Rows.Clear();
                int[] allJobIds = ibp.AllJobs();
                if (allJobIds != null)
                {
                    foreach (int jobId in allJobIds)
                    {
                        DMS.FC.BP.FileClassificatorProgressInfo pInfo = (DMS.FC.BP.FileClassificatorProgressInfo)ibp.GetProgressInfo(jobId);

                        DMS.FC.DsFilesClassification.ActiveJobsRow row = dsFilesClassification.ActiveJobs.NewActiveJobsRow();
                        row.DateTimeNow = pInfo.timestamp;
                        row.JobId = pInfo.JobId;
                        TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - pInfo.timestamp.Ticks);
                        row.JobProccessingElapsedTime = ts.TotalSeconds;
                        row.JobState = pInfo.JobState.ToString();
                        row.CountDirs = pInfo.CountDirs;
                        row.CountFiles = pInfo.CountFiles;
                        row.CountResults = pInfo.CountResults;

                        dsFilesClassification.ActiveJobs.Rows.Add(row);

                    }
                }
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError(string.Format("Beim aktualisieren der Liste der aktiven Jobs: {0}", ex.Message)));
            }

        }

        private void btnNewJobResetValues_Click(object sender, EventArgs e)
        {
            tbxNewJobRegEx.Text = ".*";
            tbxNewJobMinSize.Text = "0";
            tbxNewJobMaxSize.Text = long.MaxValue.ToString();
            tbxNewJobFileType.Text = ".*";
            tbxNewJobDir.Text = Properties.Settings.Default.DefaultFindFileDir;
        }

        private void btnActiveJobsStartStopAutoUpdate_Click(object sender, EventArgs e)
        {
            if (timerUpdateActiveJobsView.Enabled)
            {
                timerUpdateActiveJobsView.Stop();
                btnActiveJobsStartStopAutoUpdate.Text = "automat. Aktualisierung starten";
                btnActiveJobsStartStopAutoUpdate.BackColor = System.Drawing.Color.LimeGreen;
                btnActiveJobKillJob.Enabled = true;
            }
            else
            {
                timerUpdateActiveJobsView.Start();
                btnActiveJobsStartStopAutoUpdate.Text = "automat. Aktualisierung stoppen";
                btnActiveJobsStartStopAutoUpdate.BackColor = System.Drawing.Color.Red;
                btnActiveJobKillJob.Enabled = false;
            }

        }

        private void btnActiveJobKillJob_Click(object sender, EventArgs e)
        {
            int ixRow = bindingSourceAllActiveJobs.Position;
            if (ixRow >= 0)
            {
                DMS.FC.DsFilesClassification.ActiveJobsRow row = (DMS.FC.DsFilesClassification.ActiveJobsRow)dsFilesClassification.ActiveJobs.Rows[ixRow];
                int JobId = row.JobId;
                ibp.Abort(JobId);

                btnActiveJobsStartStopAutoUpdate_Click(null, null);
            }
        }

        private void btnResultsRequery_Click(object sender, EventArgs e)
        {
            try
            {
                // Liste aller fertiggestellter Jobs auf dem Client mit den 
                // mit den frisch fertiggestellten Jobs auf dem Server aktualisieren
                try
                {
                    foreach (int jobId in ibp.AllJobs())
                    {
                        DMS.FC.BP.FileClassificatorProgressInfo pInfo = (DMS.FC.BP.FileClassificatorProgressInfo)ibp.GetProgressInfo(jobId);

                        if (pInfo.JobState == DMS.Job.JobStates.finished)
                        {
                            DMS.Job job;
                            ibp.DeliverFinishedJob(jobId, out job);

                            allFinishedJobs.Add(jobId, (DMS.FC.BP.Job)job);
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Log(mko.Log.RC.CreateError("Beim Abrufen der Liste aller Fertiggestellter Jobs: " + ex.Message));
                }

                // Ausgabe der Fertiggestellten Jobs in der Listbox
                lbxResultsJobs.Items.Clear();
                                
                foreach (int jobId in allFinishedJobs.Keys)
                {

                    lbxResultsJobs.Items.Add(jobId);
                }

                log.Log(mko.Log.RC.CreateMsg("Fertiggestellte Jobs abgefragt"));
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError(string.Format("Beim Abfragen der fertiggestellten Jobs: {0}", ex.Message)));
            }
        }

        private void lbxResultsJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ausgabe der Ergebnisse des ausgewählten Jobs als Tabelle
            if (lbxResultsJobs.SelectedItem != null)
            {
                int ix = Convert.ToInt32(lbxResultsJobs.SelectedItem);

                dsFilesClassification.ContentVec.Rows.Clear();

                foreach (DMS.FC.DsFilesClassification.ContentVecRow res in allFinishedJobs[ix].results.Rows)
                {
                    DMS.FC.DsFilesClassification.ContentVecRow row = dsFilesClassification.ContentVec.NewContentVecRow();
                    row.depth = res.depth;
                    row.path = res.path;
                    row.ArchiveBitSetCount = res.ArchiveBitSetCount;
                    row.SumArchiveBitFileSize = res.SumArchiveBitFileSize;
                    row.FileCount = res.FileCount;
                    row.SumFilesSize = res.SumFilesSize;
                    row.FotosCount = res.FotosCount;
                    row.SumFotosSize = res.SumFotosSize;
                    row.OfficeCount = res.OfficeCount;
                    row.SumOfficeFilesSize = res.SumOfficeFilesSize;
                    row.OtherCount = res.OtherCount;
                    row.SumOtherFilesSize = res.SumOtherFilesSize;
                    row.SourceCodeCount = res.SourceCodeCount;
                    row.SumSourceCodeFilesSize = res.SumSourceCodeFilesSize;
                    row.VideosCount = res.VideosCount;
                    row.SumVideosFilesSize = res.SumVideosFilesSize;
                    row.WebCount = res.WebCount;
                    row.SumWebFilesSize = res.SumWebFilesSize;

                    dsFilesClassification.ContentVec.Rows.Add(row);
                }
            }
        }

        private void btnResultsDelete_Click(object sender, EventArgs e)
        {
            if (lbxResultsJobs.SelectedItem != null)
            {
                int ix = Convert.ToInt32(lbxResultsJobs.SelectedItem);
                lbxResultsJobs.Items.Remove(ix);
                dsFilesClassification.ContentVec.Rows.Clear();
                allFinishedJobs.Remove(ix);
                log.Log(mko.Log.RC.CreateMsg(string.Format("Ergebnisse von Job {0:D} gelöscht", ix)));
            }

        }

        [FileDialogPermission(SecurityAction.Demand)]
        private void btnSaveAllFinishedJobs_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgSaveFinishedJobs.ShowDialog(this) == DialogResult.OK)
                {
                    // Die vom User selektierte Datei wird mit den gewährten IO- Permissions 
                    // geöffnet
                    System.IO.Stream stream = dlgSaveFinishedJobs.OpenFile();

                    // XmlWriter konfigurieren für Ausgaben ohne xml- Deklaration
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.OmitXmlDeclaration = false;
                    settings.Indent = true;
                    settings.Encoding = System.Text.Encoding.Unicode;
                    settings.ConformanceLevel = ConformanceLevel.Document;
                    
                    XmlWriter _XmlWriter = XmlWriter.Create(stream, settings);

                    int jobId = (int)lbxResultsJobs.SelectedItem;
                    
                    // Demo der XmlSerialisierung
                    DMS.FC.BP.Job job = allFinishedJobs[jobId];
                    XmlSerializer xser = new XmlSerializer(typeof(DMS.FC.BP.Job));
                    xser.Serialize(_XmlWriter, job);

                    log.Log(mko.Log.RC.CreateMsg(string.Format("Der Job mit der id {0:D} wurde in {1} gesichert", jobId, dlgSaveFinishedJobs.FileName)));
                    
                }
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError(string.Format("Beim Sichern aller abgeschlossener Jobs: {0}", ex.Message)));
            }
        }

        // Ein serialisierten Job von der Platte laden

        // Recht auf Dateiöffnen- Dialog ausführen wird benötigt
        [FileDialogPermission(SecurityAction.PermitOnly, Open=true)]
        [UIPermission(SecurityAction.PermitOnly, Unrestricted=true)]
        // Recht auf Ausführen, und Ausführung von Serialisierungsformattern wird benötigt        
        [SecurityPermission(SecurityAction.PermitOnly, Execution = true, SerializationFormatter = true)]
        private void btnLoadFinishedJobs_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgOpenFinishedJobs.ShowDialog(this) == DialogResult.OK)
                {
                    // Die vom User selektierte Datei wird mit den gewährten IO- Permissions 
                    // geöffnet
                    System.IO.Stream stream = dlgOpenFinishedJobs.OpenFile();

                    XmlSerializer xser = new XmlSerializer(typeof(DMS.FC.BP.Job));

                    DMS.FC.BP.Job job = (DMS.FC.BP.Job)xser.Deserialize(stream);
                    Debug.Assert(job != null);
                    if (allFinishedJobs.ContainsKey(job.JobId))
                        log.Log(mko.Log.RC.CreateMsg(string.Format("Achtung: der Job mit der Id {0:D} ist bereits vorhanden. Das Laden des Jobs aus einer XML- Datei wurde abgebrochen", job.JobId)));
                    else
                    {
                        allFinishedJobs.Add(job.JobId, job);
                        //log.Log(mko.Log.RC.CreateMsg(string.Format("Der Job mit der Id {0:D} wurde aus der Datei {1} wiederhergestellt", job.JobId, dlgOpenFinishedJobs.FileName)));
                    }
                                        
                }
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError(string.Format("Beim Sichern aller abgeschlossener Jobs: {0}", ex.Message)));
            }

        }

        private void btnRemotingLoadConfig_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;

            System.Runtime.Remoting.RemotingConfiguration.Configure("FileClassificatorClient.exe.config", false);
            
            log.Log(mko.Log.RC.CreateMsg("Remotingconfiguration aus App.config geladen"));
            //FindFileBatchProzessor = new BatchProcessor();
            FCBatchProzessor = (DMS.FC.BP.BatchProcessor)System.Runtime.Remoting.RemotingServices.Connect(typeof(DMS.FC.BP.BatchProcessor), @"tcp://127.0.0.1:5555/FileClassificatorBP");
            ibp = FCBatchProzessor;

        }

        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxNewJobDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void rbtResultsFilterYes_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbt = (RadioButton)sender;
            cbxResulltsFilterOps.Enabled = rbt.Checked;
            cbxResultsFilterColName.Enabled = rbt.Checked;
            tbxResultsFilter.Enabled = rbt.Checked;
            btnResultsFilterSet.Enabled = rbt.Checked;
        }

        private void btnResultsFilterSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtResultsFilterYes.Checked && 
                    !string.IsNullOrEmpty(tbxResultsFilter.Text) && 
                    !string.IsNullOrEmpty(cbxResulltsFilterOps.Text) && 
                    !string.IsNullOrEmpty(cbxResultsFilterColName.Text))
                    bindingSourceJobResults.Filter = cbxResultsFilterColName.Text + " " + cbxResulltsFilterOps.Text + " " + tbxResultsFilter.Text;
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError("Beim setzten des Filter für die Ergebniskreuztabelle: " + ex.Message));
            }
        }

        private void rbtResultsFilterNo_CheckedChanged(object sender, EventArgs e)
        {
            bindingSourceJobResults.Filter = "";
        }
    }
}

