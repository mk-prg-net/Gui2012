using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace WinFormCtrlLibTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void zeitraumBox1_ChangedEvent(object sender, WinFormCtrlLib.ZeitraumBox.PropertyChangedEventArgs e)
        {
            WinFormCtrlLib.ZeitraumBox zbx = sender as WinFormCtrlLib.ZeitraumBox;
            Debug.Assert(zbx != null);

            lbxLogEvents.Items.Add(
                string.Format(
                    "{0:g} wurde {2} geändert in {1}", 
                    e.whatIsChanged, 
                    e.whatIsChanged == WinFormCtrlLib.ZeitraumBox.PropertyChangedEventArgs.Changed.vonChanged ? zbx.Von : zbx.Bis,
                    zbx.Valid ? "gültig" : "ungültig"));
        }
    }
}
