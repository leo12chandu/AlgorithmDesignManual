using System;
namespace AlgorithmDesigns.Chapter3.Exercise16
{
    public class AVLTree<T> : BinaryTree<T> where T: IComparable
    {
        public int BalanceFactor
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        private AVLTree<T> LeftAVLTree 
        {
            get
            {
                return ((AVLTree<T>)this.LeftTree);
            }
        }

        private AVLTree<T> RightAVLTree
        {
            get
            {
                return ((AVLTree<T>)this.RightTree);
            }
        }

        public AVLTree(T value, BinaryTree<T> parent) : base(value, parent)
        {
            this.Height = 0;
        }

        public override void Insert(T key)
        {
            base.Insert(key);

            this.Height = this.GetHeight();
            this.BalanceFactor = this.GetBalanceFactor();

            // If AVL balancefactor > 1, fix it.
            if(Math.Abs(this.BalanceFactor) > 1)
            {
                this.Fix();
            }
        }

        protected override BinaryTree<T> CreateTree(T key, BinaryTree<T> tree)
        {
            return new AVLTree<T>(key, this);
        }

        private int GetHeight()
        {
            var lHeight = this.LeftTree != null ? ((AVLTree<T>)this.LeftTree).Height : -1;
            var rHeight = this.RightTree != null ? ((AVLTree<T>)this.RightTree).Height : -1;

            var height = Math.Max(lHeight, rHeight) + 1;

            return height;
        }

        private int GetBalanceFactor()
        {
            var lHeight = this.LeftTree != null ? this.LeftAVLTree.Height : -1;
            var rHeight = this.RightTree != null ? this.RightAVLTree.Height : -1;

            //var balanceFactor = Math.Abs(rHeight - lHeight);
            var balanceFactor = rHeight - lHeight;

            return balanceFactor;
        }

        public void Fix()
        {
            //if(this.BalanceFactor < -1)
            //{
            //    if(this.LeftAVLTree.BalanceFactor < 0)
            //    {
            //        this.LeftAVLTree.RightTree
            //    }
            //}

        }
    }
}
