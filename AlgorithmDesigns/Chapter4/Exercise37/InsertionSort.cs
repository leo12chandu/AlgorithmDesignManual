using System;
using System.Collections.Generic;

namespace AlgorithmDesigns.Chapter4.Exercise37
{
    public class InsertionSort<T> : ISortingAlgo<T> where T : IComparable
    {
        public InsertionSort()
        {
        }

        public List<T> Sort(List<T> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                this.InsertInItsPosition(input, i);
            }

            return input;
        }

        private void InsertInItsPosition(List<T> input, int nextIndex)
        {
            int j = nextIndex;
            while(j> 0 && input[j].CompareTo(input[j-1]) < 0)
            {
                this.Swap(input, j - 1, j);
                j--;
            }
        }


        private void Swap(List<T> input, int currentIndex, int smallestIndex)
        {
            T temp = input[smallestIndex];
            input[smallestIndex] = input[currentIndex];
            input[currentIndex] = temp;
        }
    }
}
