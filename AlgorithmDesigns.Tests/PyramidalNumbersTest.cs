using System.Diagnostics;
using System.Linq;
using AlgorithmDesigns.PyramidalNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesigns.Tests
{
    [TestClass]
    public class PyramidalNumbersTest
    {
        [TestMethod]
        public void Test10Elements_ExpectPyramidals()
        {
            int noOfElements = 1000000;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            PyramidalEvaluater evaluater = new PyramidalEvaluater(noOfElements);

            var pyramidalSums = evaluater.GetPyramidalSums();

            watch.Stop();
            var totalTime = watch.ElapsedMilliseconds;

            Assert.AreEqual(1, pyramidalSums[2].First());
        }
    }
}
