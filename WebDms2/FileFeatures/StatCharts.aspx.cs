using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebDms2
{
    public partial class StatCharts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbxListFileClasses_DataBound(object sender, EventArgs e)
        {
            var cbxList = sender as CheckBoxList;
            Debug.Assert(cbxList != null);

            foreach (ListItem item in cbxList.Items)
            {
                item.Selected = true;
            }
        }

        protected void odsSizePerFileClass_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            var bo = e.ObjectInstance as DMS.FCollect.Db.BoSizePerFileClass;
            Debug.Assert(bo != null);

            foreach (ListItem item in cbxListFileClasses.Items)
            {
                // Ausschließen aller nicht berücksichtigter Klassen
                if(!item.Selected)
                    bo.AllFilter.Add(new DMS.FCollect.Db.BoSizePerFileClass.ExcludeFileClassFilter() { RValue = int.Parse(item.Value) });
            }
            
        }

        protected void btnSetChoice_Click(object sender, EventArgs e)
        {
            Chart1.DataBind();
            Chart2.DataBind();
            Chart3.DataBind();
        }       
        
    }
}