using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.Text.RegularExpressions;

namespace WebCrawler
{
    class PickLinksWorker : DMS.IWorker
    {
        // Referenz auf die PageDownloadQueue
        public DMS.IBatchProcessing pageDownloadQueue { get; set; }
        
        #region IWorker Member

        public bool setup(DMS.Job currentJob)
        {
            return true;
        }

        //const string HRefRegEx = "href\\s*=\\s*[\"]??(http:\\/\\/).+[\"]??";
        const string HRefRegEx = "href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))";

        public void doIt(DMS.Job currentJob)
        {


#if(DEBUG)
            Debug.Assert(System.Text.RegularExpressions.Regex.IsMatch("href   =\"http://www.mkoit.de\"", HRefRegEx));
            Debug.Assert(System.Text.RegularExpressions.Regex.IsMatch("href = http://www.mkoit.de", HRefRegEx));
            Debug.Assert(System.Text.RegularExpressions.Regex.IsMatch("href=http://www.mkoit.de", HRefRegEx));

            Debug.Assert(System.Text.RegularExpressions.Regex.IsMatch("href=\"http://www.mkoit.de\"", HRefRegEx));

            //Debug.Assert(!System.Text.RegularExpressions.Regex.IsMatch("href=\"https:/www.mkoit.de\"", HRefRegEx));
#endif


            // Downcast in PickLinksJob
            PickLinksJob pJob = currentJob as PickLinksJob;
            Debug.Assert(pJob != null);

            int NewDeept = pJob.ActDeept - 1;            

            // Alle Urls aus dem HTML- Text extrahieren
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(
                HRefRegEx,
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            MatchCollection mc = regEx.Matches(pJob.HtmlText);
            Debug.WriteLine("PC: Deept= " + pJob.ActDeept + " JobId= " + pJob.JobId + " #Urls = " + mc.Count);

            // Iteration durch alle Treffer des regulären Ausdrucks
            foreach (System.Text.RegularExpressions.Match match in mc)
            {
                // Für jede Url einen neuen PageDownload Job erzeugen
                Debug.Assert(pageDownloadQueue != null);

                string Url;
                if (GetInternetLink(match.Captures[0].Value, out Url))
                {
                    PageDownloadJob downloadJob = new PageDownloadJob();

                    // Job wird nach der Fertigstellung automatisch entfernt 
                    downloadJob.OneWay = true;
                    downloadJob.JobId = pageDownloadQueue.NewJobId();
                    downloadJob.Url = Url;

                    downloadJob.ActDeept = NewDeept;

                    // Rückkopplung: Herunterladen der Seite, auf die der Link aus der aktuellen verweist
                    pageDownloadQueue.pushJob(downloadJob);
                }
            }

            pJob.SetFinished();

        }

        bool GetInternetLink(string href, out string url)
        {
            url = "";
            try
            {
                int start = href.IndexOf("http://");
                if (start >= 0)
                {
                    url = href.Substring(start);
                    if (url.EndsWith("\""))
                        url = url.Substring(0, url.Length - 1);                    
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public DMS.JobProgressInfo GetProgressInfo(DMS.Job job)
        {
            // Downcast der Job- Referenz in eine Referenz vom Typ PageDownloadJob
            PickLinksJob pJob = job as PickLinksJob;
            Debug.Assert(pJob != null);

            DMS.JobProgressInfo pinfo = new DMS.JobProgressInfo(pJob.JobId, pJob.JobState);
            return pinfo;
        }

        #endregion
    }
}
