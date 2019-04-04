using System;
using System.Linq;
using AlgorithmDesigns.Chapter3.Exercise2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesigns.Tests.Chapter3
{
    [TestClass]
    public class Exercise2Tests
    {
        [TestMethod]
        public void Exercise2TestReversing()
        {
            int noOfItems = 10;
            var list = ReverseLinkedList.Create(noOfItems);
            Console.WriteLine("Printing input list.");
            ReverseLinkedList.Print(list);
            var reversed = ReverseLinkedList.Reverse(list);
            Console.WriteLine("Printing reversed list.");
            ReverseLinkedList.Print(reversed);

            // get last value.
            int lastVal = GetLastVal(noOfItems, reversed);

            Assert.AreEqual(reversed.Value, noOfItems);
            Assert.AreEqual(reversed.Next.Value, noOfItems - 1);
            Assert.AreEqual(lastVal, 1);
        }

        private static int GetLastVal(int noOfItems, SinglyLinkedList reversed)
        {
            var lastVal = noOfItems;
            SinglyLinkedList current = reversed;
            while (current != null)
            {
                lastVal = current.Value;
                current = current.Next;
            }

            return lastVal;
        }
    }
}
