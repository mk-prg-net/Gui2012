using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace GBLWeb
{
    public partial class VonBisZeitintervall : System.Web.UI.UserControl, mkoIt.Asp.ITimeIntervalCtrl
    {
        public VonBisZeitintervall()
        {
            BeginningOfTime = new DateTime(1945, 5, 8);
            EndOfTime = new DateTime(3000, 1, 1);
        }

        public class VonBisZeitintervallException : Exception
        {
            public VonBisZeitintervallException(bool vonErr, bool bisErr, string msg)
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
        public event mkoIt.Asp.InitBeginAndEndOfTimeEventHandler InitBeginAndEndOfTime;

        public event EventHandler VonBisChanged;

        // Ältestes Datum, das als Intervalluntergrenze zulässig ist
        public DateTime BeginningOfTime { get; set; }

        // Modernstes Datum, das als Intervallobergrenz zulässig ist
        public DateTime EndOfTime { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (InitBeginAndEndOfTime != null)
                InitBeginAndEndOfTime(this, new mkoIt.Asp.InitBeginAndEndOfTimeArgs(this));
        }

        protected void btnResetVon_Click(object sender, EventArgs e)
        {
            tbxVon.Text = "alt";
            if (VonBisChanged != null)
                VonBisChanged(this, null);
        }

        protected void btnResetBis_Click(object sender, EventArgs e)
        {
            tbxBis.Text = "neu";
            if (VonBisChanged != null)
                VonBisChanged(this, null);
        }

        public bool Restriktion
        {
            get
            {
                if (VonBis.Begin > BeginningOfTime || VonBis.End < EndOfTime)
                    return true;
                else
                    return false;
            }
        }

        public mko.Interval<DateTime> VonBis
        {
            get
            {
                //Page.Validate();
                //if (Page.IsValid)
                //{
                mko.Interval<DateTime> _vonBis = new mko.Interval<DateTime>();
                if (tbxVon.Text.ToLower() == "alt" || string.IsNullOrEmpty(tbxVon.Text))
                    _vonBis.Begin = BeginningOfTime;
                else
                {
                    DateTime von;
                    if (DateTime.TryParse(tbxVon.Text, out von))
                        _vonBis.Begin = von;
                    else
                        throw new VonBisZeitintervallException(true, false, "\"von\" enthält keinen Datumswert");
                }

                if (tbxBis.Text.ToLower() == "neu" || string.IsNullOrEmpty(tbxBis.Text))
                    _vonBis.End = EndOfTime;
                else
                {
                    DateTime bis;
                    if (DateTime.TryParse(tbxBis.Text, out bis))
                        _vonBis.End = bis;
                    else
                        throw new VonBisZeitintervallException(false, true, "\"bis\" enthält keinen Datumswert");
                }

                //if (_vonBis.Begin > _vonBis.End)
                //    throw new VonBisZeitintervallException(true, true, "Das Enddatum für den definierten Zeitraum ist älter als das Startdatum");

                return _vonBis;
                //}
                //else
                //    throw new VonBisZeitintervallException(true, true, "Die Definition des Zeitraumes ist ungültig");
            }

            set
            {
                if (value.Begin == BeginningOfTime)
                    tbxVon.Text = "alt";
                else
                    tbxVon.Text = value.Begin.ToString("dd.MM.yyyy");

                if (value.End == EndOfTime)
                    tbxBis.Text = "neu";
                else
                    tbxBis.Text = value.End.ToString("dd.MM.yyyy");
            }

        }

        protected void vldVon_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (args.Value.ToLower() == "alt" || string.IsNullOrEmpty(args.Value))
                args.IsValid = true;
            else
            {
                DateTime von;
                if (DateTime.TryParse(args.Value, out von))
                    if (BeginningOfTime <= von && von <= EndOfTime)
                        args.IsValid = true;
            }
        }

        protected void vldBis_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (args.Value.ToLower() == "neu" || string.IsNullOrEmpty(args.Value))
                args.IsValid = true;
            else
            {
                DateTime bis;
                if (DateTime.TryParse(args.Value, out bis))
                    if (BeginningOfTime <= bis && bis <= EndOfTime)
                    {
                        if (tbxVon.Text.ToLower() == "alt" || string.IsNullOrEmpty(args.Value))
                            args.IsValid = true;
                        else
                        {
                            DateTime von;
                            if (DateTime.TryParse(tbxVon.Text, out von))
                            {
                                if (von <= bis)
                                    args.IsValid = true;
                            }
                        }
                    }
            }
        }

        bool VonBisChangedFired = false;
        protected void tbxVon_TextChanged(object sender, EventArgs e)
        {
            if (VonBisChanged != null && !VonBisChangedFired)
            {
                VonBisChangedFired = true;
                VonBisChanged(this, null);
            }
        }

        protected void tbxBis_TextChanged(object sender, EventArgs e)
        {
            if (VonBisChanged != null && !VonBisChangedFired)
            {
                VonBisChangedFired = true;
                VonBisChanged(this, null);
            }
        }

        protected void btnCalenderVonOnOff_Click(object sender, ImageClickEventArgs e)
        {
            CalendarVon.Visible = !CalendarVon.Visible;
        }

        protected void btnCalenderBisOnOff_Click(object sender, ImageClickEventArgs e)
        {
            CalendarBis.Visible = !CalendarBis.Visible;
        }

        protected void CalendarVon_SelectionChanged(object sender, EventArgs e)
        {
            tbxVon.Text = string.Format("{0:dd.MM.yyyy}", CalendarVon.SelectedDate);
            CalendarVon.Visible = false;
            if (VonBisChanged != null && !VonBisChangedFired)
            {
                VonBisChangedFired = true;
                VonBisChanged(this, null);
            }
        }

        protected void CalendarBis_SelectionChanged(object sender, EventArgs e)
        {
            tbxBis.Text = string.Format("{0:dd.MM.yyyy}", CalendarBis.SelectedDate);
            CalendarBis.Visible = false;
            if (VonBisChanged != null && !VonBisChangedFired)
            {
                VonBisChangedFired = true;
                VonBisChanged(this, null);
            }
        }


        /// <summary>
        /// Validierungsgruppe für alle Validierungssteuerelemente im Control
        /// </summary>
        public string ValidationGroup
        {
            get
            {
                return vldBis.ValidationGroup;
            }

            set
            {
                vldBis.ValidationGroup = value;
            }
        }

        /// <summary>
        /// Fehlermeldung der Validatoren für das Zeitintervall setzen
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return vldBis.ErrorMessage;
            }

            set
            {
                vldBis.ErrorMessage = value;
            }
        }

        #region ITimeIntervalCtrl Member

        event mkoIt.Asp.InitBeginAndEndOfTimeEventHandler mkoIt.Asp.ITimeIntervalCtrl.InitBeginAndEndOfTime
        {
            add
            {
                InitBeginAndEndOfTime += new mkoIt.Asp.InitBeginAndEndOfTimeEventHandler(value);
            }
            remove { throw new NotImplementedException(); }
        }

        DateTime mkoIt.Asp.ITimeIntervalCtrl.BeginningOfTime
        {
            get
            {
                return BeginningOfTime;
            }
            set
            {
                BeginningOfTime = value;
            }
        }

        DateTime mkoIt.Asp.ITimeIntervalCtrl.EndOfTime
        {
            get
            {
                return EndOfTime;
            }
            set
            {
                EndOfTime = value;
            }
        }

        event EventHandler mkoIt.Asp.ITimeIntervalCtrl.VonBisChanged
        {
            add
            {
                VonBisChanged += new EventHandler(value);
            }
            remove
            {
                VonBisChanged -= new EventHandler(value);
            }
        }

        mko.Interval<DateTime> mkoIt.Asp.ITimeIntervalCtrl.VonBis
        {
            get
            {
                return VonBis;
            }
            set
            {
                VonBis = value;
            }
        }

        bool mkoIt.Asp.ITimeIntervalCtrl.Restriktion
        {
            get
            {
                return Restriktion;
            }
            set
            {

            }
        }

        #endregion
    }

}