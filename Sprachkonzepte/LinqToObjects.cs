using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Sprachkonzepte
{   

    class LinqToObjects
    {

        long[] zahlen = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };


        bool IstDurch2Teilbar(long zahl)
        {
            return zahl % 2 == 0;
        }

        public void exec()
        {

            var alleDurch2Teilbaren = zahlen.Where(IstDurch2Teilbar);

            Debug.WriteLine("Alle durch 2 teilbaren");
            foreach (long zahl in alleDurch2Teilbaren)
                Debug.Write(zahl + ", ");

            // Gleiche Lösung mittels Lambda- Ausdruck
            alleDurch2Teilbaren = zahlen.Where(z => z % 2 == 0);

        }

    }
}
