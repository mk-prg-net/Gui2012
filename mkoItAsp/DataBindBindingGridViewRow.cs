using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Diagnostics;

namespace mkoIt.Asp.DataBind
{
    public class BindingGridViewRow<TWebCtrl, TFieldValue> : Binding<TWebCtrl, TFieldValue>
        where TWebCtrl : Control
    {
        public BindingGridViewRow(TWebCtrl webCtrl, string fieldName, WebCtrlPropertySetter webCtrlPoropertySetter)
            : base(webCtrl, fieldName, webCtrlPoropertySetter)
        { }

        protected override object GetDataItem(TWebCtrl ctrl)
        {
            GridViewRow row = (GridViewRow)ctrl.NamingContainer;
            return row.DataItem;
        }
    }
}
