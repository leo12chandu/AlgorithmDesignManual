using System;
namespace AlgorithmDesigns.Chapter3.Exercise2
{
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
