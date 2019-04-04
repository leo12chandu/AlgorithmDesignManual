using System;
namespace AlgorithmDesigns.Chapter3.Exercise23
{
    public class ReverseLinkedList
    {
        public ReverseLinkedList()
        {
        }

        public SinglyLinkedList ReverseRecursively(SinglyLinkedList linkedList)
        {
            var current = linkedList;
            var next = linkedList.Next;
            var reverseList = this.ReverseRecursively(next);
            reverseList.Next = current;
            current.Next = null;

            return current;
        }

        public SinglyLinkedList ReverseIteratively(SinglyLinkedList linkedList)
        {
            var current = linkedList;
            SinglyLinkedList previous = null;
            while (current != null)
            {
                SinglyLinkedList newList = new SinglyLinkedList(current.Value);
                if(previous != null)
                {
                    newList.Next = previous;
                }

                current = current.Next;
                previous = newList;
            }

            return current;
        }
    }

    public class SinglyLinkedList
    {
        public int Value
        {
            get;
            set;
        }

        public SinglyLinkedList Next { get; set; }

        public SinglyLinkedList(int value)
        {
            this.Value = value;
        }
    }
}
