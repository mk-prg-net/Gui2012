﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace mko.Log
{
    public class WinFormStatusStripLogHnd : ILogHnd
    {
        // Protokollierung von Meldungen in den Eventlogs des Systems

        public bool ShowMessage = false;
        public bool ShowStatus = false;

        StatusStrip _stp;
        ToolStripLabel statusText;

        public WinFormStatusStripLogHnd(System.Windows.Forms.StatusStrip statusStrip)
        {
            Debug.Assert(statusStrip != null, "Dem Konstruktor von mko.Log.WinFormStatusStripLogHnd muss eine StatusStrip- Referenz übergeben werden");

            _stp = statusStrip;
            statusText = (System.Windows.Forms.ToolStripLabel)_stp.Items.Find("StatusText", true)[0];
        }

        public WinFormStatusStripLogHnd(System.Windows.Forms.StatusStrip statusStrip, string NameStatusLabel)
        {
            Debug.Assert(statusStrip != null, "Dem Konstruktor von mko.Log.WinFormStatusStripLogHnd muss eine StatusText- Referenz übergeben werden");

            _stp = statusStrip;
            statusText = (System.Windows.Forms.ToolStripLabel)_stp.Items.Find(NameStatusLabel, true)[0];
        }

        #region ILogHnd Member

        DgDeregisterILogHnd dgDeregisterILogHnd = null;
        void ILogHnd.SetSelfDeregisterDelegate(DgDeregisterILogHnd dg)
        {
            if (dg != null)
                dgDeregisterILogHnd = dg;
        }

        void SelfDeregisterILogHnd()
        {
            if (dgDeregisterILogHnd != null)
                dgDeregisterILogHnd(this);
        }

        delegate void DGHnd(string userId, ILogInfo info);

        void ILogHnd.OnLog(string userId, ILogInfo info)
        {
            try
            {
                // Threadsicherer Aufruf der Listbox Add Methode
                if (_stp.InvokeRequired)
                {
                    ILogHnd logHnd = this;
                    DGHnd dg = new DGHnd(logHnd.OnLog);
                    _stp.BeginInvoke(dg, new object[] { userId, info });
                }
                else
                    switch (info.LogType)
                    {
                        case EnumLogType.Error:
                            {
                                string descr = string.Format("Err: user= {0:s}: {1} / {2}", info.LogDate, userId, info.Message);
                                Debug.Fail("WinFormStatusStripLogHnd: " + descr);
                                statusText.Text = "descr";
                            }
                            break;
                        case EnumLogType.Message:
                            if (ShowMessage)
                            {
                                string descr = string.Format("Msg: user= {0:s}: {1} / {2}", info.LogDate, userId, info.Message);
                                Debug.WriteLine("WinFormStatusStripLogHnd: " + descr);
                                statusText.Text = descr;
                            }
                            break;
                        case EnumLogType.Status:
                            if (ShowStatus)
                            {
                                string descr = string.Format("Sta: user= {0}: {1} / {2}", info.LogDate, userId, info.Message);
                                Debug.WriteLine("WinFormStatusStripLogHnd: " + descr);
                                statusText.Text = descr;
                            }
                            break;
                        default:
                            {
                                string descr = string.Format("Unbekannter Logtyp: user= {0:s}: {1} / {2}", info.LogDate, userId, info.Message);
                                statusText.Text = descr;
                                Debug.Fail("WinFormStatusStripLogHnd: " + descr);
                            }
                            break;
                    }
            }
            catch (Exception ex)
            {
                SelfDeregisterILogHnd();
            }
        }

        #endregion
    }
}
