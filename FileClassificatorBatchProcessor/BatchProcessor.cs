using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FC.BP
{
    public class BatchProcessor : DMS.BatchProcessor<FCWorker>
    {
        public static mko.Log.LogServer logServer = new mko.Log.LogServer();
        public BatchProcessor() 
            : base(logServer, new FCWorker(logServer)) 
        { }
    }
}
