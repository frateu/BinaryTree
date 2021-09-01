using System;
using BinaryTree.controller;
using BinaryTree.model;

namespace BinaryTree
{
    class Index
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree(5);

            tree.Add(20);
            tree.Add(2);
            tree.Add(13);
            tree.Add(76);
            tree.Add(45);

            //tree.ViewTree();
            //tree.RootNode();
            //tree.NodeLeaf();
            tree.NodeDegree();
        }
    }
}
