//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 14.6.2011
//
//  Projekt.......: DMS.ImageProcessing
//  Name..........: Filter.cs
//  Aufgabe/Fkt...: Experimentelle Bildverarbeitung unter .NET 4
//                  Ein allgemeines 2D Filter wird implementiert
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows XP mit .NET 2.0
//  Werkzeuge.....: Visual Studio 2005
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace DMS.ImageProcessing
{
    public class Filter
    {
        public struct Maskenelement
        {
            /// <summary>
            /// Position des Maskenelements, relativ zu einem Bezugspunkt
            /// </summary>
            public Point P;

            /// <summary>
            /// Koeffzienten des Filters
            /// </summary>
            public double KoeffR;
            public double KoeffG;
            public double KoeffB;
            public double KoeffT;

        }

        protected List<Maskenelement> Maske;        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">X- Koordinate des Bezugspunktes</param>
        /// <param name="y">Y- Koordinate des Bezugspunktes</param>
        /// <param name="bmp">Bitmap, die gefiltert werden soll</param>
        /// <returns>Neuer gefiterter Farbwert anstelle des Bezugspunktes</returns>
        public virtual Color applyAt(int x, int y, Bitmap bmp)
        {
            double sumR = 0;
            double sumG = 0;
            double sumB = 0;
            double sumT = 0;

            foreach (Maskenelement m in Maske)
            {                
                int xAbs = x + m.P.X;
                int yAbs = y + m.P.Y;
                if (xAbs >= 0 && xAbs < bmp.Width && yAbs >= 0 && yAbs < bmp.Width)
                {
                    Color pix = bmp.GetPixel(xAbs, yAbs);
                    sumR += pix.R * m.KoeffR;
                    sumG += pix.G * m.KoeffG;
                    sumB += pix.B * m.KoeffB;
                    sumT += pix.A * m.KoeffT;
                }
            }

            var neu = Color.FromArgb(
                            (Byte)Math.Round(sumT),
                            (Byte)Math.Round(sumR),
                            (Byte)Math.Round(sumG),
                            (Byte)Math.Round(sumB));

            return neu;
        }
    }
}
