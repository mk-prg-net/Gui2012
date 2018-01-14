using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mko.Log
{
    public class RC : mko.Log.ILogInfo
    {
        string _msg;
        DateTime _date;
        mko.Log.EnumLogType _logType;

        private RC()
        {
            _date = DateTime.Now;
        }

        public static RC CreateError(string descr)
        {
            RC rc = new RC();
            rc._logType = mko.Log.EnumLogType.Error;
            rc._msg = descr;
            return rc;
        }

        static string ErrorDetail(Exception ex, int depht) {
            if (ex != null)
            {
                depht++;
                return "<E" + depht + ">" + ex.Message + ex.InnerException != null ? " " + ErrorDetail(ex.InnerException, depht) : "" + "</E" + depht + ">";
            }
            else
                return "";
        }

        public static RC CreateError(string descr, Exception ex)
        {
            RC rc = new RC();
            rc._logType = mko.Log.EnumLogType.Error;
            rc._msg = descr + ErrorDetail(ex, 0);

            return rc;
        }

        public static RC CreateStatusOk()
        {
            RC rc = new RC();
            rc._logType = mko.Log.EnumLogType.Status;
            rc._msg = "ok";
            return rc;
        }

        public static RC CreateStatus(string descr)
        {
            RC rc = new RC();
            rc._logType = mko.Log.EnumLogType.Status;
            rc._msg = descr;
            return rc;
        }

        public static RC CreateMsg(string descr)
        {
            RC rc = new RC();
            rc._logType = mko.Log.EnumLogType.Message;
            rc._msg = descr;
            return rc;
        }

        #region ILogInfo Member

        EnumLogType ILogInfo.LogType
        {
            get { return _logType; }
        }

        public DateTime LogDate
        {
            get { return _date; }
        }

        string ILogInfo.Message
        {
            get { return _msg; }
        }

        #endregion
    }
}

