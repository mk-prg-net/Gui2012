using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class ImageMap_Siegerehrung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool hatSplieablauf = false;
            foreach (string key in Session.Keys)
            {
                if (key == "Spielablauf")
                {
                    hatSplieablauf = true;
                    break;
                }
            }
            if (hatSplieablauf)
            {
                // Zugriff auf Spielablauf und Darstellung als Literalcontrol

                //var Spielablauf = Session["Spielablauf"] as List<ImageMapSpielzug>;

                // Mit strukturiertem Sitzungsobjekt arbeiten
                var sessObj = new mkoIt.Asp.SessionVar<WebDms2.AspBasics.ImageMapSessionDaten>(Session, "ImageMapDaten");
                string spieler = sessObj.Value.NameSpieler;
                var Spielablauf = sessObj.Value.Spielablauf;

                foreach (var zug in Spielablauf)
                {
                    PlaceHolderWegZumSieg.Controls.Add(new Label() { Text = zug.Treffer + ", ", ID = "lblRunde" + zug.Runde.ToString() });
                }
            }

        }
    }
}