using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using N = mko.Newton;
using NI = mko.Newton.UI;
using B = mko.Ballistik;

namespace WebDms2.Physik
{
    public partial class Ballistik : System.Web.UI.Page
    {
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

                double fAuftrieb = double.Parse(tbxAuftrieb.Text);
                double fLuftwiderstand = double.Parse(tbxLuftwiderstand.Text);

                // Einlesen der Parameter aus den Textboxen
                N.Velocity v0;
                N.Mass masse;
                N.Time flugzeit;
                if (NI.Velocity.TryParse(vinUnit, out v0, tbxV0x.Text, tbxV0y.Text) &&
                    NI.Mass.TryParse(tbxMasse.Text, massUnit, out masse) &&
                    NI.Time.TryParse(tbxFlugzeit.Text, tFlugUnit, out flugzeit))
                {
                    var fallbeschleunigung = N.Acceleration.MeterPerSec2(0.0, -9.81);

                    return B.Flugbahn.berechne2D(
                        v0,
                        masse,
                        (v) => B.Auftrieb.Linear(v, fAuftrieb),
                        (v) => B.Widerstand.Luft(v, fLuftwiderstand),
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

        protected void Page_Load(object sender, EventArgs e)
        {
            N.Init.Do();
            if (!IsPostBack)
            {
                // Beim ersten Seitenabruf wird ein allgemeiner Datenabgleich für 
                // alle Bindungen durchgeführt. Die Einschränkung "erster Seitenabruf"
                // muss gemacht werden, da sonst bei allen folgenden Abrufen die 
                // geposteten Werte (z.B. selectedValues der DropDownListen) durch 
                // diesen algemeinen Datenabgleich wieder überschrieben werden
                DataBind();

                dpdBallistikEinheitV.SelectedIndex = (int)NI.Velocity.Unit.km_per_s;
                dpdFlugzeitEinheit.SelectedIndex = (int)NI.Time.Unit.s;
                dpdMasseEinheit.SelectedIndex = (int)NI.Mass.Unit.kg;

                grdBallistik.DataSource = Flugbahn;
                Chart1.DataSource = FlugbahnPoint;
                grdBallistik.DataBind();

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