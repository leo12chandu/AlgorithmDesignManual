using System;
namespace AlgorithmDesigns.Chapter3.Exercise2
{
    public class ReverseLinkedList
    {
        //public static void Main()
        //{
        //    var list = Create(10);
        //    Console.WriteLine("Printing input list.");
        //    Print(list);
        //    var reversed = Reverse(list);
        //    Console.WriteLine("Printing reversed list.");
        //    Print(reversed);
        //}

        public static SinglyLinkedList Reverse(SinglyLinkedList linkedList)
        {
            SinglyLinkedList current = linkedList, prev = null, root = null;
            while(current != null)
            {
                // change the current to ref prev.
                var temp = current.Next;
                current.Next = prev;
                root = current;

                // assign next to current and current to prev
                prev = current;
                current = temp;
            }

            return root;
        }

        public static SinglyLinkedList Create(int noOfNodes = 10)
        {
            SinglyLinkedList list = new SinglyLinkedList(1);
            var current = list;

            for (int i = 1; i < noOfNodes; i++)
            {
                SinglyLinkedList next = new SinglyLinkedList(i+1);
                current.Next = next;

                current = next;
            }

            return list;
        }

        public static void Print(SinglyLinkedList list)
        {
            SinglyLinkedList current = list;
            while(current != null)
            {
                Console.Write(current.Value + "\t");
                current = current.Next;
            }
        }
    }
}
