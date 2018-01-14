using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Diagnostics;

namespace WebDms2.DBArtikel
{
    public partial class Lieferanten : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBArtikelDbLayer.BoLieferant.ConnectionString =  WebDms2.Properties.Settings.Default.DBArtikelConnectionString;

            // !! Fehler: Durch das generelle Databind werden vor der aktualisierung
            // alle Benutzereingaben durch die alten Werte überschrieben !!
            // Alle Datenbindungen über Datensteuerelemente werden ausgeführt
            //DataBind();
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            // Nachdem ein neuer Datensatz mittels der Details- View eingefügt wurde
            // ist ein DataBind- Aufruf sinvoll. Dadurch werden alle Steuerelemente
            // auf der Webseite erneut an die Daten gebunden, wodurch der neue 
            // Datensatz in den Tabellen erst auftaucht.
            DataBind();
        }

        protected void btnNeu_Click(object sender, EventArgs e)
        {
            DBArtikelDbLayer.Dtx.Lieferanten lf = new DBArtikelDbLayer.Dtx.Lieferanten();
            lf.lfnr = int.Parse(tbxLfNr.Text);
            lf.name = tbxName.Text;
            lf.email = tbxEmail.Text;
            lf.plz = tbxPlz.Text;

            DBArtikelDbLayer.BoLieferant bo = new DBArtikelDbLayer.BoLieferant();
            bo.insert(lf);
            Debug.WriteLine("Neuer Lieferantendatensatz erfolgreich angelegt");
            DataBind();
        }
    }
}
