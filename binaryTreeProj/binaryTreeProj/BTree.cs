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

        internal void fill(int key)
        {
            if (Root == null)
            {
                Root = new BNode { Data = key };
                return;
            }
            InsertData(Root,key);
        }

        internal void fill()
        {
            for (int i = 0; i < 10; i++)
            {
                if (Root == null)
                {
                    Root = new BNode { Data = i };
                    continue;
                }
                InsertData(Root, i);
            }
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
            var nodeToDelte = FindData(Root, data);
            if (nodeToDelte == null)
            {
                return false;
            }
            else
            {
                if (nodeToDelte.IsLeaf)
                {
                    var parent = nodeToDelte.Parent;
                    if (parent.Left == nodeToDelte)
                    {
                        
                        parent.Left = null;
                        return true;

                    }
                    if (parent.Right == nodeToDelte)
                    {
                        parent.Right = null;
                        return true;
                    }
                       
                }
                if (nodeToDelte.HasOnlyOneSone)
                {
                    if (nodeToDelte.Right != null)
                    {
                        if(nodeToDelte.InRightSide)
                        {
                            nodeToDelte.Parent.Right = nodeToDelte.Right;
                            nodeToDelte.Right.Parent = nodeToDelte.Parent;
                            return true;
                        }
                        if (nodeToDelte.InLeftSide)
                        {
                            nodeToDelte.Parent.Left = nodeToDelte.Right;
                            nodeToDelte.Right.Parent = nodeToDelte.Parent;
                            return true;
                        }

                    }

                    if (nodeToDelte.Left != null)
                    {
                        if (nodeToDelte.InRightSide)
                        {
                            nodeToDelte.Parent.Right = nodeToDelte.Left;
                            nodeToDelte.Left.Parent = nodeToDelte.Parent;
                            return true;
                        }
                        if (nodeToDelte.InLeftSide)
                        {
                            nodeToDelte.Parent.Left = nodeToDelte.Left;
                            nodeToDelte.Left.Parent = nodeToDelte.Parent;
                            return true;
                        }

                    }
                }
                else
                {
                    BNode nextNode = getNextNode(nodeToDelte);
                    nodeToDelte.Data = nextNode.Data;


                    if (nextNode.InRightSide)
                    {
                        nextNode.Parent.Right = null;
                    }
                    else
                    {
                        nextNode.Parent.Left = null;
                    }
                     
                    return true;
                }
                return false;
            }
        }

        private BNode getNextNode(BNode node)
        {
            BNode nextNode = node.Right;
            if (node.Right.IsLeaf)
            {
                return node.Right;
            }
            else
            {
                while (nextNode.Left != null)
                {
                    nextNode = nextNode.Left;
                    if (!nextNode.HasOnlyOneSone && ! nextNode.IsLeaf)
                    {
                        return null;
                    }
                }
                return nextNode;
            }
        }
       
    }

}
