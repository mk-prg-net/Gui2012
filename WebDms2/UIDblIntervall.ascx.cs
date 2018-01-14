using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GBLWeb
{
    public partial class UIDblIntervall : System.Web.UI.UserControl, mkoIt.Asp.IDblIntervalCtrl
    {      

        public class UIDblIntervallException : Exception
        {
            public UIDblIntervallException(bool vonErr, bool bisErr, string msg)
                : base(msg)
            {
                _vonErr = vonErr;
                _bisErr = bisErr;
            }

            bool _vonErr;
            public bool VonErr
            {
                get
                {
                    return _vonErr;
                }
            }

            bool _bisErr;
            public bool BisErr
            {
                get
                {
                    return _bisErr;
                }
            }
        }

        //-------------------------------------------------------------------------------------------
        // Events
        public class InitMinAndMaxArgs : EventArgs
        {
            UIDblIntervall ctrl;
            public InitMinAndMaxArgs(UIDblIntervall uiDblCtrl)
            {
                ctrl = uiDblCtrl;
            }

            public double MinimumValue
            {
                set
                {
                    ctrl.MinimumValue = value;
                }
            }

            public double MaximumValue
            {
                set
                {
                    ctrl.MaximumValue = value;
                }
            }

            public int Steps
            {
                set
                {
                    ctrl.Steps = value;
                }
            }
        }

        public delegate void InitMinAndMaxEventHandler(object sender, InitMinAndMaxArgs args);
        public event InitMinAndMaxEventHandler InitMinAndMax;

        public event EventHandler IntervalChanged;

        // Kleinster Wert, das als Intervalluntergrenze zulässig ist

        double _MinimumValue;
        public double MinimumValue
        {
            get
            {
                return _MinimumValue;
            }
            set
            {                
                _MinimumValue = value;

                if (!IsPostBack)
                {
                    tbxVon.Text = "min";       
                }
            }
        }

        // Modernstes Datum, das als Intervallobergrenz zulässig ist  
        double _MaximumValue;
        public double MaximumValue
        {
            get
            {
                return _MaximumValue;
            }
            set
            {                
                _MaximumValue = value;                

                if (!IsPostBack)
                {
                   
                    tbxBis.Text = "max";                  
                }
            }
        }

        int _Steps;
        public int Steps
        {
            set
            {
                _Steps = value;                
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (InitMinAndMax != null)
                InitMinAndMax(this, new InitMinAndMaxArgs(this));
            //if (!IsPostBack && IntervalChanged != null)
            //{
            //    IntervalChanged(this, null);
            //}
        }

        protected void btnResetVon_Click(object sender, EventArgs e)
        {
            tbxVon.Text = "min";
            if (IntervalChanged != null)
                IntervalChanged(this, null);
        }

        protected void btnResetBis_Click(object sender, EventArgs e)
        {
            tbxBis.Text = "max";
            if (IntervalChanged != null)
                IntervalChanged(this, null);
        }

        public bool Restriktion
        {
            get
            {
                if (Intervall.Begin > MinimumValue || Intervall.End < MaximumValue)
                    return true;
                else
                    return false;
            }
        }

        public mko.Interval<double> Intervall
        {
            get
            {
                //Page.Validate();
                //if (Page.IsValid)
                //{
                    mko.Interval<double> _vonBis = new mko.Interval<double>();
                    if (tbxVon.Text.ToLower() == "min" || string.IsNullOrEmpty(tbxVon.Text))
                        _vonBis.Begin = MinimumValue;
                    else
                    {
                        double von;
                        if (double.TryParse(tbxVon.Text, out von))
                            _vonBis.Begin = von;
                        else
                            throw new UIDblIntervallException(true, false, "\"min\" enthält keinen Double- Wert");
                    }

                    if (tbxBis.Text.ToLower() == "max" || string.IsNullOrEmpty(tbxBis.Text))
                        _vonBis.End = MaximumValue;
                    else
                    {
                        double bis;
                        if (double.TryParse(tbxBis.Text, out bis))
                            _vonBis.End = bis;
                        else
                            throw new UIDblIntervallException(false, true, "\"max\" enthält keinen Double- Wert");
                    }

                    //if (_vonBis.Begin > _vonBis.End)
                    //    throw new UIDblIntervallException(true, true, "Das Intervallende ist kleiner als der Intervallanfang");

                    return _vonBis;
                //}
                //else
                //    throw new UIDblIntervallException(true, true, "Die Definition des Intervalles ist ungültig");
            }

            set
            {
                System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                //System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

                if (value.Begin == MinimumValue)
                    tbxVon.Text = "min";
                else
                    tbxVon.Text = value.Begin.ToString(ci.NumberFormat);

                if (value.End == MaximumValue)
                    tbxBis.Text = "max";
                else
                    tbxBis.Text = value.End.ToString(ci.NumberFormat);
            }

        }

        protected void vldVon_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (string.IsNullOrEmpty(args.Value))
                args.IsValid = true;
            else
            {
                double von;
                if (double.TryParse(args.Value, out von))
                    if (MinimumValue <= von && von <= MaximumValue)
                        args.IsValid = true;
            }
        }

        protected void vldBis_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (string.IsNullOrEmpty(args.Value))
                args.IsValid = true;
            else
            {
                double bis;
                if (double.TryParse(args.Value, out bis))
                    if (MinimumValue <= bis && bis <= MaximumValue)
                        args.IsValid = true;

            }
        }

        bool IntervalChangedFired = false;
        protected void tbxVon_TextChanged(object sender, EventArgs e)
        {
            if (IntervalChanged != null && !IntervalChangedFired)
            {
                IntervalChangedFired = true;
                IntervalChanged(this, null);
            }
        }

        protected void tbxBis_TextChanged(object sender, EventArgs e)
        {
            if (IntervalChanged != null && !IntervalChangedFired)
            {
                IntervalChangedFired = true;
                IntervalChanged(this, null);
            }
        }


        #region IDblIntervalCtrl Member

        double mkoIt.Asp.IDblIntervalCtrl.Maximum
        {
            get
            {
                return MaximumValue;
            }
            set
            {
                MaximumValue = value;
            }
        }

        double mkoIt.Asp.IDblIntervalCtrl.Minimum
        {
            get
            {
                return MinimumValue;
            }
            set
            {
                MinimumValue = value;
            }
        }

        bool mkoIt.Asp.IDblIntervalCtrl.Restriktion
        {
            get
            {
                return Restriktion;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        mko.Interval<double> mkoIt.Asp.IDblIntervalCtrl.VonBis
        {
            get
            {
                return Intervall;
            }
            set
            {
                Intervall = value;
            }
        }

        event EventHandler mkoIt.Asp.IDblIntervalCtrl.VonBisChanged
        {
            add { 
                IntervalChanged +=new EventHandler(value);
            }
            remove {
                IntervalChanged -= new EventHandler(value);
            }
        }

        #endregion
    }
}