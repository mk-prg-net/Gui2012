using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TSave = System.Collections.Concurrent;

namespace PrimScanParallelWinFormApp
{
    public partial class Form1 : WinFormTemplates.WinFormTemplate1
    {
        public Form1()
        {
            InitializeComponent();
        }


        long Von { get; set; }

        private void tbxVon_Validating(object sender, CancelEventArgs e)
        {
            var tbx = sender as TextBox;
            long start = 0;
            if (GetStart(tbx, ref start))
                tbxBis.Text = (start + 100000).ToString();
        }

        private bool GetStart(TextBox tbx, ref long start)
        {

            if (long.TryParse(tbx.Text, out start))
            {

                return true;
            }
            else
            {
                log.Log(mko.Log.RC.CreateError("von ist keine Zahl"));
                return false;
            }
        }

        private bool GetEnde(TextBox tbx, ref long start)
        {

            if (long.TryParse(tbx.Text, out start))
            {

                return true;
            }
            else
            {
                log.Log(mko.Log.RC.CreateError("von ist keine Zahl"));
                return false;
            }
        }

        delegate TSave.ConcurrentBag<IEnumerable<long>> DGScan(long start, long ende, mko.Algo.NumberTheory.PrimeFactors.DGProgress progressCallback);
        DGScan dgScan;

        delegate void DGPrintResults(TSave.ConcurrentBag<IEnumerable<long>> results);
        IEnumerable<long>[] LastResult = null;

        void EndeCallback(IAsyncResult ares)
        {
            var results = dgScan.EndInvoke(ares);

            if (lbxResults.InvokeRequired)
            {
                lbxResults.Invoke(new DGPrintResults(res =>
                {
                    LastResult = res.ToArray();

                    cbxResultPart.Items.Clear();
                    for (int i = 0; i < res.Count; i++)
                        cbxResultPart.Items.Add(i);

                    log.Log(mko.Log.RC.CreateStatus("Scan beendet"));


                    
                }), new object[] { results });
            }
        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            lbxFertigePartitionen.Items.Clear();
            lbxResults.Items.Clear();

            dgScan = new DGScan(mko.Algo.NumberTheory.PrimeFactors.scanParallelWithTasks);

            var Progress = new mko.Algo.NumberTheory.PrimeFactors.DGProgress(PrimScanParallel_Progress);

            long start = 0, ende = 0;
            if(GetStart(tbxVon, ref start) && GetEnde(tbxBis, ref ende)) {
                IAsyncResult ares =  dgScan.BeginInvoke(start, ende, Progress, EndeCallback, null);
                log.Log(mko.Log.RC.CreateStatus("Scan (" + start + ", " + ende + ") gestartet"));
                //while (!ares.IsCompleted)
                //{

                //    Application.DoEvents();
                   
                //}
            }
        }

        // Achtung: der Eventhandler wird aus einer Task gestartet, die u.U. in einem
        // anderen Thread läuft-> WinForm Controls dürfen nur aus dem Hauptthread 
        // beeinflusst werden
        void PrimScanParallel_Progress(Tuple<long, long> partition)
        {
            // lbxFertigePartitionen.Items.Add("Part (" + p.Start + ", " + p.Ende + ") fertig");
            if (lbxFertigePartitionen.InvokeRequired)
            {
                // Wir befinden uns in einem Thrad <> Windows- Thread -> Arbeit an
                // Windows- Thread deligieren

                lbxFertigePartitionen.Invoke(
                    new mko.Algo.NumberTheory.PrimeFactors.DGProgress(p =>
                        {
                            lbxFertigePartitionen.Items.Add("Part (" + p.Item1 + ", " + p.Item2 + ") fertig");
                        }),
                        new object[] { partition });
            }
        }

        private void cbxResultPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LastResult != null)
            {
                var cbx = sender as ComboBox;
                int part = (int)cbx.SelectedIndex;

                lbxResults.Items.Clear();
                foreach (long p in LastResult[part])
                    lbxResults.Items.Add(p);
            }

        }
    }
}
