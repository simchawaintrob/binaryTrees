using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaryTreeProj
{
    class BTree
    {
        public BNode Root { get; set; }

        public bool InsertData(BNode root, int data)
        {
            
            if (FindData(root, data) != null)
                return false;

            if (data < root.Data)
                if(root.Left != null)
                    return InsertData(root.Left, data);
                else
                {
                    root.Left = new BNode { Data = data, Parent = root };
                    return true;

                }

            if (data > root.Data)
                if (root.Right != null)
                    return InsertData(root.Right, data);
                else
                {
                    root.Right = new BNode { Data = data, Parent = root };
    
                    return true;
                }

            return false;

        }

        BNode FindData(BNode root, int data)
        {
            if (root == null)
                return null;

            if (root.Data == data)
                return root;

            if (data < root.Data)
                return FindData(root.Left, data);

            if (data > root.Data)
                return FindData(root.Right, data);

            return null;
        }

        internal bool DeleteData(int data)
        {
            var nodeToDelete = FindData(Root, data);
            if (nodeToDelete == null)
            {
                return false;
            }
            if (nodeToDelete.IsLeaf)
            {
                DeleteIsLeaf(nodeToDelete);
                return true;
            }
            if (nodeToDelete.HasOnlyOneSone)
            {
                DeleteHasOneSon(nodeToDelete);
                return true;

            }
            else
            {
                var nextNode = getNextNode(nodeToDelete);
                var oldData = nodeToDelete.Data;
                nodeToDelete.Data = nextNode.Data;
                nextNode.Data = oldData;
                if (nodeToDelete.Right == nextNode)
                {
                    if (nextNode.IsLeaf)
                    {
                        DeleteIsLeaf(nodeToDelete);
                    }
                    else
                    {
                        DeleteHasOneSon(nextNode);
                    }
                }
                else
                {

                nextNode.Parent.RemoveChild(nextNode);
                }

                return true;
                
            }

        }

        private void DeleteIsLeaf(BNode nodeToDelete)
        {
            nodeToDelete.RemoveChild(nodeToDelete);
        }

        private BNode getNextNode(BNode node)
        {
            BNode nextNode = node.Right;
            while (nextNode.Left != null)
            {
                nextNode = nextNode.Left;
            }

            // is always leaf
            return nextNode;
        }

        internal void Fill(int key)
        {
            if (Root == null)
            {
                Root = new BNode { Data = key };
                return;
            }
            InsertData(Root,key);
        }

        internal void FillDemo()
        {
            Fill(5);
            Fill(8);
            Fill(10);
            Fill(7);
            Fill(20);
            Fill(0);
            Fill(3);
            Fill(50);
            Fill(15);
        }
        
        private void DeleteHasOneSon(BNode nodeToDelete)
        {
            if (nodeToDelete.HasOnlyOneSone)
            {
                var child = nodeToDelete.GetOneChild();
                var parent = nodeToDelete.Parent;

                var inLeftSide = nodeToDelete.InLeftSide;
                parent.RemoveChild(nodeToDelete);
                parent.AddChild(child, inLeftSide);
            }
            
        }

       
    }

}
