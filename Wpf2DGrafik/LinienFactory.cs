using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using wpf = System.Windows;
using wpf2d = System.Windows.Shapes;
using media = System.Windows.Media;

namespace Wpf2DGrafik
{
    class LinienFactory : ShapeFactory
    {
        public LinienFactory()
        {
            _StepCount = 2;
        }

        protected override wpf.Shapes.Shape createShape()
        {
            return new wpf2d.Line()
            {
                Name = MakeCtrlId(),
                Stroke = media.Brushes.Black,
                StrokeThickness = 5,
                X1 = bases[0].X,
                X2 = bases[1].X,
                Y1 = bases[0].Y,
                Y2 = bases[1].Y
            };
        }
    }
}
