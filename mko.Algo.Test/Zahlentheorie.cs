using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using mko.Algo.NumberTheory;
using Fn = mko.Algo.NumberTheory.Fn;

namespace mko.Algo.Test
    
{
    [TestClass]
    public class Zahlentheorie
    {
        [TestMethod]
        public void PrimeFactorsTest()
        {
            Assert.IsFalse(Fn.PrimeFactors.IsPrime(1));
            Assert.IsTrue(Fn.PrimeFactors.IsPrime(2));
            Assert.IsTrue(Fn.PrimeFactors.IsPrime(3));
            Assert.IsTrue(Fn.PrimeFactors.IsPrime(3499));

            long primefactor;
            Assert.IsFalse(PrimeFactors.PrimeTest(1, out primefactor));
            Assert.IsTrue(PrimeFactors.PrimeTest(2, out primefactor));
            Assert.IsTrue(PrimeFactors.PrimeTest(3, out primefactor));
            Assert.IsTrue(PrimeFactors.PrimeTest(3499, out primefactor));
            Assert.IsTrue(PrimeFactors.PrimeTest(1000003, out primefactor));


            Assert.IsTrue(PrimeFactors.scan(1, 20).SequenceEqual(new long[] { 2, 3, 5, 7, 11, 13, 17, 19 }));

            Assert.IsTrue(PrimeFactors.scan(1, 10000).SequenceEqual(PrimeFactors.scanParallel(1, 10000, false)));



        }
    }
}
