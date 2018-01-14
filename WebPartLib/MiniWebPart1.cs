using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

//using Microsoft.SharePoint;
//using Microsoft.SharePoint.WebControls;
//using Microsoft.SharePoint.WebPartPages;
using System.Security;

[assembly: AllowPartiallyTrustedCallers]

namespace WebPartLib
{
    [Guid("2f1394fa-684a-470b-8428-f25127c6770a")]
    public class MiniWebPart1 : System.Web.UI.WebControls.WebParts.WebPart
    {
        public MiniWebPart1()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("Dies ist ein Minimalwebpart, das eine Textzeile ausgeben kann");
        }

    }
}