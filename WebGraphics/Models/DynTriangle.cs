using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Euk = mko.Euklid;
using Gph = mko.Graphic;
using GphW3 = mko.Graphic.WebClient;
using Css = mkoIt.Xhtml.Css;

namespace WebGraphics.Models
{
    public class DynTriangle
    {
        Euk.Line[] InitialEdges = new Euk.Line[3] {
            new Euk.Line(new Euk.Vector(0.0, 0.0), new Euk.Vector(100.0, 0.0)),
            new Euk.Line(new Euk.Vector(100.0, 0.0), new Euk.Vector(50.0, 70.0)),
            new Euk.Line(new Euk.Vector(50.0, 70.0), new Euk.Vector(0.0, 0.0)),
        };

        Euk.Line[] Edges = new Euk.Line[3];

        Queue<Euk.Line[]> history = new Queue<Euk.Line[]>();

        public DynTriangle()
        {
            int i = 0;
            Edges = InitialEdges.Select(e => Edges[i++] = new Euk.Line(e)).ToArray();
        }

        GphW3.PenSolidColor Pen = new GphW3.PenSolidColor(Css.Color.Black, Css.BorderStyleMeasure.Solid, new Css.LengthMeasurePixel(3));
        GphW3.BrushSolidColor Brush = new Gph.WebClient.BrushSolidColor(Css.Color.Orange);


        public mko.Graphic.Triangle Triangle
        {
            get
            {                
                return new mko.Graphic.Triangle(Edges[0], Edges[1], Edges[2], 0.0001, Brush, Pen);
            }
        }

        bool Translate(Euk.Vector displacement)
        {
            var trafo = new Euk.Transformations.Translation(displacement);
            int i = 0;
            Edges = Edges.Select(e => Edges[i++] = new Euk.Line(e, trafo)).ToArray();
            return true;            
        }

        public DynTriangle MoveLeft(double dx)
        {
            Translate(new Euk.Vector(-dx, 0));
            return this;
        }

        public DynTriangle MoveRight(double dx)
        {
            Translate(new Euk.Vector(dx, 0));
            return this;
        }

        public DynTriangle MoveUp(double dy)
        {
            Translate(new Euk.Vector(0, -dy));
            return this;
        }

        public DynTriangle MoveDown(double dy)
        {
            Translate(new Euk.Vector(0, dy));
            return this;
        }


    }
}