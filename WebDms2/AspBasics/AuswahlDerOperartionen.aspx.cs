using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class AuswahlDerOperartionen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panA.Visible = panB.Visible = false;
        }

        protected void dpdAuswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lbx = sender as ListBox;
            int val = int.Parse(lbx.SelectedValue);


            panA.Visible = val == 1;
            panB.Visible = !panA.Visible;
        }
    }
}