using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Diagnostics;

namespace WebCrawler
{
    class PageDownloadWorker : DMS.IWorker
    {
        PickLinks _pickLinks;
        DMS.IBatchProcessing pickLinksBp;

        // Liste aller besuchter Links
        public List<string> Visited = new List<string>();

        // Signalisiert die Fertigstellung
        public delegate void DGProgressInfo(PageDownloadJobProgressInfo pinfo);
        public event DGProgressInfo EventEndOfCrawl;

        public PageDownloadWorker(PickLinks pickLinks)
        {
            this._pickLinks = pickLinks;
            this.pickLinksBp = (DMS.IBatchProcessing)_pickLinks;
        }

        #region IWorker Member

        public bool setup(DMS.Job currentJob)
        {
            return true;
        }

        public void doIt(DMS.Job currentJob)
        {
            // Downcast der Job- Referenz in eine Referenz vom Typ PageDownloadJob
            PageDownloadJob downloadJob = currentJob as PageDownloadJob;
            Debug.Assert(downloadJob != null);
            Debug.WriteLine("PD: Deept= " + downloadJob.ActDeept + " JobId= " + downloadJob.JobId + " Url=" + downloadJob.Url);

            try
            {
                // Prüfen, ob die max. Tiefe beim crawlen erreicht wurde
                if (downloadJob.ActDeept <= 0)
                {
                    if (EventEndOfCrawl != null)
                    {
                        lock (Visited)
                        {
                            EventEndOfCrawl(
                                new PageDownloadJobProgressInfo(
                                    downloadJob.Url,
                                    Visited.Count,
                                    downloadJob.JobId,
                                    downloadJob.JobState));
                        }
                    }
                    return;
                }

                // Prüfen, ob Seite bereits besucht wurde
                if (Visited.Any(r => r == downloadJob.Url))
                    return;

                // Seite herunterladen
                System.Net.WebRequest request = null;
                System.Net.WebResponse response = null;

                System.Net.NetworkCredential cred = new NetworkCredential(
                    //System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                    "Administrator",
                    "schulung");

                //System.Net.WebProxy myProxy = new System.Net.WebProxy("http://10.7.252.34:80", true);
                //myProxy.Credentials = cred;


                request = System.Net.WebRequest.Create(downloadJob.Url);
                //request.Proxy = myProxy;
                response = request.GetResponse();

                // Seite als besucht verzeichnen
                Visited.Add(downloadJob.Url);

                // Inhalt der Seite auslesen

                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                string HtmlText = reader.ReadToEnd();

                // Neuen PickLinJob in die Queue von PickLinks stellen
                PickLinksJob pickJob = new PickLinksJob();

                // Job wird nach der Fertigstellung automatisch entfernt 
                pickJob.OneWay = true;
                pickJob.JobId = pickLinksBp.NewJobId();
                pickJob.HtmlText = HtmlText;
                pickJob.ActDeept = downloadJob.ActDeept;

                pickLinksBp.pushJob(pickJob);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler beim Herunterladen: " + ex.Message);
            }
            finally
            {
                downloadJob.SetFinished();
            }
        }

        public DMS.JobProgressInfo GetProgressInfo(DMS.Job job)
        {
            // Downcast der Job- Referenz in eine Referenz vom Typ PageDownloadJob
            PageDownloadJob downloadJob = job as PageDownloadJob;
            Debug.Assert(downloadJob != null);
            lock (Visited)
            {
                PageDownloadJobProgressInfo pinfo = new PageDownloadJobProgressInfo(
                                        downloadJob.Url,
                                        Visited.Count,
                                        downloadJob.JobId,
                                        downloadJob.JobState);
                return pinfo;
            }            
        }

        #endregion
    }
}
