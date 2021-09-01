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
            root = new Node(value);
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
            if (value < node.Value)
            {
                if (node.left == null)
                    node.left = new Node(value);
                else
                    Add(node.left, value);
            }
            else
            {
                if (node.right == null)
                    node.right = new Node(value);
                else
                    Add(node.right, value);
            }
        }
        public void ViewTree()
        {
            Console.WriteLine("Tree View: ");
            Console.WriteLine("  Root: Node - {0}", root.Value);
            ViewTree(root);
        }
        protected virtual void ViewTree(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("  Left of '{0}': Node - {1}", node.Value, node.left.Value);
                ViewTree(node.left);
            }   
            if (node.right != null)
            {
                Console.WriteLine("  Right of '{0}': Node - {1}", node.Value, node.right.Value);
                ViewTree(node.right);
            }
        }
        public void RootNode()
        {
            Console.WriteLine("\nRoot and Node from the Tree: ");
            Console.WriteLine("  Root: {0}", root.Value);
            RootNode(root);
        }
        protected virtual void RootNode(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("  Node: {0}", node.left.Value);
                RootNode(node.left);
            }
            if (node.right != null)
            {
                Console.WriteLine("  Node: {0}", node.right.Value);
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
                    Console.WriteLine("  Leaf: {0}", node.left.Value);
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
                    Console.WriteLine("  Leaf: {0}", node.right.Value);
                }
                else
                {
                    NodeLeaf(node.right);
                }
            }
        }
        public void NodeDegree()
        {
            Console.WriteLine("\nNodes Degree: ");
            NodeDegree(root);
        }
        protected virtual void NodeDegree(Node node)
        {
            if (node.left == null && node.right == null)
            {
                Console.WriteLine("  Degree of node '{0}': {1}",node.Value, 0);
            }
            else if (node.left == null || node.right == null)
            {
                Console.WriteLine("  Degree of node '{0}': {1}", node.Value, 1);
                if (node.left != null)
                {
                    NodeDegree(node.left);
                }
                else
                {
                    NodeDegree(node.right);
                }
            }
            else
            {
                Console.WriteLine("  Degree of node '{0}': {1}", node.Value, 2);
                NodeDegree(node.left);
                NodeDegree(node.right);
            }
        }
        public void NodeHeight()
        {
            Console.WriteLine("\nNodes Height: ");
            Console.WriteLine("  Height of '{0}' is: {1}", root.Value, FindHeight(root, 0));
            NodeHeight(root);
        }
        protected virtual void NodeHeight(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("  Height of '{0}' is: {1}", node.left.Value, FindHeight(node.left, 0));
                NodeHeight(node.left);
            }
            if (node.right != null)
            {
                Console.WriteLine("  Height of '{0}' is: {1}", node.right.Value, FindHeight(node.right, 0));
                NodeHeight(node.right);
            }
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
        public void NodeDepth()
        {
            Console.WriteLine("\nNodes Depth: ");
            Console.WriteLine("  Depth of '{0}' is: {1}", root.Value, 0);
            NodeDepth(root);
        }
        protected virtual void NodeDepth(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("  Depth of '{0}' is: {1}", node.left.Value, FindDepth(root, node.left, 0, 0));
                NodeDepth(node.left);
            }
            if (node.right != null)
            {
                Console.WriteLine("  Depth of '{0}' is: {1}", node.right.Value, FindDepth(root, node.right, 0, 0));
                NodeDepth(node.right);
            }
        }
        private int FindDepth(Node nodeRoot, Node node, int oldOne, int verfFound)
        {
            int theMostOld = oldOne;
            if (nodeRoot.left != null)
            {
                theMostOld++;
                if (nodeRoot.left.Value == node.Value)
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
                if (nodeRoot.right.Value == node.Value)
                {
                    verfFound = 1;
                }
                else
                {
                    theMostOld = FindDepth(nodeRoot.right, node, theMostOld, verfFound);
                }
            }
            return theMostOld;
        }
    }
}
