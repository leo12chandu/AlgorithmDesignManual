using System;
using System.Diagnostics;
using System.Linq;
using AlgorithmDesigns.RamanujamNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesigns.Tests
{
    [TestClass]
    public class RamanujamNumbersTest
    {
        [TestMethod]
        public void Test10Elements_ExpectRamanujamPairs()
        {
            // BigOh (n-squared)
            int noOfElements = 1000;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var sumPairs = RamanujamGenerator.GeneratePairs(noOfElements);

            watch.Stop();
            var totalTime = watch.ElapsedMilliseconds;

            var ramanujamPairs = sumPairs.Where(d => d.Value.Count > 1);
            //Assert.AreEqual(1, pyramidalSums[2].First());
            Assert.IsTrue(ramanujamPairs.Any());
        }
    }
}
