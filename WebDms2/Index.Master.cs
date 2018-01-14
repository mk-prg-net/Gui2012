using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GBLWeb
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != cphBody.FindControl("hfBackgroundImage"))
            {
                var hfBackgroundImage = cphBody.FindControl("hfBackgroundImage") as HiddenField;
                htmlBody.Style.Add(HtmlTextWriterStyle.BackgroundImage, mkoIt.Asp.AspWebSitePath.MapUrl(Page, "~/Bilder/" + hfBackgroundImage.Value));
                htmlBody.Style.Add("background-repeat", "repeat");
            }
        }
    }
}
