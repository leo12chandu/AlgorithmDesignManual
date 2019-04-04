using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AlgorithmDesigns.Chapter4.Exercise37;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesigns.Tests.Chapter4
{
    [TestClass]
    public class Exercise37Tests
    {
        [TestMethod]
        public void SelectionSort_SimpleTest()
        {
            var input = "selectionsort".ToCharArray().ToList<char>();
            ISortingAlgo<char> algo = new SelectionSort<char>();
            var output = algo.Sort(input);

            Assert.AreEqual("ceeilnoorsstt", new string(output.ToArray()));
        }

        [TestMethod]
        public void SelectionSort_StringsTest()
        {
            var input = "This is testing string sorting".Split(' ').ToList<string>();
            ISortingAlgo<string> algo = new SelectionSort<string>();
            var output = algo.Sort(input);

            Assert.AreEqual("is", output.First());
            Assert.AreEqual("This", output.Last());
        }

        [TestMethod]
        public void InsertionSort_SimpleTest()
        {
            var input = "insertionsort".ToCharArray().ToList<char>();
            ISortingAlgo<char> algo = new InsertionSort<char>();
            var output = algo.Sort(input);

            Assert.AreEqual("eiinnoorrsstt", new string(output.ToArray()));
        }

        [TestMethod]
        public void HeapSort_SimpleTest()
        {
            var input = "heapsort".ToCharArray().ToList<char>();
            ISortingAlgo<char> algo = new HeapSort<char>();
            var output = algo.Sort(input);

            Assert.AreEqual("aehoprst", new string(output.ToArray()));
        }

        [TestMethod]
        public void MergeSort_SimpleTest()
        {
            var input = "mergesort".ToCharArray().ToList<char>();
            ISortingAlgo<char> algo = new MergeSort<char>();
            var output = algo.Sort(input);

            Assert.AreEqual("eegmorrst", new string(output.ToArray()));
        }

        [TestMethod]
        public void MergeSortParallel_SimpleTest()
        {
            var input = "mergesort".ToCharArray().ToList<char>();
            ISortingAlgo<char> algo = new MergeSortParallel<char>();
            var output = algo.Sort(input);

            Assert.AreEqual("eegmorrst", new string(output.ToArray()));
        }

        [TestMethod]
        public void QuickSort_SimpleTest()
        {
            var input = "quicksort".ToCharArray().ToList<char>();
            ISortingAlgo<char> algo = new QuickSort<char>();
            var output = algo.Sort(input);

            Assert.AreEqual("cikoqrstu", new string(output.ToArray()));
        }

        [TestMethod]
        public void AllSortAlgos_FileTest()
        {
            Dictionary<ISortingAlgo<string>, long> sortingTimes = new Dictionary<ISortingAlgo<string>, long>();
            Dictionary<ISortingAlgo<string>, int> sortingOutputCounts = new Dictionary<ISortingAlgo<string>, int>();
            List<ISortingAlgo<string>> sortingAlgos = new List<ISortingAlgo<string>>()
            {
                new SelectionSort<string>(), // takes the longest.
                new InsertionSort<string>(),
                new HeapSort<string>(),
                new MergeSort<string>(),
                //new MergeSortParallel<string>()
                new QuickSort<string>()
            };
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var inputText = File.ReadAllText("/Users/leo12_chandu/Projects/AlgorithmDesignManaul/TestFiles/SampleTextFile_200kb.txt");
            var input = inputText.Split(' ').ToList<string>();

            watch.Stop();
            var readFileTime = watch.ElapsedMilliseconds;

            foreach (var sortingAlgo in sortingAlgos)
            {
                // clone input. So, if a sortAlgo changes the array, it wont impact the next one.
                var clonedInput = input.Select(item => (string)item.Clone()).ToList<string>();
                watch.Reset();
                watch.Start();
                var output = sortingAlgo.Sort(clonedInput);
                watch.Stop();

                var sortTime = watch.ElapsedMilliseconds;
                sortingTimes.Add(sortingAlgo, sortTime);
                sortingOutputCounts.Add(sortingAlgo, output.Count);
            }


            //Assert.AreEqual("eegmorrst", new string(output.ToArray()));
        }

    }
}
