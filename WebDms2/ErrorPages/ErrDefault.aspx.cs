using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.ErrorPages
{
    public partial class ErrDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                tabCellErrCode.Text = ex.GetType().Name;
                tabCellErrCode.Text = mko.ExceptionHelper.FlattenExceptionMessages(ex);
            }
        }
    }
}