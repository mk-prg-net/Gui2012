using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Core
{
    public class DmsBatchProcessor : DMS.BatchProcessor<DmsWorker>, IDisposable
    {
        static mko.Log.LogServer _log = new mko.Log.LogServer();
        List<mko.Log.ILogHnd> _allLogHandler = null;

        /// <summary>
        /// Vereinfachter Zugriff auf die BatchProcessing Schnittstelle
        /// </summary>
        public IBatchProcessing ControlPanel
        {
            get
            {
                return this;
            }
        }

        // Konstruktion
        public DmsBatchProcessor(List<mko.Log.ILogHnd> allLogHandler)
            : base(_log, new DmsWorker(_log))
        {
            _allLogHandler = allLogHandler;
            foreach (mko.Log.ILogHnd hnd in _allLogHandler)
            {
                _log.registerLogHnd(hnd);
            }
        }

        //--------------------------------------------------------------------------------
        // Dispose und Destruktion

        #region IDisposable Member

        void Cleanup()
        {
            foreach (mko.Log.ILogHnd hnd in _allLogHandler)
            {
                _log.deregisterLogHnd(hnd);
            }
        }

        public void Dispose()
        {
            Cleanup();
            GC.SuppressFinalize(this);
        }

        ~DmsBatchProcessor()
        {
            Cleanup();
        }

        #endregion
    }
}
