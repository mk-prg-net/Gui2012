using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileClassificatorClient
{
    public partial class FormClassificatorClient : mkoWinFormTemplate.Form1
    {
        DMS.FileClassificatorServer fcServer;
        DMS.StandardFileClassificator classificator = new DMS.StandardFileClassificator();
        ContentVectorDataTableWriter writer;

        public FormClassificatorClient()
        {
            InitializeComponent();
            writer = new ContentVectorDataTableWriter(MyDsFilesClassification.ContentVec);
            
            fcServer = new DMS.FileClassificatorServer(classificator, writer);

            fcServer.EventProgress += new DMS.DirTree.DGEventProgress(fcServer_EventProgress);
        }

        void fcServer_EventProgress(DMS.DirTree.DirTreeProgressInfo info)
        {
            if (info.FileCount % 50 == 0)
                Application.DoEvents();
        }

        private void btnClassifyNew_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Debug.WriteLine("Klassifizierung auf " + folderBrowserDialog1.SelectedPath + " beginnt");
                    fcServer.scanDir(folderBrowserDialog1.SelectedPath);
                    Debug.WriteLine("Klassifizierung erfolgreich");

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Err: Beim Klassifizieren von " + folderBrowserDialog1.SelectedPath + ": " + ex.Message);
                }
            }
        }
    }
}
