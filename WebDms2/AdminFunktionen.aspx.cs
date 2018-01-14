using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class AdminFunktionen : System.Web.UI.Page
    {
        string UserId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Zugriff auf den User
            UserId = User.Identity.Name;
        }

        protected void btnAdminsOnly_Click(object sender, EventArgs e)
        {
            if(System.Web.Security.Roles.IsUserInRole("Admins"))
                lblAusgabe.Text = UserId +": Alles ok";
            else
                lblAusgabe.Text = UserId + ": ist nicht ok";
        }

        protected void btnFrei_Click(object sender, EventArgs e)
        {
            lblAusgabe.Text = UserId + ": Alles ok";
        }
    }
}