using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class LebenszyklusEvents : System.Web.UI.Page
    {

        ListItem meldungAusPreInit = null;

        void Page_PreInit(Object sender, EventArgs e)
        {
            meldungAusPreInit = new ListItem("PreInit: " + DateTime.Now.ToLongTimeString());
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            if (meldungAusPreInit != null) 
                lbxMeldungen.Items.Add(meldungAusPreInit);
            lbxMeldungen.Items.Add(new ListItem("Init: " + DateTime.Now.ToLongTimeString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lbxMeldungen.Items.Add(new ListItem("Load: " + DateTime.Now.ToLongTimeString()));
        }

        protected void btnMakeClickEvent_Click(object sender, EventArgs e)
        {
            lbxMeldungen.Items.Add(new ListItem("Click: " + DateTime.Now.ToLongTimeString()));
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            lbxMeldungen.Items.Add(new ListItem("PreRender: " + DateTime.Now.ToLongTimeString()));
        }
    }
}