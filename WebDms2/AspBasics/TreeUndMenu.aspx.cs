using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebDms2.AspBasics
{
    public partial class TreeUndMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
        {
            var tv = sender as TreeView;
            lblSelectedNode.Text=tv.SelectedNode.Text;

#if(DEBUG)
            var item = tv.SelectedNode.DataItem;
            Debug.WriteLine(item.GetType().Name);
#endif
        }
    }
}