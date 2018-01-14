using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using E = mko.Euklid;
using Htm = mkoIt.Asp.HtmlCtrl;
using Css = mkoIt.Xhtml.Css;
using GphW3 = mko.Graphic.WebClient;


namespace WebDms2.Html5Canvas
{
    public class NikoHomeFactory
    {
        public static void Create(E.Vector Pos, Models.Polygon Model, GphW3.CanvasPlotter Plotter)
        {
            Model.PolygonBlock.Clear();           

            Model.StartsAt(new E.Vector(0, 0) + Pos);
            Model.LineTo(new E.Vector(100, 0) + Pos);
            Model.LineTo(new E.Vector(100, 100) + Pos);
            Model.LineTo(new E.Vector(0, 100) + Pos);
            Model.LineTo(new E.Vector(0, 0) + Pos);
            Model.LineTo(new E.Vector(100, 100) + Pos);

            Model.PolygonBlock.draw(Plotter);

        }

    }
}