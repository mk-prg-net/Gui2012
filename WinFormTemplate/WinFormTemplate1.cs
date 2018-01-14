using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormTemplates
{
    public partial class WinFormTemplate1 : Form
    {
        protected mko.Log.LogServer log = new mko.Log.LogServer();
        protected mko.Log.WinFormListBoxLogHnd lbxLogHnd;
        protected mko.Log.WinFormStatusStripLogHnd StatusStripLogHnd;
       

        public WinFormTemplate1()
        {
            InitializeComponent();

            lbxLogHnd = new mko.Log.WinFormListBoxLogHnd(lbxLog);
            log.registerLogHnd(lbxLogHnd);

            StatusStripLogHnd = new mko.Log.WinFormStatusStripLogHnd(statusStrip1, "toolStripStatusLabel1");
            log.registerLogHnd(StatusStripLogHnd);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}