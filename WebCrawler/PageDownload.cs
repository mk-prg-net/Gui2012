using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WebCrawler
{
    class PageDownload : DMS.BatchProcessor<PageDownloadWorker>
    {
        public PageDownload(mko.Log.LogServer log, PageDownloadWorker worker)
            : base(log, worker)
        {
            Debug.Write("PageDownload - Instanz erfolgreich erzeugt");
        }
    }
}
