using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using wpf = System.Windows;
using media = System.Windows.Media;

namespace Wpf2DGrafik
{
    public class Zeichnung
    {
        public List<wpf.Shapes.Shape> Elemente = new List<wpf.Shapes.Shape>();

        public void zeichne(wpf.Controls.Canvas zeichenbrett)
        {
            zeichenbrett.Children.Clear();

            foreach (var sh in Elemente)
                zeichenbrett.Children.Add(sh);
        }


        public void auswählen(int ix)
        {
            for (int i = 0; i < Elemente.Count; i++)
            {
                if (i == ix)
                {
                    Elemente[i].Fill = media.Brushes.Red;
                    Elemente[i].Stroke = media.Brushes.Blue;
                }
                else
                {
                    Elemente[i].Fill = media.Brushes.Transparent;
                    Elemente[i].Stroke = media.Brushes.Black;
                }
            }
        }

        public void auswählen(wpf.Point pos)
        {
            for (int i = 0; i < Elemente.Count; i++)
            {
                if (Elemente[i].IsMouseOver)
                {
                    //Elemente(i).Fill = Brushes.Red
                    Elemente[i].Stroke = media.Brushes.Blue;
                }
                else
                {
                    //Elemente(i).Fill = Brushes.Transparent
                    Elemente[i].Stroke = media.Brushes.Black;
                }
            }
        }
    }
}
