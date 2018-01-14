using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

//using Microsoft.SharePoint;
//using Microsoft.SharePoint.WebControls;
//using Microsoft.SharePoint.WebPartPages;

namespace WebPartLib
{
    [Guid("8be206b3-eb3a-41b1-893b-e9bc8dd78c00")]
    public class ParamWP1 : System.Web.UI.WebControls.WebParts.WebPart
    {
        public ParamWP1()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        string privAusgabeText = "Standardtext";
        bool privInTabelle = false;

        [WebBrowsable(true),
        Personalizable(PersonalizationScope.User),
        WebDescription("Dieser Text wird ausgegeben"),
        WebDisplayName("Ausgabetext")]
        public string ausgabeText
        {
            get { return privAusgabeText; }
            set { privAusgabeText = value; }
        }


        [WebBrowsable(true),
        Personalizable(PersonalizationScope.User),
        WebDescription("Ausgeben in Tabelle"),
        WebDisplayName("Tabellenausgabe")]
        public bool inTabelle
        {
            get { return privInTabelle; }
            set { privInTabelle = value; }
        }




        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (privInTabelle)
            {
                writer.Write("<table border=\"1\" width=\"100%\">");
                writer.Write("<tr><td>");
            }

            writer.Write(privAusgabeText);

            if (privInTabelle)
            {
                writer.Write("</td></tr>");
                writer.Write("</table>");
            }
        }
    }
}
