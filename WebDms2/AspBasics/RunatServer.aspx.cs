using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebDms2.AspBasics
{
    public partial class RunatServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSetImage_Click(object sender, EventArgs e)
        {            
            var img =  panHtmlContainer.FindControl("img1") as System.Web.UI.HtmlControls.HtmlImage;
            Debug.Assert(img != null);
            img1.Src = "~/Bilder/smiley-gross.png";

        }
    }
}