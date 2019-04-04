using System;
using System.Collections.Generic;

namespace AlgorithmDesigns.Chapter4.Exercise37
{
    public class MergeSort<T> : ISortingAlgo<T> where T : IComparable
    {
        public MergeSort()
        {
        }

        public List<T> Sort(List<T> input)
        {
            return this.DivideAndConquer(input, 0, input.Count - 1);
        }

        private List<T> DivideAndConquer(List<T> input, int startIndex, int endIndex)
        {
            int numOfElements = endIndex - startIndex + 1;

            if(numOfElements <= 1)
            {
                return new List<T>() { input[startIndex] };
            }

            int middleIndex = startIndex + (int)Math.Floor((double)((numOfElements) / 2)) - 1;

            var leftInput = this.DivideAndConquer(input, startIndex, middleIndex);
            var rightInput = this.DivideAndConquer(input, middleIndex + 1, endIndex);
            var mergedList = this.Merge(leftInput, rightInput);

            return mergedList;
        }

        private List<T> Merge(List<T> leftInput, List<T> rightInput)
        {
            List<T> mergedList = new List<T>();
            int leftIndex = 0, rightIndex = 0;
            int numOfElements = leftInput.Count + rightInput.Count;

            // merge left and right arrays into mergedList
            while((leftIndex < leftInput.Count) &&
                  (rightIndex < rightInput.Count))
            {
                if(leftInput[leftIndex].CompareTo(rightInput[rightIndex]) <= 0)
                {
                    mergedList.Add(leftInput[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    mergedList.Add(rightInput[rightIndex]);
                    rightIndex++;
                }
            }

            // put remaining in left back into mergedList
            if (leftIndex < leftInput.Count)
            {
                for (int i = leftIndex; i < leftInput.Count; i++)
                {
                    mergedList.Add(leftInput[i]);
                }
            }

            // put remaining in right back into mergedList
            if (rightIndex < rightInput.Count)
            {
                for (int i = rightIndex; i < rightInput.Count; i++)
                {
                    mergedList.Add(rightInput[i]);
                }
            }

            return mergedList;
        }
    }
}
