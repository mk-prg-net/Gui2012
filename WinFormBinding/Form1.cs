using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Für die Entwurfszeit enthielt die DataSouce einen Verweis auf den Datentyp der Elemente, die die Datenquelle
            // zu Laufzeit enthält.
            // Für die Laufzeit müssen nun die tatsächlichen Daten in der DataSource bereitgestellt werden
            greiferBindingSource.DataSource = Greifer.CreateList();

            greiferBaudratenBindingSource.Filter = "Baudrate = 9600";
            greiferBaudratenBindingSource.DataSource = GreiferBaudraten.CreateList();
            
        }

        private void greiferBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            greiferBaudratenBindingSource.DataSource = GreiferBaudraten.CreateList().Where(r => (r.ZulässigeGreifer & ((Greifer)greiferBindingSource.Current).ID) != 0).ToArray();

            //greiferBaudratenBindingSource.Filter = "Contains('" + ((Greifer)greiferBindingSource.Current).Name + "')";
            //greiferBaudratenBindingSource.Filter = "Baudrate == 9600";
            //greiferBaudratenBindingSource.Filter = "9600";
        }
    }
}
