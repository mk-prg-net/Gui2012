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
    public class Drawing
    {
        public enum EditOperators
        {
            moveTo, lineTo, undo, clear
        }

        GphW3.PenSolidColor Pen = new GphW3.PenSolidColor(Css.Color.Black, Css.BorderStyleMeasure.Solid, new Css.LengthMeasurePixel(3));        
        GphW3.BrushSolidColor Brush = new Gph.WebClient.BrushSolidColor(Css.Color.Orange);

        public mko.Graphic.Block Block { get; set; }

        public Drawing()
        {            
        }

        public Drawing(mko.Graphic.Block block)
        {
            this.Block = block;
        }

        int EdgeCount = 0;
        private Euk.Line ConstructionLine = new Euk.Line(2);

        public bool Clear()
        {
            EdgeCount = 0;
            return Block.Clear();
        }

        

        public IEnumerable<dynamic> GetAllShapeDescriptions()
        {
            var allShapes = new LinkedList<mko.Graphic.Shape>();
            Block.CollectAllShapes(Block, allShapes);
            int i = 0;
            return allShapes.Select(shape => new { no = i++, type = shape.ToString() });

        }

    }
}