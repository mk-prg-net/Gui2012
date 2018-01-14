using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mag = mko.Newton.OrderOfMagnitude;

namespace mko.Newton
{
    public partial class Mass
    {
        /// <summary>
        /// Ruhemasse des Elektron
        /// </summary>
        public static MassInGram<Mag.Kilo> MassOfElectron
        {
            get
            {
                return Kilogram(9.10938291e-31);
            }
        }

        /// <summary>
        /// Ruhemasse des Protons
        /// </summary>
        public static MassInGram<Mag.Kilo> MassOfProton
        {
            get
            {
                return Kilogram(1.672621777e-27);
            }
        }

        /// <summary>
        /// Masse des Neutrons
        /// </summary>
        public static MassInGram<Mag.Kilo> MassOfNeutron
        {
            get
            {
                return Kilogram(1.674927351e-27);
            }
        }

        /// <summary>
        /// Masse der Erde
        /// </summary>
        public static MassInGram<Mag.Kilo> MassOfEarth
        {
            get
            {
                return Kilogram(5.9736e24);
            }
        }

        /// <summary>
        /// Masse des Erdmondes
        /// </summary>
        public static MassInGram<Mag.Kilo> MassOfEarthMoon
        {
            get
            {
                return Kilogram(7.3477e22);
            }
        }


        /// <summary>
        /// Masse des Mars
        /// </summary>
        public static MassInGram<Mag.Kilo> MassOfMars
        {
            get
            {
                return Kilogram(6.4185e23);
            }
        }


        /// <summary>
        /// Masse des Jupiters
        /// </summary>
        public static MassInGram<Mag.Kilo> MassOfJupiter
        {
            get
            {
                return Kilogram(1.8986e27);
            }
        }

        /// <summary>
        ///  Masse der Sonne
        /// </summary>
        public static MassInGram<Mag.Kilo> MassOfSun
        {
            get
            {
                return Kilogram(1.9891e30);
            }
        }


        public static MassInGram<Mag.Kilo> GesamtmasseBodenseewasser
        {
            get
            {
                return Kilogram(4.8e13);
            }
        }

    }
}
