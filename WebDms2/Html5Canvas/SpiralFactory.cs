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
    public class SpiralFactory
    {
        public static void Create(double Vergrößerungsfaktor, Models.Polygon Model, GphW3.CanvasPlotter Plotter)
        {

            var v = new E.Vector(500, 400);
            Model.Clear();
            Model.StartsAt(v);            

            Css.Color[] colors = { Css.Color.Green, Css.Color.Lime, Css.Color.Orange, Css.Color.Aqua };

            for (int phi = 0, ci = 0; phi < 360; phi += 4, ci++)
            {
                var vs = new E.Vector(100, 0);
                var rot = new E.Transformations.RotationInCylindricalCoordinates(2, phi * Math.PI / 180.0, 0, 1);
                var scale = new E.Transformations.Scale(Vergrößerungsfaktor * phi / 360.0, 1);

                var vrand = rot.apply(scale.apply(vs)) + v;

                Model.LineTo(vrand, colors[ci % colors.Length]);
            }

            Model.PolygonBlock.draw(Plotter);
        }
    }
}