using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Euk = mko.Euklid;
using Gph = mko.Graphic;
using GphW3 = mko.Graphic.WebClient;
using Css = mkoIt.Xhtml.Css;
using System.Diagnostics;


namespace WebGraphics.Models
{
    [Serializable]
    public class Polygon
    {
        List<Euk.Vector> polygon = new List<Euk.Vector>();

        public void Clear()
        {
            polygon.Clear();
        }

        public bool StartsAt(Euk.Vector P)
        {
            Debug.Assert(P.Dimensions == 2);
            polygon.Clear();
            polygon.Add(new Euk.Vector(P));
            return true;
        }

        public bool LineTo(Euk.Vector P)
        {
            Debug.Assert(P.Dimensions == 2);
            polygon.Add(new Euk.Vector(P));
            return true;            
        }

        GphW3.PenSolidColor Pen = new GphW3.PenSolidColor(Css.Color.Black, Css.BorderStyleMeasure.Solid, new Css.LengthMeasurePixel(3));
        GphW3.BrushSolidColor Brush = new Gph.WebClient.BrushSolidColor(Css.Color.Orange);


        public Gph.Block PolygonBlock
        {
            get
            {
                List<Gph.Line> lines = new List<Gph.Line>(3 + polygon.Count / 2);
                Euk.Vector[] P = new Euk.Vector[2];
                if (polygon.Count > 1)
                {
                    for (int i = 1; i < polygon.Count; i++)
                    {
                        //P[i % 2] = polygon[i];
                        //if (i % 2 != 0)
                        //{
                            lines.Add(new Gph.Line(polygon[i - 1], polygon[i], Brush, Pen));
                        //}
                    }
                }

                return new Gph.Block(lines.ToArray());
            }
        }
    }
}