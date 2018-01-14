using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mag = mko.Newton.OrderOfMagnitude;

namespace mko.Newton
{
    public partial class Acceleration
    {
        /// <summary>
        /// Fallbeschleunigung auf der Erde
        /// </summary>
        public static AccelerationInMeterPerSec<Mag.One> GravityOnEarth
        {
            get
            {
                return MeterPerSec2(9.81);
            }
        }

        /// <summary>
        /// Fallbeschleunigung auf dem Erdmond
        /// </summary>
        public static AccelerationInMeterPerSec<Mag.One> GravityOnEarthMoon
        {
            get
            {
                return MeterPerSec2(1.6249);
            }
        }

        /// <summary>
        /// Fallbeschleunigung auf dem Mars
        /// </summary>
        public static AccelerationInMeterPerSec<Mag.One> GravityOnMars
        {
            get
            {
                return MeterPerSec2(3.711);
            }
        }

        /// <summary>
        /// Fallbeschleunigung auf dem Jupiter
        /// </summary>
        public static AccelerationInMeterPerSec<Mag.One> GravityOnJupiter
        {
            get
            {
                return MeterPerSec2(24.79);
            }
        }

        /// <summary>
        /// Fallbeschleunigung auf der Sonne
        /// </summary>
        public static AccelerationInMeterPerSec<Mag.One> GravityOnSun
        {
            get
            {
                return MeterPerSec2(274.0);
            }
        }

    }
}
