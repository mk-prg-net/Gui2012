using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class AufEinerMasterseiteAufbauend : System.Web.UI.Page
    {
        mko.Log.LogServer log;

        protected void Page_Load(object sender, EventArgs e)
        {
            log = new mko.Log.LogServer();

            var refMaster = (GBLWeb.DMSMaster)Master;
            refMaster.StatusLabel.Text = "HAllo, es ist " + DateTime.Now.ToLongTimeString() + " Uhr";


            log.registerLogHnd(refMaster.StatusLabel);
        }

        protected void btnMakeErr_Click(object sender, EventArgs e)
        {
            log.Log(mko.Log.RC.CreateError("Eine Fehlermeldung"));
        }
    }
}