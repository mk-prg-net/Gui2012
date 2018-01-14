using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class ImageMap : System.Web.UI.Page
    {
        Dictionary<string, int> alleTreffer = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.ForeColor = System.Drawing.Color.Yellow;
            hlSiegerehrung.Visible = false;

            if (!IsPostBack)
            {
                alleTreffer = new Dictionary<string, int>();
                ViewState["treffer"] = alleTreffer;
            }
            else
            {
                alleTreffer = ViewState["treffer"] as Dictionary<string, int>;
            }

        }
        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {
            Label1.Text = e.PostBackValue;
            if(!alleTreffer.ContainsKey(e.PostBackValue))
                alleTreffer.Add(e.PostBackValue, alleTreffer.Count + 1);
            if (alleTreffer.Count >= 6)
            {
                Label1.Text += " Gewonnen !!!!!!";
                Label1.ForeColor = System.Drawing.Color.Red;

                // Sichern des Spielablaufes im Sitzungszustand
                Session["Spielablauf"] = alleTreffer.OrderBy(r => r.Value).Select(r => new ImageMapSpielzug{ Runde = r.Value, Treffer = r.Key }).ToList();

                // Mit strukturiertem Sitzungsobjekt arbeiten
                var sessObj = new mkoIt.Asp.SessionVar<WebDms2.AspBasics.ImageMapSessionDaten>(Session, "ImageMapDaten");
                sessObj.Value.NameSpieler = "Hans";
                sessObj.Value.Spielablauf = alleTreffer.OrderBy(r => r.Value).Select(r => new ImageMapSpielzug { Runde = r.Value, Treffer = r.Key }).ToList();


                hlSiegerehrung.Visible = true;
                Response.Redirect("~/AspBasics/ImageMap-Siegerehrung.aspx");

                alleTreffer.Clear();
            }
        }

    }
}