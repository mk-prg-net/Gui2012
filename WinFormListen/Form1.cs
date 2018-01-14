using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormListen
{
    public partial class Form1 : WinFormTemplates.WinFormTemplate1
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMultiColStart_Click(object sender, EventArgs e)
        {
            lbxMultiColPrimzahlen.Items.Clear();
            long begin, end;
            if (long.TryParse(tbxMultiColVon.Text, out begin) && long.TryParse(tbxMultiColBis.Text, out end))
            {

                lbxMultiColPrimzahlen.DataSource = new List<long>(mko.Algo.NumberTheory.PrimeFactors.scan(begin, end));
            }
        }
    }
}
