using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class WebFormMitMasterpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var master = Master as WebDms2.DemoMaster;
            var master = Master;
            lblAuthorMaster.Text = master.Author;
        }
    }
}