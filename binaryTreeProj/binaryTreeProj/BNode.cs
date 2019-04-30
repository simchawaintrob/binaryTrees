

namespace binaryTreeProj
{
    public class BNode
    {
        // -------------- properties -------------------
        public int Data { get; set; }
        public BNode Left { get; set; }
        public BNode Right { get; set; }
        public BNode Parent { get; set; }
        public bool IsLeaf
        {
            get
            {
                if (Left == null && Right == null)
                {

                return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasOnlyOneSone { get { return Left == null && Right != null || Right == null && Left != null; } }
        public bool InLeftSide { get { return Parent.Left != null ? Parent.Left == this : false; ; } }
        public bool InRightSide { get { return Parent.Right != null ? Parent.Right == this : false; } }
        public override string ToString()
        {
            return this.Data.ToString();
        }
      

        // -------------- functions -------------------
        internal bool RemoveChild(BNode nodeToDelete)
        {
            if (nodeToDelete.InLeftSide)
            {
                Left.Parent = null;
                Left = null;
                return true;
            }

            if (nodeToDelete.InRightSide)
            {
                Right.Parent = null;
                Right = null;
                return true;
            }
            return false;

        }
        internal BNode GetOneChild()
        {
            if (!HasOnlyOneSone)
            {
                return null;
            }
            return Left ?? Right;
        }
        internal void AddChild(BNode child, bool inLeftSide)
        {
            if (inLeftSide)
            {
                Left = child;
                child.Parent = this;
            }
            else
            {
                Right = child;
                child.Parent = this;
            }
        }
    }
}
