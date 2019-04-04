using System;
using System.Collections.Generic;
using AlgorithmDesigns.Common;

namespace AlgorithmDesigns.PyramidalNumbers
{

    //Pyramidal Numbers
    // 1) Find out all the pyramidal numbers under n
    // 2) Store pyramidal numbers in HashSet and SortedList
    // 3) Create 2-sum-table with dictionary and store them in SortedList too.
    // 4) Foreach 1..n, 
    //      a) check pyramidal numbers.
    //      b) check 2-sum-table.
    //      c) subtract pyramidal numbers and see if they are in 2-sum-table.
    //      d) subtract 2-sum-table and check if it exists in 2-sum-table.
    public class PyramidalEvaluater
    {
        private int NoOfElements { get; }

        private const int minElement = 2;
        private HashSet<int> pyramidalNumbers = new HashSet<int>();
        private SortedSet<int> pyramidalNumbersSorted = new SortedSet<int>();

        private Dictionary<int, int[]> twoSumTable = new Dictionary<int, int[]>();
        private SortedDictionary<int, int[]> twoSumTableSorted = new SortedDictionary<int, int[]>();

        public PyramidalEvaluater(int n)
        {
            this.NoOfElements = n;
            this.GeneratePyramidalNumbers(n);
            this.GenerateTwoSumTable();
        }

        // BigOh(n Lg(n)) or BigOh (n) ??
        private void GenerateTwoSumTable()
        {
            // component1 of pyramid numbers
            foreach(var p1 in pyramidalNumbersSorted)
            {
                //bool p2ReachedP1 = false;

                // component2 of pyramid numbers
                foreach (var p2 in pyramidalNumbersSorted)
                {
                    if (p2 < p1)
                        continue;

                    var sum = p1 + p2;
                    if (sum > this.NoOfElements || twoSumTable.ContainsKey(sum))
                    {
                        break;
                    }

                    twoSumTable.Add(p1 + p2, new int[2] { p1, p2 });
                    twoSumTableSorted.Add(p1 + p2, new int[2] { p1, p2 });
                }
            }
        }

        private void GeneratePyramidalNumbers(int n)
        {
            int p = -1;

            for (int k = minElement; k <= n && p < n; k++)
            {
                // get pyramidal numbers.
                p = this.GetPyramidalNumber(k);

                // add to pyramidal numbers collections.
                pyramidalNumbers.Add(p);
                pyramidalNumbersSorted.Add(p);
            }
        }

        private int GetPyramidalNumber(int m)
        {
            return m >= 2 ? (int)(Math.Pow(m, 3) - m) / 6 : m;
        }

        public Dictionary<int, int[]> GetPyramidalSums()
        {
            Dictionary<int, int[]> pyramidalSums = new Dictionary<int, int[]>();
            int[] pyramidalComponents;

            for (int k = minElement; k <= this.NoOfElements; k++)
            {
                // k is itself a single pyramid number
                if(pyramidalNumbers.Contains(k))
                {
                    pyramidalSums[k] = new int[1] { k };
                }
                // k is sum of 2 pyramid numbers.
                else if(twoSumTable.ContainsKey(k))
                {
                    pyramidalSums[k] = twoSumTable[k];
                }
                // k is sum of 3 pyramid numbers.
                else if(IsSumOfThreePyramidals(k, out pyramidalComponents))
                {
                    pyramidalSums[k] = pyramidalComponents;
                }
                // k is sum of 4 pyramid numbers.
                else if (IsSumOfFourPyramidals(k, out pyramidalComponents))
                {
                    pyramidalSums[k] = pyramidalComponents;
                }
                // k is sum of 5 pyramid numbers.
                else if (IsSumOfFivePyramidals(k, out pyramidalComponents))
                {
                    pyramidalSums[k] = pyramidalComponents;
                }
                else
                {
                    Console.WriteLine($"Could not find pyramidal sums for {k}");
                }
            }

            return pyramidalSums;
        }


        private bool IsSumOfFourPyramidals(int k, out int[] fourPyramidals)
        {
            bool isSumOfFourPyramidals = false;
            fourPyramidals = null;

            // loop through twoSums to subtract and check if the result is another twoSum of pyramidals.
            foreach (var twoSum in twoSumTableSorted.Keys)
            {
                if (twoSum > k)
                {
                    break;
                }

                // subtract the 2-sum-of-pyramidals (p) from target number (k) that we need components for.
                int kLessTwoSum = k - twoSum;

                // check if it exists in 2-Sum-Table
                if ( twoSumTable.ContainsKey(kLessTwoSum))
                {
                    fourPyramidals = twoSumTable[kLessTwoSum].CombineArrays(twoSumTable[twoSum]);
                    isSumOfFourPyramidals = true;
                    break;
                }
            }

            return isSumOfFourPyramidals;
        }

        private bool IsSumOfThreePyramidals(int k, out int[] threePyramidals)
        {
            bool isSumOfThreePyramidals = false;
            threePyramidals = null;

            // loop through pyramidals to subtract and check if the result is a twoSum of pyramidals.
            foreach (var p in pyramidalNumbersSorted)
            {
                if(p > k)
                {
                    break;
                }

                // subtract the pyramidal (p) from target number (k) that we need components for.
                int kLessP = k - p;

                // check if it exists in 2-Sum-Table
                if (twoSumTable.ContainsKey(kLessP))
                {
                    threePyramidals = twoSumTable[kLessP].CombineArrays(new int[1] {p});
                    isSumOfThreePyramidals = true;
                    break;
                }
            }

            return isSumOfThreePyramidals;
        }

        private bool IsSumOfFivePyramidals(int k, out int[] fivePyramidals)
        {
            bool isSumOfFivePyramidals = false;
            fivePyramidals = null;

            // loop through pyramidals to subtract and check if the result is a twoSum of pyramidals.
            foreach (var p in pyramidalNumbersSorted)
            {
                if (p > k)
                {
                    break;
                }

                // subtract the pyramidal (p) from target number (k) that we need components for.
                int kLessP = k - p;

                // loop through twoSums to subtract and check if the result is another twoSum of pyramidals.
                foreach (var twoSum in twoSumTableSorted.Keys)
                {
                    if (twoSum > kLessP)
                    {
                        break;
                    }

                    // subtract the 2-sum-of-pyramidals (p) from target number (k) that we need components for.
                    int kLessPAndTwoSum = kLessP - twoSum;

                    // check if it exists in 2-Sum-Table
                    if (twoSumTable.ContainsKey(kLessPAndTwoSum))
                    {
                        fivePyramidals = twoSumTable[kLessPAndTwoSum].
                                                                     CombineArrays(twoSumTable[twoSum]).
                                                                     CombineArrays(new int[1] { p });
                        isSumOfFivePyramidals = true;
                        break;
                    }
                }

                if (isSumOfFivePyramidals)
                    break;
            }

            return isSumOfFivePyramidals;
        }
    }
}
