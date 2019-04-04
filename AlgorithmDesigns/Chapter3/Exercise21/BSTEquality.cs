using System;
namespace AlgorithmDesigns.Chapter3.Exercise21
{
    /*
     * Write a function to compare whether two binary trees are identical. 
     * Identical trees have the same key value at each position and the same structure.
     */
    public class BSTEquality
    {
        public BSTEquality()
        {
        }

        public bool AreEqual<T>(BSTTree<T> bstTree1, BSTTree<T> bstTree2) where T:IComparable
        {
            bool areEqual = this.NodesAreEqual<T>(bstTree1, bstTree2) 
                                    && AreEqual(bstTree1.Left, bstTree2.Left)
                                    && AreEqual(bstTree1.Right, bstTree2.Right);

            return areEqual;
        }

        private bool NodesAreEqual<T>(BSTTree<T> bstTree1, BSTTree<T> bstTree2) where T:IComparable
        {
            return (bstTree1 == null && bstTree2 == null) ||
                (bstTree1 != null && bstTree2 != null && bstTree1.Value.Equals(bstTree2.Value));
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
}
