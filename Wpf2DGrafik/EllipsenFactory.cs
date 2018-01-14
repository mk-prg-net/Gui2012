using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using wpf = System.Windows;
using wpf2d = System.Windows.Shapes;
using media = System.Windows.Media;

namespace Wpf2DGrafik
{
    class EllipsenFactory : ShapeFactory
    {

        public EllipsenFactory()
        {
            _StepCount = 2;
        }

        protected override wpf2d.Shape createShape()
        {
            return new wpf2d.Ellipse()
            {
                Name = MakeCtrlId(),
                HorizontalAlignment = wpf.HorizontalAlignment.Left,
                VerticalAlignment = wpf.VerticalAlignment.Top,
                Margin = new wpf.Thickness()
                {
                    Top = Math.Min(bases[0].Y, bases[1].Y),
                    Left = Math.Min(bases[0].X, bases[1].X)
                },
                Stroke = media.Brushes.Black,
                Width = Math.Abs(bases[0].X - bases[1].X),
                Height = Math.Abs(bases[0].Y - bases[1].Y)
            };
        }
    }
}
