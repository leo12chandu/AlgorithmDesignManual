using System;
namespace AlgorithmDesigns.Chapter3.Exercise16
{
    public class DictionaryLinkedList<T> : IDictionaryAlgo<T> where T:IComparable
    {
        public DictionaryLinkedList()
        {
        }

        private LinkedListItem<T> FirstItem
        {
            get;
            set;
        }

        private LinkedListItem<T> LastItem
        {
            get;
            set;
        }


        public bool ContainsKey(T key)
        {
            var currentItem = this.FirstItem;


            while (currentItem != null)
            {
                int comparisonResult = key.CompareTo(currentItem.Value);

                // matches current node.
                if (comparisonResult == 0)
                {
                    return true;
                }
                // search in right tree if key > current.
                else
                {
                    currentItem = currentItem.Next;
                }
            }

            return false;
        }

        public void Insert(T key)
        {
            if(this.FirstItem == null)
            {
                this.FirstItem = new LinkedListItem<T>(key, null);
                this.LastItem = this.FirstItem;
                return;
            }

            var currentItem = this.FirstItem;
            //var previousItem = currentItem;

            while (currentItem != null)
            {
                int comparisonResult = key.CompareTo(currentItem.Value);

                // matches current node.
                if (comparisonResult == 0)
                {
                    return;
                }
                // search in right tree if key > current.
                else
                {
                    //previousItem = currentItem;
                    currentItem = currentItem.Next;
                }
            }

            // did not find in the LL, so add it.
            var newItem = new LinkedListItem<T>(key, this.LastItem);
            this.LastItem = newItem;
        }
    }

    public class LinkedListItem<T>
    {
        public T Value { get; private set; }

        public LinkedListItem<T> Previous { get; set; }

        public LinkedListItem<T> Next { get; set; }

        public LinkedListItem(T value, LinkedListItem<T> previous)
        {
            this.Value = value;
            if (previous != null)
            {
                this.Previous = previous;
                this.Previous.Next = this;
            }
        }
    }
}
