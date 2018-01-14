using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using N = mko.Newton;
using NI = mko.Newton.UI;

namespace WebDms2.AspBasics
{
    public partial class Datenbindung : System.Web.UI.Page
    {
        public DateTime AktuelleUhrzeit
        {
            get
            {
                return DateTime.Now;
            }
        }

        public System.Drawing.Color BackgroundColor
        {
            get
            {
                string input = tbxColor.Text.Trim().ToLower();
                if (input == "green")
                    return System.Drawing.Color.Green;
                else if (input == "blue")
                    return System.Drawing.Color.Blue;
                else if (input == "red")
                    return System.Drawing.Color.Red;
                else
                    return System.Drawing.Color.Black;
            }
        }

        public System.Drawing.Color ForeColor
        {
            get
            {
                string input = tbxColor.Text.Trim().ToLower();
                if (input == "green")
                    return System.Drawing.Color.White;
                else if (input == "blue")
                    return System.Drawing.Color.Yellow;
                else if (input == "red")
                    return System.Drawing.Color.White;
                else
                    return System.Drawing.Color.White;
            }
        }

        public IEnumerable<KeyValuePair<string, int>> AlleVEinheiten
        {
            get
            {
                var pairs = new List<KeyValuePair<string, int>>();
                mko.algorithm.ForEachEnumMember<NI.Velocity.Unit>.execute((name, id) => pairs.Add(new KeyValuePair<string, int>(NormName(name), id)));                
                return pairs;
            }
        }

        string NormName(string enumName)
        {
            return enumName.Replace("_", "").Replace("per", "/");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            N.Init.Do();
            if(!IsPostBack)
                // Beim ersten Seitenabruf wird ein allgemeiner Datenabgleich für 
                // alle Bindungen durchgeführt. Die Einschränkung "erster Seitenabruf"
                // muss gemacht werden, da sonst bei allen folgenden Abrufen die 
                // geposteten Werte (z.B. selectedValues der DropDownListen) durch 
                // diesen algemeinen Datenabgleich wieder überschrieben werden
                DataBind();
        }

        protected void btnSetColor_Click(object sender, EventArgs e)
        {
            tbxColor.DataBind();
        }

        protected void btnUmrechnung_Click(object sender, EventArgs e)
        {
            // Messwertobjekt erzeugen und mit den Eingaben aus der WebForm initialisieren
            N.Velocity Vin;
            if (NI.Velocity.TryParse(tbxVin.Text, (NI.Velocity.Unit)int.Parse(dpdEinheitVin.SelectedValue), out Vin))
            {
                var EinheitVout = (NI.Velocity.Unit)int.Parse(dpdEinheitVout.SelectedValue);

                var Vout = NI.Velocity.Converter[EinheitVout](Vin);

                // Umrechnen in die Zieleinheit und Ausgeben der Werte
                lblVout.Text = Vout.ToString();
            }
            else
            {
                lblStatus.Text = "In Vin muss ein nummerischer Wert eingegeben werden";
            }
        }

        public IEnumerable<KeyValuePair<string, int>> AlleMasseEinheiten
        {
            get
            {
                var pairs = new List<KeyValuePair<string, int>>();
                mko.algorithm.ForEachEnumMember<NI.Mass.Unit>.execute((name, id) => pairs.Add(new KeyValuePair<string, int>(NormName(name), id)));
                return pairs;
            }
        }

        public IEnumerable<KeyValuePair<string, int>> AlleZeitEinheiten
        {
            get
            {
                var pairs = new List<KeyValuePair<string, int>>();
                mko.algorithm.ForEachEnumMember<NI.Time.Unit>.execute((name, id) => pairs.Add(new KeyValuePair<string, int>(NormName(name), id)));
                return pairs;

            }
        }


        public IEnumerable<N.Length> Flugbahn
        {
            get
            {               

                NI.Velocity.Unit vinUnit = (NI.Velocity.Unit)int.Parse(dpdBallistikEinheitV.SelectedValue);
                NI.Mass.Unit massUnit = (NI.Mass.Unit)int.Parse(dpdMasseEinheit.SelectedValue);
                NI.Time.Unit tFlugUnit = (NI.Time.Unit)int.Parse(dpdFlugzeitEinheit.SelectedValue);                

                // Einlesen der Parameter aus den Textboxen
                N.Velocity v0;
                N.Mass masse;
                N.Time flugzeit;
                if (NI.Velocity.TryParse(vinUnit, out v0, tbxV0x.Text, tbxV0y.Text) &&
                    NI.Mass.TryParse(tbxMasse.Text, massUnit, out masse) &&
                    NI.Time.TryParse(tbxFlugzeit.Text, tFlugUnit, out flugzeit))
                {
                    var fallbeschleunigung = N.Acceleration.MeterPerSec2(0.0, -9.81);

                    return N.Ballistik.Flugbahn2D(
                        v0, 
                        masse,
                        (v) => N.Force.N(v.Vector[1]*-0.01, v.Vector[0]*0.05),
                        (v) => N.Force.N(0.0, 0.0),
                        fallbeschleunigung,
                        N.Time.MilliSec(100.0),
                        flugzeit);
                }
                else
                    return null;
               
            }
        }

        public System.Drawing.PointF[] FlugbahnPoint
        {
            get
            {
                return Flugbahn.Select(p => new System.Drawing.PointF((float)p.Vector[0], (float)p.Vector[1])).ToArray();
            }
        }

        protected void btnNeuberechnen_Click(object sender, EventArgs e)
        {
            

            grdBallistik.DataSource = Flugbahn;
            Chart1.DataSource = FlugbahnPoint;
            grdBallistik.DataBind();
        }

    }
}