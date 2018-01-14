using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sprachkonzepte.Test
{
    [TestClass]
    public class DelegatesTest
    {
        [TestMethod]
        public void TesteDelegates()
        {
            var obj = new Sprachkonzepte.LambdaAndDelegates();

            Assert.IsTrue(obj.exec());
        }
    }
}
