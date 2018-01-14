using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Steuerelemente
{
    public class LabledUri
    {
        public string UriLabel { get; set; }
        public string Uri { get; set; }

        // ListBoxItem generiert den Content aus LAbelUri, indem die 
        // ToString- MEthode aufgerufen wird. 
        public override string ToString()
        {
            return UriLabel;
        }
    }
}
