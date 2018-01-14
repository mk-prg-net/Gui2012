using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler
{
    public class Crawler
    {
        mko.Log.LogServer log = new mko.Log.LogServer();        
       
        public Crawler()
        {
            PickLinksWorker pickWorker = new PickLinksWorker();
            _pickLinks = new PickLinks(log, pickWorker);

            PageDownloadWorker pWorker = new PageDownloadWorker(_pickLinks);
            pWorker.EventEndOfCrawl +=new PageDownloadWorker.DGProgressInfo(pWorker_EventEndOfCrawl);

            _pageDownload = new PageDownload(log, pWorker);

            // Für die Rückkopplung benötigt PickLinks eine Referenz auf PageDownload
            pickWorker.pageDownloadQueue = _pageDownload;
        }

        public delegate void DgEventEndOfCrawl(long VisitedSitesCount);
        public event DgEventEndOfCrawl EndOfCrawl;

        void  pWorker_EventEndOfCrawl(PageDownloadJobProgressInfo pinfo)
        {
            
 	        if(EndOfCrawl != null)
                EndOfCrawl(pinfo.VisitedSitesCount);
        }

        PageDownload _pageDownload;
        PickLinks _pickLinks;


        // Starten eines WebScanns
        public void crawl(string StartUrl, int MaxDeept)
        {
            PageDownloadJob firstDownloadJob = new PageDownloadJob();

            DMS.IBatchProcessing pageDownloadBp = (DMS.IBatchProcessing)_pageDownload;

            // Job wird nach der Fertigstellung automatisch aus dem JobStorage im BatchProcessor entfernt
            firstDownloadJob.OneWay = true;
            firstDownloadJob.JobId = pageDownloadBp.NewJobId();
            firstDownloadJob.Url = StartUrl;
            firstDownloadJob.ActDeept = MaxDeept;

            pageDownloadBp.pushJob(firstDownloadJob);
        }      

    }
}
