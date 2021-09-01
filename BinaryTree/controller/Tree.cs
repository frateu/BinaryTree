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
            Console.WriteLine("Root: " + root.Value);
            ViewTree(root);
        }
        protected virtual void ViewTree(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("\nLeft of " + node.Value + " : " + node.left.Value);
                ViewTree(node.left);
            }   
            if (node.right != null)
            {
                Console.WriteLine("\nRight of " + node.Value + " : " + node.right.Value);
                ViewTree(node.right);
            }
        }
        public void RootNode()
        {
            Console.WriteLine("\nRoot and Node from the Tree: ");
            Console.WriteLine("Root: " + root.Value);
            RootNode(root);
        }
        protected virtual void RootNode(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("Node: " + node.left.Value);
                ViewTree(node.left);
            }
            if (node.right != null)
            {
                Console.WriteLine("Node: " + node.right.Value);
                ViewTree(node.right);
            }
        }
        public void NodeLeaf()
        {
            Console.WriteLine("Leafs of the Tree: ");
            NodeLeaf(root);
        }
        protected virtual void NodeLeaf(Node node)
        {
            if (node.left != null)
            {
                if (node.left.left == null && node.left.right == null)
                {
                    Console.WriteLine("Leaf: " + node.left.Value);
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
                    Console.WriteLine("Leaf: " + node.right.Value);
                }
                else
                {
                    NodeLeaf(node.right);
                }
            }
        }
        public void NodeDegree()
        {
            Console.WriteLine("Node Degree: ");
            NodeDegree(root);
        }
        protected virtual void NodeDegree(Node node)
        {
            if (node.left == null && node.right == null)
            {
                Console.WriteLine("Degree of node {0}: {1}",node.Value, 0);
            }
            else if (node.left == null || node.right == null)
            {
                Console.WriteLine("Degree of node {0}: {1}", node.Value, 1);
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
                Console.WriteLine("Degree of node {0}: {1}", node.Value, 2);
                NodeDegree(node.left);
                NodeDegree(node.right);
            }
        }
    }
}
