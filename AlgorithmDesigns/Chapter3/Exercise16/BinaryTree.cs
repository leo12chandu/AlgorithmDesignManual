using System;
namespace AlgorithmDesigns.Chapter3.Exercise16
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTree(T value, BinaryTree<T> parent)
        {
            this.Value = value;
            this.Parent = parent;
        }

        public T Value
        {
            get;
            private set;
        }

        public BinaryTree<T> Parent
        {
            get;
            private set;
        }

        public BinaryTree<T> LeftTree
        {
            get;
            set;
        }

        public BinaryTree<T> RightTree
        {
            get;
            set;
        }

        public bool Contains(T key)
        {
            int comparisonResult = key.CompareTo(this.Value);

            // matches current node.
            if (comparisonResult == 0)
            {
                return true;
            }
            // search in right tree if key > current.
            else if (comparisonResult > 0 && this.RightTree != null)
            {
                return this.RightTree.Contains(key);
            }
            // search in left tree if key < current.
            else if(comparisonResult < 0 && this.LeftTree != null)
            {
                return this.LeftTree.Contains(key);
            }

            return false;
        }

        public virtual void Insert(T key)
        {
            int comparisonResult = key.CompareTo(this.Value);

            // matches current node.
            if (comparisonResult == 0)
            {
                // already inserted.
            }
            // search in right tree if key > current.
            else if (comparisonResult > 0)
            {
                if (this.RightTree == null)
                {
                    this.RightTree = this.CreateTree(key, this);
                }
                else
                {
                    this.RightTree.Insert(key);
                }
            }
            // search in left tree if key < current.
            else if (comparisonResult < 0)
            {
                if (this.LeftTree == null)
                {
                    this.LeftTree = this.CreateTree(key, this);
                }
                else
                {
                    this.LeftTree.Insert(key);
                }
            }
        }

        protected virtual BinaryTree<T> CreateTree(T key, BinaryTree<T> tree)
        {
            return new BinaryTree<T>(key, this);
        }
    }
}
