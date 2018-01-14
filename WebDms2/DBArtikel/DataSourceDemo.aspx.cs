using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebDms2.DBArtikel
{
    public partial class DataSourceDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        int selectedPnr = -1;

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            var grd = sender as GridView;

            // Bestimmen des ausgewählten Datensatzes
            selectedPnr = (int) grd.SelectedDataKey.Value;

            Debug.WriteLine("Bestimmen des Ausgewählten Datensatzes: pnr = " + selectedPnr);


            // Binden der GridView mit den Dataildaten erneut an die Datenquelle
            grdDetails.DataBind();

            DetailsView1.DataBind();
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.WhereParameters["pnr"] = selectedPnr;
        }

        protected void LinqDataSource2_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.WhereParameters["pnr"] = selectedPnr;
        } 

        protected void dpdProdukte_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dpd = sender as DropDownList;
            selectedPnr = int.Parse(dpd.SelectedValue);

            // Binden der GridView mit den Dataildaten erneut an die Datenquelle
            grdDetails.DataBind();
        }
    }
}