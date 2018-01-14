using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormCtrlLib
{

    public partial class ZeitraumBox : UserControl
    {
        public ZeitraumBox()
        {
            InitializeComponent();

            // Gets the attributes for the property.
            AttributeCollection attributes =
               TypeDescriptor.GetProperties(this)["ZeitraumInTagen"].Attributes;

            /* Prints the default value by retrieving the DefaultValueAttribute 
             * from the AttributeCollection. */
            DefaultValueAttribute ZeitraumInTagenDefaultAttribute =
               (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
            

            Von = DateTime.Now.AddDays(1);
            Bis = DateTime.Now.AddDays(2);

        }

        [Browsable(false)]        
        [DefaultValue(30)]
        public double ZeitraumInTagen
        {
            get {
                var span = new TimeSpan(Bis.Ticks - Von.Ticks);
                return span.TotalDays;
            }            
        }

        /// <summary>
        /// Benutzer Zugriff auf dateTimePickerVon ermöglichen
        /// </summary>
        /// 
        [Category("Zeitraum")]
        [DefaultValue(typeof(DateTime), "1.12.2012")]
        public DateTime Von
        {
            get
            {
                return dateTimePickerVon.Value;
            }

            set
            {
                dateTimePickerVon.Value = value;

                // Benachrichtigen von anderen Objekten, daß Von geändert wurde
                OnChangedEvent(PropertyChangedEventArgs.Changed.vonChanged);
            }

        }

        /// <summary>
        /// Benutzer Zugriff auf dateTimePickerBis ermöglichen
        /// </summary>
        /// 
        [Category("Zeitraum")]
        [DefaultValue(typeof(DateTime), "31.12.2012")]
        public DateTime Bis
        {
            get
            {
                return dateTimePickerBis.Value;
            }

            set
            {
                dateTimePickerBis.Value = value;

                // Benachrichtigen von anderen Objekten, daß Bis geändert wurde
                OnChangedEvent(PropertyChangedEventArgs.Changed.bisChanged);
            }
        }

        /// <summary>
        /// Gibt true zurück, wenn die Eingaben einem gültigen Zeitraum entsprechen
        /// </summary>
        public bool Valid
        {
            get
            {
                return Bis.Ticks >= Von.Ticks;
            }
        }

        public class PropertyChangedEventArgs : EventArgs
        {
            public enum Changed {
                vonChanged,
                bisChanged
            };

            public Changed whatIsChanged
            {
                get;
                set;
            }
        }

        public delegate void PropertyChangedEvent(object sender, PropertyChangedEventArgs e);

        [Category("Zeitraum")]
        public event PropertyChangedEvent ChangedEvent;

        // Methode zum Auslösen des Events
        void OnChangedEvent(PropertyChangedEventArgs.Changed vonBisctrl)
        {
            //if (ChangedEvent != null)
            //    ChangedEvent(this, new PropertyChangedEventArgs() { whatIsChanged= vonBisctrl });

            if (ChangedEvent != null)
            {
                PropertyChangedEventArgs pa = new PropertyChangedEventArgs();
                pa.whatIsChanged = vonBisctrl;
                ChangedEvent(this, pa);
            }
        }

        private void dateTimePickerVon_ValueChanged(object sender, EventArgs e)
        {
            OnChangedEvent(PropertyChangedEventArgs.Changed.vonChanged);
        }

        private void dateTimePickerBis_ValueChanged(object sender, EventArgs e)
        {
            OnChangedEvent(PropertyChangedEventArgs.Changed.bisChanged);
        }


    }
}
