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
    public class CornerPoint
    {
        public enum Operators
        {
            starts, lineTo
        }

        public Operators Operator { get; set; }

        public int CornerCount { get; set; }

        public double PX { get; set; }
        public double PY { get; set; }

        public Euk.Vector P
        {
            get
            {
                return new Euk.Vector(PX, PY);
            }
        }
    }
}