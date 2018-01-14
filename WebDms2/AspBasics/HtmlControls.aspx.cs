using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace WebDms2.AspBasics
{
    public partial class HtmlControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                // Alle Steuerelemente Serverseitig mittels 
                // Validierungselementen prüfen
                this.Validate();

                if (!this.IsValid)
                {
                    TD10.InnerHtml = "Eingaben sind ungültig ";
                }



                // Html- Steuerelemente können in der klassischen 
                // Form ausgewertet werden

                string wert = Request.Form["tbxHtm"];

                string wert2 = tbxHtm.Value;

                TD1.InnerText = "<b>" + wert2 + "</b>";

                // Checkboxen


                string auswahlZusatz = "";
                if (checkHtmMilch.Checked)
                {
                    auswahlZusatz = "Milch";
                }

                if (checkHtmZucker.Checked)
                {
                    // auswahlZusatz = (auswahlZusatz.Length == 0) ? "" :  auswahlZusatz + " ";
                    if (auswahlZusatz.Length != 0)
                        auswahlZusatz += " ";

                    auswahlZusatz += "Zucker";
                }

                TD4.InnerHtml = "<B>" + auswahlZusatz + "<b>";

                // Listboxen

                string lbxAuswertung = "";
                lbxAuswertung = "<ul>";

                if (lbxHtmDatenbank.SelectedIndex != -1)
                {
                    lbxAuswertung += "<li><b>Text:</b>" + lbxHtmDatenbank.Items[lbxHtmDatenbank.SelectedIndex].Text + "</li>";
                    lbxAuswertung += "<li><b>Value:</b>" + lbxHtmDatenbank.Items[lbxHtmDatenbank.SelectedIndex].Value + "</li>";
                    lbxAuswertung += "<li><b>Sel:</b>" + lbxHtmDatenbank.Items[lbxHtmDatenbank.SelectedIndex].Selected.ToString() + "</li>";
                }
                else
                    lbxAuswertung += "";

                lbxAuswertung += "</ul>";
                TD6.InnerHtml = lbxAuswertung;

                HtmlGenericControl li = new HtmlGenericControl("li");
                li.InnerText = "Hallo";

                lstDatenSimpelLbx.Controls.Add(li);

                // Abscannen aller Einträge einer einfachen ListBox

                ListItem litem; // Da hier keine neue INstanz vom Typ ListItem
                // erzeugt wird, kann litem wie ein Pointer in C
                // benutzt werden

                for (int i = 0; i < lbxHtmDatenbank.Items.Count; i++)
                {
                    litem = lbxHtmDatenbank.Items[i];

                    HtmlGenericControl lii = new HtmlGenericControl("li");
                    lii.InnerHtml = "<b>Text:</b>" + litem.Text + "<b>Value:</b>" + litem.Value + "<b>Sel:</b>" + litem.Selected.ToString();

                    lstDatenSimpelLbx.Controls.Add(lii);
                }

                // Auswerten eine Multilistbox

                foreach (ListItem litem2 in mlbxHtmDatenbank.Items)
                {
                    // Alle Einträge von Items werden besucht. Im schleifenrumpf ist jeder
                    // Besuchte Eintrag über litem2 verfügbar

                    HtmlGenericControl lii = new HtmlGenericControl("li");
                    lii.InnerHtml = "<b>Text:</b>" + litem2.Text + "<b>Value:</b>" + litem2.Value + "<b>Sel:</b>" + litem2.Selected.ToString();

                    lstDatenMultiLbx.Controls.Add(lii);
                }
            }
        }
    }
}