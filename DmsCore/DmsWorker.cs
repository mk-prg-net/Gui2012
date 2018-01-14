using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DMS.Core
{
    public class DmsWorker : IWorker
    {
        TraceSwitch ts = new TraceSwitch("DmsWorkerTraceSwitch", "Grad der Protokollierung einstellen");

        mko.Log.LogServer _log;

        public DmsWorker(mko.Log.LogServer log)
        {
            _log = log;            
            
            string msg = "Der DmsWorker wurde in AppDomain " + AppDomain.CurrentDomain.FriendlyName + " instanziiert";
            Trace.WriteLineIf(ts.TraceInfo, msg);
            log.Log(mko.Log.RC.CreateMsg(msg));
        }

        Job cjob;
        DMS.FC.FileClassificatorServer fcServ;

        #region IWorker Member

        public bool setup(Job currentJob)
        {
            // Typ des Jobs bestimmen
            
            return true;
        }

        public void doIt(Job currentJob)
        {
            throw new NotImplementedException();
        }

        public JobProgressInfo GetProgressInfo(Job job)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
