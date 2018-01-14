using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace mko
{
    [Serializable]
    public struct Interval<T>
        where T : IComparable<T>
    {
        T _Begin;
        public T Begin {
            get
            {
                //Debug.Assert(_Begin.CompareTo(_End) <= 0, "GblDbLayer.Interval: Begin > End");
                return _Begin;
            }
            set
            {
                _Begin = value;
            }
        }

        T _End;
        public T End {
            get
            {
                //Debug.Assert(_Begin.CompareTo(_End) <= 0, "GblDbLayer.Interval: Begin > End");
                return _End;
            }
            set
            {
                _End = value;
            }
        }

        public override string ToString()
        {
            return "(" + Begin.ToString() + ", " + End.ToString() + ")";
        }

        public bool contains(T value)
        {
            return (_Begin.CompareTo(value) <= 0 && _End.CompareTo(value) >= 0);

        }

    }
}
