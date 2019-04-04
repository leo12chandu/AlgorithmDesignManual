using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmDesigns.Chapter4.Exercise37
{
    public class HeapSort<T> : ISortingAlgo<T> where T:IComparable
    {
        public HeapSort()
        {
        }

        public List<T> Sort(List<T> input)
        {
            List<T> heap = new List<T>();

            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < input.Count; i++)
            {
                heap.Add(input[i]);
                this.BubbleUp(heap);
            }

            watch.Stop();
            var heapinsertionTime = watch.ElapsedMilliseconds;

            watch.Reset();
            watch.Start();
            var output = this.GetSortedElements(heap);
            watch.Stop();
            var heapGetMinTime = watch.ElapsedMilliseconds;

            return output;
        }

        private void BubbleUp(List<T> output)
        {
            if(output.Count <= 1)
            {
                return;
            }

            int currentIndex = output.Count - 1;
            int parentIndex = this.Parent(currentIndex);
            while (output[currentIndex].CompareTo(output[parentIndex]) < 0)
            {
                this.Swap(output, currentIndex, parentIndex);

                if (parentIndex <= 0)
                    break;

                currentIndex = parentIndex;
                parentIndex = this.Parent(currentIndex);
            }
        }

        private List<T> GetSortedElements(List<T> input)
        {
            List<T> output = new List<T>();

            while (input.Count > 0)
            {
                output.Add(input[0]);

                // move last element to the top.
                int lastIndex = input.Count - 1;
                input[0] = input[lastIndex];
                input.RemoveAt(lastIndex);

                this.BubbleDown(input, 0);
            }


            return output;
        }

        private void BubbleDown(List<T> input, int index)
        {
            int youngChild = this.GetChildIndex(index);

            if(youngChild < input.Count)
            {
                int smallestChild = youngChild;

                // older child is the smaller one.
                if(youngChild + 1 < input.Count && input[youngChild + 1].CompareTo(input[youngChild]) < 0)
                {
                    smallestChild = youngChild + 1;
                }

                // compare with smallest child
                if (input[index].CompareTo(input[smallestChild]) > 0)
                {
                    this.Swap(input, index, smallestChild);
                    this.BubbleDown(input, smallestChild);
                }
            }

            //// compare with left child
            //if (youngChild < input.Count && input[index].CompareTo(input[youngChild]) > 0)
            //{
            //    this.Swap(input, index, youngChild);
            //    this.BubbleDown(input, youngChild);
            //}

            //// compare with right child
            //if (youngChild + 1 < input.Count && input[index].CompareTo(input[youngChild + 1]) > 0)
            //{
            //    this.Swap(input, index, youngChild + 1);
            //    this.BubbleDown(input, youngChild + 1);
            //}
        }

        private List<T> GetSortedElements2(List<T> input)
        {
            T[] output = new T[input.Count];
            int lastIndex = input.Count - 1;
            int lastIndexOutput = 0;

            while (lastIndex > 0)
            {
                output[lastIndexOutput++] = input[0];

                // move last element to the top.
                input[0] = input[lastIndex--];
                //input.RemoveAt(lastIndex);

                this.BubbleDown2(input, 0, lastIndex);
            }


            return output.ToList<T>();
        }

        private void BubbleDown2(List<T> input, int index, int lastIndex)
        {
            int youngChild = this.GetChildIndex(index);

            // compare with left child
            if (youngChild <=lastIndex && input[index].CompareTo(input[youngChild]) > 0)
            {
                this.Swap(input, index, youngChild);
                this.BubbleDown2(input, youngChild, lastIndex);
            }

            // compare with right child
            if (youngChild + 1 <= lastIndex + 1 && input[index].CompareTo(input[youngChild + 1]) > 0)
            {
                this.Swap(input, index, youngChild + 1);
                this.BubbleDown2(input, youngChild + 1, lastIndex);
            }
        }


        private void Swap(List<T> input, int currentIndex, int smallestIndex)
        {
            T temp = input[smallestIndex];
            input[smallestIndex] = input[currentIndex];
            input[currentIndex] = temp;
        }

        private int Parent(int currentIndex)
        {
            return (int)Math.Floor((double)(currentIndex + 1) / 2) - 1;
        }

        private int GetChildIndex(int parent)
        {
            return 2 * parent + 1;
        }
    }
}
