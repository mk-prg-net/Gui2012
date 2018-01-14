using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.ErrorPages
{
    public partial class ErrPageNotFound1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUrlPage.Text = Request.Url.ToString();

        }
    }
}