using System;
namespace AlgorithmDesigns.Chapter3.Exercise16
{
    public class DictionaryBST<T> : IDictionaryAlgo<T> where T : IComparable
    {
        public BinaryTree<T> BinaryTree
        {
            get;
            set;
        }

        public DictionaryBST()
        {
        }

        public bool ContainsKey(T key)
        {
            if (this.BinaryTree == null)
                return false;
            else 
            {
                return this.BinaryTree.Contains(key);
            }
        }

        public void Insert(T key)
        {
            if (this.BinaryTree == null)
            {
                this.BinaryTree = new BinaryTree<T>(key, null);
            }
            else
            {
                this.BinaryTree.Insert(key);
            }
        }
    }
}
