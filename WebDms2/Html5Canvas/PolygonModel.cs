using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Euk = mko.Euklid;
using Gph = mko.Graphic;
using GphW3 = mko.Graphic.WebClient;
using Css = mkoIt.Xhtml.Css;
using System.Diagnostics;


namespace WebDms2.Html5Canvas.Models
{
    /// <summary>
    /// Polygonzug
    /// </summary>
    [Serializable]
    public class Polygon
    {
        // Liste der Ortsvektoren, die den Polygonzug definieren
        List<Euk.Vector> polygon = new List<Euk.Vector>();

        // Liste der Farben der Verbindungslinien zwischen jeweils zwei Ortsvektoren
        List<Css.Color> colors = new List<Css.Color>();

        Css.Color _defaultColor = Css.Color.Red;
        public Css.Color DefaultColor
        {
            get
            {
                return _defaultColor;
            }
            set
            {
                _defaultColor = value;
            }
        }

        // Neuen Polygonzug anlegen
        public void Clear()
        {
            polygon.Clear();
            colors.Clear();
        }

        /// <summary>
        /// Startpunkt eines Polygons definieren
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public bool StartsAt(Euk.Vector P)
        {
            Debug.Assert(P.Dimensions == 2);
            polygon.Clear();
            polygon.Add(new Euk.Vector(P));
            return true;
        }

        /// <summary>
        /// Nächsten Polygonpunkt definieren
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public bool LineTo(Euk.Vector P)
        {
            Debug.Assert(P.Dimensions == 2);
            polygon.Add(new Euk.Vector(P));
            return true;
        }

        /// <summary>
        /// Nächsten Polygonpunkt zusammen mit einer Farbe definieren
        /// </summary>
        /// <param name="P"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool LineTo(Euk.Vector P, Css.Color color)
        {
            Debug.Assert(P.Dimensions == 2);
            polygon.Add(new Euk.Vector(P));
            colors.Add(color);
            return true;
        }

        //public GphW3.PenSolidColor Pen = new GphW3.PenSolidColor(Css.Color.Black, Css.BorderStyle.Solid, new Css.LengthPixel(3));
        //public GphW3.BrushSolidColor Brush = new Gph.WebClient.BrushSolidColor(Css.Color.Orange);

        /// <summary>
        /// Polygon als Block grafischer Primitive ausgeben
        /// </summary>
        public Gph.Block PolygonBlock
        {
            get
            {
                List<Gph.Line> lines = new List<Gph.Line>(3 + polygon.Count / 2);
                Euk.Vector[] P = new Euk.Vector[2];
                if (polygon.Count > 1)
                {
                    if (colors.Any())
                    {
                        for (int i = 1; i < polygon.Count; i++)
                        {
                            int ixColor = (i - 1) % colors.Count;
                            var Pen = new GphW3.PenSolidColor(colors[ixColor], Css.BorderStyle.Solid, Css.LengthPixel.Pixel(4));
                            var Brush = new GphW3.BrushSolidColor(colors[ixColor]);
                            lines.Add(new Gph.Line(polygon[i - 1], polygon[i], Brush, Pen));
                        }
                    }
                    else
                    {
                        var Pen = new GphW3.PenSolidColor(DefaultColor, Css.BorderStyle.Solid, Css.LengthPixel.Pixel(4));
                        var Brush = new GphW3.BrushSolidColor(DefaultColor);
                        for(int i = 1; i < polygon.Count; i++)
                            lines.Add(new Gph.Line(polygon[i - 1], polygon[i], Brush, Pen));
                    }
                }

                return new Gph.Block(lines.ToArray());
            }
        }
    }
}