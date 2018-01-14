using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2
{
    public partial class Leuchttisch : System.Web.UI.Page
    {
        int ImageCountPerLine = 0;
        int LineCount = 0;

        public string SetSeparator()
        {
            string sep = "";

            if (ImageCountPerLine++ >= 5)
            {
                sep = "<br/><br/>";
                ImageCountPerLine = 0;
                LineCount++;
            }
            else
                sep = "&nbsp;";

            //Response.Write(br);
            return sep;

        }

        public string ImageFrameStyle()
        {
            return string.Format("border-style: outset; border-width: 3pt; width: 110px; left: {0:D}px; top:{1:D}px; position: absolute;", ImageCountPerLine * 140 + 30, LineCount * 200 + 150);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}