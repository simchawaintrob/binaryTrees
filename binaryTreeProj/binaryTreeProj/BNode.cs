using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaryTreeProj
{
    public class BNode
    {
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

        public bool InLeftSide { get {return Parent.Left == this; } }
        public bool InRightSide { get { return Parent.Right == this; } }
        public override string ToString()
        {
            return this.Data.ToString();
        }
    }
}
