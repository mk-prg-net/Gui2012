using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class MultiView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MuliView1.SetActiveView(View1);
        }
        protected void btnShowView1_Click(object sender, EventArgs e)
        {
            MuliView1.SetActiveView(View1);            
        }
        protected void btnShowView2_Click(object sender, EventArgs e)
        {
            MuliView1.SetActiveView(View2);
        }
    }
}