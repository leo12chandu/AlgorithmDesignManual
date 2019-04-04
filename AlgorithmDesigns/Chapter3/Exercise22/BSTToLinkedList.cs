using System;
using System.Collections.Generic;

namespace AlgorithmDesigns.Chapter3.Exercise22
{
    /*
     * Write a program to convert a binary search tree into a linked list.
     */
    public class BSTToLinkedList
    {

        public LinkedList<T> ConvertBSTToLinkedList<T>(BSTTree<T> tree) where T : IComparable
        {
            var currentList = new LinkedList<T>();
            this.ConvertBSTToLinkedList<T>(tree, currentList);

            return currentList;
        }

        private void ConvertBSTToLinkedList<T>(BSTTree<T> tree, LinkedList<T> linkList) where T : IComparable
        {
            if (tree != null)
            {
                ConvertBSTToLinkedList<T>(tree.Left, linkList);
                linkList.AddLast(tree.Value);
                ConvertBSTToLinkedList(tree.Right, linkList);
            }
        }
    }

    public class BSTTree<T> where T : IComparable
    {
        public T Value { get; private set; }

        public BSTTree<T> Left { get; set; }

        public BSTTree<T> Right
        {
            get;
            set;
        }
    }

    //public class SinglyLinkedList
    //{
    //    public int Value
    //    {
    //        get;
    //        set;
    //    }

    //    public SinglyLinkedList Next { get; set; }

    //    public SinglyLinkedList(int value)
    //    {
    //        this.Value = value;
    //    }
    //}
}
