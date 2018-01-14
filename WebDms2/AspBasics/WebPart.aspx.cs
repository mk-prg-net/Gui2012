using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebDms2.AspBasics
{
    public partial class WebPart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dpdWebPartModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dpd = sender as DropDownList;
            switch (dpd.SelectedValue)
            {
                case "1":
                    WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode;
                    break;
                case "2":
                    WebPartManager1.DisplayMode = WebPartManager.DesignDisplayMode;
                    break;
                case "3":
                    WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode;
                    break;
                case "4":
                    WebPartManager1.DisplayMode = WebPartManager.CatalogDisplayMode;
                    break;
                default:;
                    break;
            }
        }

        /// <summary>
        /// Einfaches Steuerelement in einem Wrapper verpacken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddWebPart_Click(object sender, EventArgs e)
        {
            if (rbtGenWp.Checked)
            {
                var lbl = new TextBox() { ID = "lblDyn", Text = DateTime.Now.ToLongTimeString() };
                GenericWebPart wp = WebPartManager1.CreateWebPart(lbl);
                wp.Description = "Ein dyn. erzeugtes Webpart";
                wp.Title = "MyDynPart";
                WebPartManager1.AddWebPart(wp, WebPartZone1, 0);
            }
            else
            {
                var wp = new WebPartLib.ParamWP1();
                WebPartManager1.AddWebPart(wp, WebPartZone1, 0);
            }

        }
    }
}