using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WebCrawler
{
    class PickLinks : DMS.BatchProcessor<PickLinksWorker>
    {
        public PickLinks(mko.Log.LogServer log, PickLinksWorker worker) : base(log, worker) {
            Debug.WriteLine("PickLinks erfolgreich instanziiert");
        }
    }
}
