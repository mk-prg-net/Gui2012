using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mko.Algo.NumberTheory
{
    public class IntervalLong
    {

        public IntervalLong() { }
        public IntervalLong(long Begin, long End)
        {
            this.Begin = Begin;
            this.End = End;
        }

        public long Begin{ get; set;}
        public long End{ get; set;}

        /// <summary>
        /// Gibt true zurück, wenn die zahl im Intervall enthalten ist
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public bool Contains(long z)
        {
            return Begin <= z && z <= End;
        }

        /// <summary>
        /// Gibt true zurück, wenn das übergebene Intevall im Intervall enthalten ist
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public bool Contains(IntervalLong SubInv)
        {
            return Begin <= SubInv.Begin && SubInv.Begin <= SubInv.End && SubInv.End <= End;
        }

        /// <summary>
        /// Gibt das i-te Element im Intervall, gezählt von Beginn an
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long this[long i] {
            get{
                if (Begin + i > End)
                    throw new ArgumentOutOfRangeException();
                return Begin + i;
            }
        }

        /// <summary>
        /// Anzahl der Elemente im Zahlenbereich
        /// </summary>
        public long Count
        {
            get
            {
                if (Begin > End)
                    throw new Exception();
                return (End - Begin) + 1;
            }
        }

    }
}
