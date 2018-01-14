using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprachkonzepte
{
    public class LambdaAndDelegates
    {

        double Add(double a, double b)
        {
            return a + b;
        }

        double Mul(double a, double b) { return a * b; }
        // (double a, double b) => { return a * b; } zum Mul passender Lambdaausdruck

        // Ein Delegate von System.Delegate ableiten, der zu den Mul und Add- MEthoden passt

        delegate double DGBinOp(double a, double b);


        // Delegates einsetzen, um Rückrufmethoden an Unterprogramme zu übergeben (op ist der Callback)
        double Calculator(double a, double b, DGBinOp op)
        {
            return op.Invoke(a, b);
        }

        public bool exec()
        {

            var myDg = new DGBinOp(Add);

            double res = myDg.Invoke(1, 2);

            // Kurzschreibweise
            res = myDg(3, 6);

            // Ein Delegate kann n Einsprungadressen aufnehmen
            myDg += new DGBinOp(Mul);

            // Eine etwas sinnlose Anwendung von Delegates
            res = myDg(3, 6);

            // Einen Einsprungpunkt aus der Liste entfernen
            myDg -= new DGBinOp(Mul);

            res = myDg(3, 6);

            res = Calculator(2, 7, new DGBinOp(Add));
            res = Calculator(2, 7, new DGBinOp(Mul));


            // Lambdaausdruck als Sprachmittel, um inline Funktionen/Unterprogramme zu definieren

            res = Calculator(2, 7, (double a, double b) => { var summe = a + b; return 5 * summe; });

            res = Calculator(2, 7, (a, b) => { var summe = a + b; return 5 * summe; });

            res = Calculator(2, 7, (a, b) => { return 5 * (a + b); });

            res = Calculator(2, 7, (a, b) => 5 * (a + b));

            // Lambdaausdrücke anwenden in Link- Erweiterungsmethoden

            int[] zahlen = { 3, 4, 6, 9, 12, 16, 18 };

            // Alle Zahlen, die durch 3 teilbar sind
            // klassisch 
            var lst3 = new List<int>();
            foreach (var z in zahlen)
            {
                if (z % 3 == 0)
                    lst3.Add(z);
            }

            // Linq

            var lst3_2 = zahlen.Where(z => z % 3 == 0).ToList();

            // Abfrage wird definiert
            var lst3_2_1 = zahlen.Where(z => z % 3 == 0);

            // Ergbnisse der Abfrage abgerufen
            var lst3_2_2 = lst3_2_1.ToArray();

            return true;

        }


    }
}
