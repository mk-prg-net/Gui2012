using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprachkonzepte
{
    public class Enumeratoren
    {

        public enum Operators
        {
            mean, min, max
        }


        public IEnumerable<string> AllOperatorsAsString
        {
            get
            {
                yield return Operators.mean.ToString();
                yield return Operators.min.ToString();
                yield return Operators.max.ToString();
            }
        }


        /// <summary>
        /// Erzeugt eine Liste aufsteigender Indizes
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        IEnumerable<int> IndexGenerator(int max)
        {
            for (int i = 0; i <= max; i++)
                yield return i;

        }

        IEnumerable<bool> BoolFieldGenerator(bool value, int max)
        {
            for (int i = 0; i <= max; i++)
                yield return value;

        }

        IEnumerable<Tuple<int, int, bool>> TableGenerator(int[] Col1, bool[] Col2)
        {
            for (int line = 0; line < Col1.Length; line++)
                yield return new Tuple<int, int, bool>(line, Col1[line], Col2[line]);
        }


        public bool testeEnumertoren()
        {
            foreach (string op in AllOperatorsAsString)
            {
                Debug.WriteLine(op);
            }

            int id = 0;
            var listeOps = AllOperatorsAsString.Select(op => new { Id = id++, Op = op });


            foreach(int z in IndexGenerator(5))
                Debug.WriteLine(z);

            // Tabelle aufbauen
            var eineListeVonZahlen = IndexGenerator(99).ToArray();
            var einArrayMitBoolWertenFalse = BoolFieldGenerator(false, 99).ToArray();


            var eineTabelle = TableGenerator(eineListeVonZahlen, einArrayMitBoolWertenFalse).ToArray();

            return true;
        }



    }
}
