using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebDms2.AspBasics
{
    public partial class SummeAusZweiMitKassenrolle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbxKassenrolle.EnableViewState = cbxMitViewState.Checked;
        }

        protected void btnOp_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            Debug.Assert(btn.CommandName == "op", "SummeAusZwei.btnOp_Click: Der Button startet keine arithmetische Operation!");

            // Expliziter Aufruf aller Vlidatoren auf dem Server, um sicherzustellen, das auch bei abgeschaltetem JavaScript die 
            // Validierung noch funktioniert
            //Validate();
            //if (IsValid)
            {

                // Einlesen der Operanden
                double a = double.Parse(tbxA.Text);
                double b = double.Parse(tbxB.Text);

                double result = 0;
                string opSymbol = "";
                switch (btn.CommandArgument)
                {
                    case "add":
                        opSymbol = "+";
                        result = a + b;
                        break;
                    case "sub":
                        opSymbol = "-";
                        result = a - b;
                        break;
                    case "mul":
                        opSymbol = "*";
                        result = a * b;
                        break;
                    case "div":
                        opSymbol = "/";
                        result = a / b;
                        break;
                    default:
                        throw new Exception("unbekannte Operation");
                }

                var resultBackColor = result > 0 ? System.Drawing.Color.FromArgb(0x3399FF) : System.Drawing.Color.Firebrick;
                tabCellResult.BackColor = resultBackColor;
                tabCellResult.Text = string.Format("A {0} B = {1:N}", opSymbol, result.ToString());

                lbxKassenrolle.Items.Add(new ListItem(tabCellResult.Text, result.ToString()));
            }
        }

        protected void btnBonAbreissen_Click(object sender, EventArgs e)
        {
            lbxKassenrolle.Items.Clear();
        }

        protected void cbxMitViewState_CheckedChanged(object sender, EventArgs e)
        {           
            lbxKassenrolle.Items.Clear();
        }

        [Serializable]
        class myLi
        {
            public string key;
            public string val;
        }

        protected void btnSaveBon_Click(object sender, EventArgs e)
        {
            var alleItems = new List<myLi>();
            foreach (ListItem li in lbxKassenrolle.Items)
            {

                alleItems.Add(new myLi() {key= li.Text, val = li.Value});
            }

            ViewState["Kassenrolle"] = alleItems;
        }

        protected void btnRestoreBon_Click(object sender, EventArgs e)
        {
            if (ViewState["Kassenrolle"] != null)
            {
                var alleItems = (List<myLi>)ViewState["Kassenrolle"];
                lbxKassenrolle.Items.Clear();
                foreach (myLi li in alleItems)
                {
                    lbxKassenrolle.Items.Add(new ListItem() {Text= li.key, Value = li.val});
                }
            }

        }

    }
}