using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2
{
    public partial class DemoMaster : System.Web.UI.MasterPage
    {
        public string Author
        {
            get
            {
                return metaAut.Content;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}