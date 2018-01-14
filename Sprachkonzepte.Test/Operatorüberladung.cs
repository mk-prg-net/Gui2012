using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sprachkonzepte.Operatorüberladung;

namespace Sprachkonzepte.Test
{
    [TestClass]
    public class Operatorüberladung
    {
        [TestMethod]
        public void OperatorüberladungTest()
        {
            var a = new Romzahl("MDCLXVI");
            var b = new Romzahl("XIII");

            // Explizite Wandlung mit Konvertierungsoperator
            long MDCLXVI = (long)a;
            Assert.AreEqual(MDCLXVI, 1666);

            // Aufruf des selbstdefinierten Additionsoperators für Romzahlen
            var RomSumme = a + b;
            long LongSumme = (long)RomSumme;
            Assert.AreEqual(LongSumme, 1679);

        }
    }
}
