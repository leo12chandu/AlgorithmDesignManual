using System;
using System.Collections.Generic;

namespace AlgorithmDesigns.Chapter4.Exercise37
{
    public class QuickSort<T> : ISortingAlgo<T> where T : IComparable
    {
        public QuickSort()
        {
        }

        public List<T> Sort(List<T> input)
        {
            this.Sort(input, 0, input.Count - 1);

            return input;
        }

        private void Sort(List<T> input, int l, int h)
        {
            if (h - l > 0)
            {
                // partition
                int p = this.Partition(input, l, h);

                this.Sort(input, l, p - 1);
                this.Sort(input, p + 1, h);
            }
        }

        private int Partition(List<T> input, int l, int h)
        {
            int firstHigh = l;
            int p = h;
            T pValue = input[h];

            for (int i = l; i < h; i++)
            {
                if (input[i].CompareTo(pValue) < 0)
                {
                    this.Swap(input, i, firstHigh);
                    firstHigh++;
                }
            }

            this.Swap(input, firstHigh, h);
            p = firstHigh;

            return p;
        }

        //private int Partition1(List<T> input, int l, int h)
        //{
        //    int p = h, lowestHigh = -1;
        //    T pValue = input[h];

        //    for (int i = l; i < h; i++)
        //    {
        //        // current > pivot
        //        if (input[i].CompareTo(pValue) > 0)
        //        {
        //            if (lowestHigh == -1)
        //            {
        //                lowestHigh = i;
        //            }
        //        }
        //        // current < pivot
        //        else
        //        {
        //            if (lowestHigh != -1)
        //            {
        //                this.Swap(input, i, lowestHigh);

        //                if (input[lowestHigh + 1].CompareTo(pValue) > 0)
        //                {
        //                    lowestHigh++;
        //                }
        //                else
        //                {
        //                    lowestHigh = i;
        //                }
        //            }

        //        }
        //    }

        //    if (lowestHigh != -1)
        //    {
        //        this.Swap(input, lowestHigh, h);
        //        p = lowestHigh;
        //    }

        //    return p;
        //}


        private void Swap(List<T> input, int currentIndex, int smallestIndex)
        {
            T temp = input[smallestIndex];
            input[smallestIndex] = input[currentIndex];
            input[currentIndex] = temp;
        }
    }
}
