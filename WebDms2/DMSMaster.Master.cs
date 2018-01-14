using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GBLWeb
{
    public partial class DMSMaster : System.Web.UI.MasterPage
    {
        public mkoIt.Asp.StatusLabel StatusLabel
        {
            get
            {
                return StatusLabelMaster;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (null != ContentPlaceHolder1.FindControl("hfBackgroundImage"))
            {
                var hfBackgroundImage = ContentPlaceHolder1.FindControl("hfBackgroundImage") as HiddenField;
                htmlBody.Style.Add(HtmlTextWriterStyle.BackgroundImage, mkoIt.Asp.AspWebSitePath.MapUrl(Page, "~/Bilder/" + hfBackgroundImage.Value));
                htmlBody.Style.Add("background-repeat", "repeat");
            }
        }
    }
}
