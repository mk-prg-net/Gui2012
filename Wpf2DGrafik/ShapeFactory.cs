using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using wpf = System.Windows;

namespace Wpf2DGrafik
{
    /// <summary>
    /// Basisklasse für Algorithmen zum Erzeugen von 2d- Grafikprimitiven mit der Maus
    /// </summary>
    public abstract class ShapeFactory
    {
        public static string MakeCtrlId()
        {
            return "N" + Guid.NewGuid().ToString().Replace('{', '_').Replace('}', '_').Replace('-', '_');
        }

        protected int _StepCount;
        protected int BuildStepCount
        {
            get
            {
                return _StepCount;
            }
        }

        int _Step = 0;
        public int BuildStep
        {
            get
            {
                return _Step;
            }
        }

        // Liste der Stützstellen, auf denen die Figur erzeugt wird (z.B. Start & Endpunkt einer Linie)
        protected List<wpf.Point> bases = new List<wpf.Point>();

        // Mit der Methode werden alle Stützpunkte der Figur erfasst. Nach erfassen des letzten 
        // Stützpunktes wird die Figur erzeugt und der Zeichnung hinzugefügt
        public bool CollectBaseAndCreateShape(wpf.Point pos, Zeichnung drawing)
        {
            if (_Step < _StepCount - 1)
            {
                _Step += 1;
                bases.Add(pos);
                return false;
            }
            else
            {
                bases.Add(pos);
                drawing.Elemente.Add(createShape());

                // Für nächste erfassung von Stützpunkten bereitmachen
                _Step = 0;
                bases.Clear();
                return true;
            }
        }


        // In einer abgeleiteten Klasse wird in dieser virtuellen Methode über den Stütztstellen 
        // die eigentliche Figur erzeugt
        protected abstract wpf.Shapes.Shape createShape();
    }
}
