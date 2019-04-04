using System;
using System.Diagnostics;
using System.Linq;
using AlgorithmDesigns.Chapter3.Exercise13;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesigns.Tests.Chapter3
{
    [TestClass]
    public class Exercise13Tests
    {
        [TestMethod]
        public void Exercise13SumTest()
        {
            int[] dataArray = { 1, 1, 1, 1, 1, 1, 1, 1 };
            ArraySumHelper helper = new ArraySumHelper(dataArray);

            var partialSum4 = helper.PartialSum(4);
            //Assert.AreEqual(partialSum4, new int[] {8, 4, 4, 2, 2, 2, 2});
            Assert.AreEqual(partialSum4, 4);

            helper.Add(4, 1);

            var partialSum4Added = helper.PartialSum(4);
            //Assert.AreEqual(partialSum4Added, new int[] { 9, 5, 4, 2, 3, 2, 2 });
            Assert.AreEqual(partialSum4Added, 5);
        }

        [TestMethod]
        public void Exercise13LargeSumTest()
        {
            int[] dataArray = new int[100000];
            for (int i = 0; i < dataArray.Length; i++) { dataArray[i] = 1; }
            ArraySumHelper helper = new ArraySumHelper(dataArray);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var partialSum4 = helper.PartialSum(99999);
            Assert.AreEqual(partialSum4, 99999);

            helper.Add(4, 1);

            var partialSum4Added = helper.PartialSum(99999);
            //Assert.AreEqual(partialSum4Added, new int[] { 9, 5, 4, 2, 3, 2, 2 });
            Assert.AreEqual(partialSum4Added, 100000);
            watch.Stop();
            Console.WriteLine($"Timetaken: {watch.ElapsedMilliseconds} ms");
        }
    }
}
