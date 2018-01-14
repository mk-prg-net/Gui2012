using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfDatenbindungAllg
{
    /// <summary>
    /// Eine Entfernungsangabe von einem Bezugspunkt (z.B. Heimatadresse)
    /// </summary>
    public class Entfernung
    {
        public Entfernung() { }
        public string Ort { get; set; }

        public double EntfernungInKm { get; set; }
    }
}
