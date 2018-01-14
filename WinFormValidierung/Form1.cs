using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace u3_Validating
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            opItemsBindingSource.DataSource = new OpItems[] {
                new OpItems() { Text= "+", Operation = Op.Add},
                new OpItems() { Text= "-", Operation = Op.Sub},
                new OpItems() { Text= "*", Operation = Op.Mul},
                new OpItems() { Text= "/", Operation = Op.Div},
            };
           
        }

        bool AValid, BValid;
        double A, B;

        private void tbxA_Validating(object sender, CancelEventArgs e)
        {
            var tbx = sender as TextBox;
            if (!double.TryParse(tbx.Text, out A))
            {
                e.Cancel = false;
                lblAValid.Text = "*";
                lblFehler.Text = "Bitte nur nummerische Werte eingeben !";
            }
            else
            {
                lblAValid.Text = lblFehler.Text = "";
            }
        }
       

        private void tbxB_Validating(object sender, CancelEventArgs e)
        {            
            var tbx = sender as TextBox;
            if (!double.TryParse(tbx.Text, out B))
            {                
                e.Cancel = true;
                lblBValid.Text = "*";
                lblFehler.Text = "Bitte nur nummerische Werte eingeben !";
            }
            else
            {
                lblBValid.Text = lblFehler.Text = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidateAndCalculate(Op.Add);
        }

        public enum Op { Add, Sub, Mul, Div }

        private void ValidateAndCalculate(Op op)
        {
            AValid = double.TryParse(tbxA.Text, out A);
            BValid = double.TryParse(tbxB.Text, out B);
            if (AValid && BValid)
            {

                switch (op)
                {
                    case Op.Add:
                        tbxRes.Text = (A + B).ToString();
                        break;
                    case Op.Sub:
                        tbxRes.Text = (A - B).ToString();
                        break;
                    case Op.Mul:
                        tbxRes.Text = (A * B).ToString();
                        break;
                    case Op.Div:
                        tbxRes.Text = (A / B).ToString();
                        break;
                    default: ;
                        break;
                }

                lblAValid.Text = lblBValid.Text = lblFehler.Text = "";
            }
            else
            {
                lblAValid.Text = AValid ? "" : "*";
                lblBValid.Text = BValid ? "" : "*";
                lblFehler.Text = "Bitte nur nummerische Werte eingeben !";
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {            
            Op SelectedValue = (Op)cbxOperatoren.SelectedValue;
            cbxOperatorenAnpassenAnManuelleEingabe(cbxOperatoren);
            ValidateAndCalculate((Op)cbxOperatoren.SelectedValue);
        }

        private void cbxOperatoren_Validating(object sender, CancelEventArgs e)
        {
            var cbx = sender as ComboBox;

            string[] ops = new string[]{"+", "-", "*", "/"};

            if (!ops.Any(op => op == cbx.Text))
            {
                e.Cancel = true;
                lblFehler.Text = "Der Operator ist ungültig";
            }
            //else
            //{
            //    //cbxOperatorenAnpassenAnManuelleEingabe(cbx);
            //    e.Cancel = false;
            //}
                
        }

        private void cbxOperatorenAnpassenAnManuelleEingabe(ComboBox cbx)
        {
            if (cbxTextUpdated)
            {
                cbxTextUpdated = false;

                var mapStringToOp = new Dictionary<string, Op>();
                mapStringToOp["+"] = Op.Add;
                mapStringToOp["-"] = Op.Sub;
                mapStringToOp["*"] = Op.Mul;
                mapStringToOp["/"] = Op.Div;

                cbx.SelectedValue = mapStringToOp[cbx.Text];
            }
        }

        bool cbxTextUpdated = false;
        private void cbxOperatoren_TextUpdate(object sender, EventArgs e)
        {
            Debug.WriteLine("Text updated");
            cbxTextUpdated = true;
        }

        private void btnOpUp_Click(object sender, EventArgs e)
        {
            opItemsBindingSource.MovePrevious();
        }

        private void btnOpDown_Click(object sender, EventArgs e)
        {
            opItemsBindingSource.MoveNext();
        }

      

        
    }
}