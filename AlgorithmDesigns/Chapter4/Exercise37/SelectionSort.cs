using System;
using System.Collections.Generic;

namespace AlgorithmDesigns.Chapter4.Exercise37
{
    public class SelectionSort<T> : ISortingAlgo<T> where T : IComparable
    {
        public SelectionSort()
        {
        }

        public List<T> Sort(List<T> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                var smallestIndex = this.GetSmallestIndex(input, i);
                this.Swap(input, i, smallestIndex);
            }

            return input;
        }

        private int GetSmallestIndex(List<T> input, int currentIndex)
        {
            int smallestIndex = currentIndex;
            T smallestElement = input[currentIndex];

            for (int i = currentIndex + 1; i < input.Count; i++)
            {
                if(input[i].CompareTo(smallestElement) < 0)
                {
                    smallestIndex = i;
                    smallestElement = input[i];
                }
            }

            return smallestIndex;
        }

        private void Swap(List<T> input, int currentIndex, int smallestIndex)
        {
            T temp = input[smallestIndex];
            input[smallestIndex] = input[currentIndex];
            input[currentIndex] = temp;
        }
    }
}
