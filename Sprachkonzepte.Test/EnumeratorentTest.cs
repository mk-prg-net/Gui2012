using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SprachkonzepteTest
{
    [TestClass]
    public class EnumeratorentTest
    {
        [TestMethod]
        public void EnumTestMethod()
        {
            var obj = new Sprachkonzepte.Enumeratoren();

            Assert.IsTrue(obj.testeEnumertoren());
        }
    }
}
