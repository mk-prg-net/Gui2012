using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mag = mko.Newton.OrderOfMagnitude;

namespace mko.Newton
{
    public partial class Length
    {
        /// <summary>
        /// Kerndurchmesser Wasserstoff
        /// </summary>
        public static LengthInMeter<Mag.Femto> DiameterAtomicNucleusHydrogen
        {
            get
            {
                return Femtometer(1.75);
            }
        }

        /// <summary>
        /// Kerndurchmesser Uran
        /// </summary>
        public static LengthInMeter<Mag.Femto> DiameterAtomicNucleusUranium
        {
            get
            {
                return Femtometer(15.0);
            }
        }

        public static LengthInMeter<Mag.Kilo> DiameterEarth
        {
            get {
                return Kilometer(12756.0);
            }
        }

        public static LengthInMeter<Mag.Kilo> DiameterEarthMoon
        {
            get
            {
                return Kilometer(2.0*1738.0);
            }
        }

        public static LengthInMeter<Mag.Kilo> DiameterMars
        {
            get
            {
                return Kilometer(6794.0);
            }
        }

        public static LengthInMeter<Mag.Kilo> DiameterJupiter
        {
            get
            {
                return Kilometer(142984.0);
            }
        }

        public static LengthInMeter<Mag.Kilo> DiameterSun
        {
            get
            {
                return Kilometer(6.96342e5);
            }
        }





    }
}
