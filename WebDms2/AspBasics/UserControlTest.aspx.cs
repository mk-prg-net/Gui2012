using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class UserControlTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uiDbIntervallMinMax1_Changed(object sender, EventArgs e)
        {
            var uiIntervall = sender as GBLWeb.UIDblIntervall;            
            lblIntervall.Text = "[" + uiIntervall.Intervall.Begin.ToString() + ", " + uiIntervall.Intervall.End.ToString() + "]";
        }

        protected void zeitraum_Changed(object sender, EventArgs e)
        {
            var zeitraumCtrl = sender as GBLWeb.VonBisZeitintervall;

            lblZeitraum.Text = zeitraumCtrl.VonBis.Begin.ToShortDateString() + " - " + zeitraumCtrl.VonBis.End.ToShortDateString();
        }
    }
}