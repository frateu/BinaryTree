using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree.model;

namespace BinaryTree.controller
{
    class Tree
    {
        private Node root;
        public Tree(int value)
        {
            root = new Node(value, null);
        }
        public void Add(int value)
        {
            Add(null, value);
        }
        protected virtual void Add(Node node, int value)
        {
            if (node == null)
            {
                node = root;
            }
            if (value < node.value)
            {
                if (node.left == null)
                    node.left = new Node(value, node);
                else
                {
                    Add(node.left, value);
                    node.left.father = node;
                }    
            }
            else
            {
                if (node.right == null)
                    node.right = new Node(value, node);
                else
                {
                    Add(node.right, value);
                    node.right.father = node;
                } 
            }
        }
        public void ViewTree()
        {
            Console.WriteLine("\nTree View: ");
            Console.WriteLine("  Root: Node - {0}", root.value);
            ViewTree(root);
        }
        protected virtual void ViewTree(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("  Left of '{0}': Node - {1}", node.value, node.left.value);
                ViewTree(node.left);
            }   
            if (node.right != null)
            {
                Console.WriteLine("  Right of '{0}': Node - {1}", node.value, node.right.value);
                ViewTree(node.right);
            }
        }
        public void RootNode()
        {
            Console.WriteLine("\nRoot and Node from the Tree: ");
            Console.WriteLine("  Root: {0}", root.value);
            RootNode(root);
        }
        protected virtual void RootNode(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("  Node: {0}", node.left.value);
                RootNode(node.left);
            }
            if (node.right != null)
            {
                Console.WriteLine("  Node: {0}", node.right.value);
                RootNode(node.right);
            }
        }
        public void NodeLeaf()
        {
            Console.WriteLine("\nLeafs of the Tree: ");
            NodeLeaf(root);
        }
        protected virtual void NodeLeaf(Node node)
        {
            if (node.left != null)
            {
                if (node.left.left == null && node.left.right == null)
                {
                    Console.WriteLine("  Leaf: {0}", node.left.value);
                }
                else
                {
                    NodeLeaf(node.left);
                }
            }
            if (node.right != null)
            {
                if (node.right.left == null && node.right.right == null)
                {
                    Console.WriteLine("  Leaf: {0}", node.right.value);
                }
                else
                {
                    NodeLeaf(node.right);
                }
            }
        }
        public int NodeDegree(int theNode)
        {
            return NodeDegree(root, 0, theNode);
        }
        protected virtual int NodeDegree(Node node, int degree, int theNode)
        {
            if (node.value == theNode)
            {
                if (node.left == null && node.right == null)
                {
                    degree = 0;
                }
                else if (node.left == null || node.right == null)
                {
                    degree = 1;
                }
                else
                {
                    degree = 2;
                }
            }
            else
            {
                if (node.left != null)
                {
                    degree = NodeDegree(node.left, degree, theNode);
                }
                if (node.right != null)
                {
                    degree = NodeDegree(node.right, degree, theNode);
                }
            }
            return degree;
        }
        public int NodeHeight(int theNode)
        {
            return NodeHeight(root, theNode, -1);
        }
        protected virtual int NodeHeight(Node node, int theNode, int height)
        {
            if (node.value == theNode)
            {
                height = FindHeight(node, 0);
            }
            else
            {
                if (node.left != null)
                {
                    height = NodeHeight(node.left, theNode, height);
                }
                if (node.right != null)
                {
                    height = NodeHeight(node.right, theNode, height);
                }
            }
            return height;
        }
        private int FindHeight(Node node, int theOne)
        {
            int bigLeft = 0;
            int bigRight = 0;
            int topHeight = theOne;
            if (node.left != null)
            {
                topHeight++;
                topHeight = FindHeight(node.left, topHeight);
                bigLeft = topHeight;
            }
            if (node.right != null)
            {
                topHeight = theOne;
                topHeight++;
                topHeight = FindHeight(node.right, topHeight);
                bigRight = topHeight;
            }

            if (bigLeft != 0 || bigRight != 0)
            {
                if (bigLeft > bigRight)
                {
                    topHeight = bigLeft;
                }
                else
                {
                    topHeight = bigRight;
                }
            }
            return topHeight;
        }
        public int NodeDepth(int theNode)
        {
            return NodeDepth(root, theNode, -1);
        }
        protected virtual int NodeDepth(Node node, int theNode, int depth)
        {
            if (node.value == theNode)
            {
                depth = FindDepth(root, node, 0, 0);
            }
            else
            {
                if (node.left != null)
                {
                    depth = NodeDepth(node.left, theNode, depth);
                }
                if (node.right != null)
                {
                    depth = NodeDepth(node.right, theNode, depth);
                }
            }
            return depth;
        }
        private int FindDepth(Node nodeRoot, Node node, int oldOne, int verfFound)
        {
            int theMostOld = oldOne;
            if (nodeRoot != node)
            {
                if (nodeRoot.left != null)
                {
                    theMostOld++;
                    if (nodeRoot.left.value == node.value)
                    {
                        verfFound = 1;
                    }
                    else
                    {
                        theMostOld = FindDepth(nodeRoot.left, node, theMostOld, verfFound);
                    }
                }
                if (nodeRoot.right != null && verfFound == 0)
                {
                    theMostOld = oldOne;
                    theMostOld++;
                    if (nodeRoot.right.value == node.value)
                    {
                        verfFound = 1;
                    }
                    else
                    {
                        theMostOld = FindDepth(nodeRoot.right, node, theMostOld, verfFound);
                    }
                }
            }
            return theMostOld;
        }
        public int NodeLevel(int theNode)
        {
            return NodeLevel(root, 0, theNode, 0);
        }
        protected virtual int NodeLevel(Node node, int theLevel, int theNode, int backupValue)
        {
            if (node.value == theNode)
            {
                backupValue = theLevel;
            }
            else
            {
                theLevel++;
                if (node.left != null)
                {
                    backupValue = NodeLevel(node.left, theLevel, theNode, backupValue);
                }
                if (node.right != null)
                {
                    backupValue = NodeLevel(node.right, theLevel, theNode, backupValue);
                }
            }
            return backupValue;
        }
        public void CheckValue(int SearchValue)
        {
            if (CheckValue(root, SearchValue, false))
            {
                Console.WriteLine("\nThere's '{0}' in the tree!", SearchValue);
            }
            else
            {
                Console.WriteLine("\nThere's no '{0}' in the tree!", SearchValue);
            }
        }
        protected virtual Boolean CheckValue(Node node, int searchValue, Boolean checker)
        {
            if (node.left != null)
            {
                if (node.left.value == searchValue)
                {
                    checker = true;
                }
                else
                {
                    checker = CheckValue(node.left, searchValue, checker);
                }
            }
            if (node.right != null)
            {
                if (node.right.value == searchValue)
                {
                    checker = true;
                }
                else
                {
                    checker = CheckValue(node.right, searchValue, checker);
                }
            }
            return checker;
        }
        public int NodeQuantity()
        {
            Console.WriteLine("\nNode Quantity: ");
            return NodeQuantity(root, 0) + 1;
        }
        protected virtual int NodeQuantity(Node node, int nodeQuantity)
        {
            if (node.left != null)
            {
                nodeQuantity++;
                nodeQuantity = NodeQuantity(node.left, nodeQuantity);
            }
            if (node.right != null)
            {
                nodeQuantity++;
                nodeQuantity = NodeQuantity(node.right, nodeQuantity);
            }
            return nodeQuantity;
        }
        public void NodeRemove(int theNode)
        {
            NodeRemove(root, theNode);
        }
        protected virtual void NodeRemove(Node node, int theNode)
        {
            if (node.value == theNode)
            {
                if (node.left != null && node.right != null)
                {
                    Node nodeCompar = new Node(0, null);
                    Node theBigger = ReturnBigger(node.left, nodeCompar);
                    if (theBigger.left == null && theBigger.right == null)
                    {
                        theBigger.father.right = null;
                    }
                    else if (theBigger.left == null || theBigger.right == null)
                    {
                        theBigger.left.father = theBigger.father;
                        if (theBigger.father.left == theBigger)
                        {
                            theBigger.father.left = theBigger.left;
                        }
                        else
                        {
                            theBigger.father.right = theBigger.left;
                        }
                    }
                    else
                    {
                        theBigger.left.father = theBigger.father.right;
                        theBigger.right.father = theBigger.left;
                    }

                    if (node.father.left.value == theNode)
                    {
                        node.father.left = theBigger;
                    }
                    else if (node.father.right.value == theNode)
                    {
                        node.father.right = theBigger;
                    }

                    theBigger.father = node.father;
                    theBigger.left = node.left;
                    theBigger.right = node.right;
                }
                else if (node.left != null || node.right != null)
                {
                    if (node.left != null)
                    {
                        node.left.father = node.father;
                        if (node.father.left.value == theNode)
                        {
                            node.father.left = node.left;
                        }
                        else if (node.father.right.value == theNode)
                        {
                            node.father.right = node.left;
                        }
                    }
                    else if (node.right != null)
                    {
                        node.right.father = node.father;
                        if (node.father.left.value == theNode)
                        {
                            node.father.left = node.right;
                        }
                        else if (node.father.right.value == theNode)
                        {
                            node.father.right = node.right;
                        }
                    }
                }
                else
                {
                    if (node.father.left.value == theNode)
                    {
                        node.father.left = null;
                    }
                    else if (node.father.right.value == theNode)
                    {
                        node.father.right = null;
                    }
                }
            }
            else
            {
                if (node.left != null)
                {
                    NodeRemove(node.left, theNode);
                }
                if (node.right != null)
                {
                    NodeRemove(node.right, theNode);
                }
            }
        }
        private Node ReturnBigger(Node node, Node theBigger)
        {
            if (node.value > theBigger.value)
            {
                theBigger = node;
            }
            if (node.left != null)
            {
                theBigger = ReturnBigger(node.left, theBigger);
            }
            if (node.right != null)
            {
                theBigger = ReturnBigger(node.right, theBigger);
            }
            return theBigger;
        }
    }
}
