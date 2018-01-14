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

    public abstract class Binding<TWebCtrl, TFieldValue> : BindingBase
        where TWebCtrl : Control
    {
        TWebCtrl _webCtrl;
        
        /// <summary>
        /// Führt die Zuweisung eines Feldwertes aus einem Datensatz an die Eigenschaft eines Webcontrols durch.
        /// Dabei können Konvertierungen und Formatierungen stattfinden
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="value"></param>
        public delegate void WebCtrlPropertySetter(TWebCtrl ctrl, TFieldValue value);
        WebCtrlPropertySetter _webCtrlPropertySetter;

        /// <summary>
        /// Name des Datenfeldes im Datensatz, auf das zugegriffen wir
        /// </summary>
        string _fieldName { get; set; }


        public Binding(TWebCtrl webCtrl, string fieldName, WebCtrlPropertySetter webCtrlPoropertySetter)
        {
            _webCtrl = webCtrl;
            _webCtrlPropertySetter = webCtrlPoropertySetter;

            _fieldName = fieldName;           

            _webCtrl.DataBinding += new EventHandler(DataBindHandler);           
        }

        void  DataBindHandler(object sender, EventArgs e)
        {
            var ctrl = (TWebCtrl)sender;     
            _webCtrlPropertySetter(ctrl, (TFieldValue)DataBinder.Eval(GetDataItem(ctrl), _fieldName));
        }

        /// <summary>
        /// In Abgeleiteten Klassen wird hier der Zugriff zu dem
        /// mit dem Control assoziierten Datensatz beschrieben
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        protected abstract object GetDataItem(TWebCtrl ctrl);

    }
}
