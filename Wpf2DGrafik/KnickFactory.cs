using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using wpf = System.Windows;
using wpf2d = System.Windows.Shapes;
using media = System.Windows.Media;

namespace Wpf2DGrafik
{
    public class KnickFactory : ShapeFactory
    {
        public KnickFactory()
        {
            _StepCount = 3;
        }


        protected override System.Windows.Shapes.Shape createShape()
        {
            var pc = new media.PointCollection();
            pc.Add(bases[0]);
            pc.Add(bases[1]);
            pc.Add(bases[2]);

            return new wpf2d.Polyline()
            {
                Name = MakeCtrlId(),
                HorizontalAlignment = wpf.HorizontalAlignment.Left,
                VerticalAlignment = wpf.VerticalAlignment.Top,
                Stroke = media.Brushes.Black,
                StrokeThickness = 5,
                Points = pc
            };
        }
    }
}
