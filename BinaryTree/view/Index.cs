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

            tree.ViewTree();

            Console.WriteLine("The degree is: {0}", tree.NodeDegree(5));
            Console.WriteLine("The height is: {0}", tree.NodeHeight(76));
            Console.WriteLine("The depth is: {0}", tree.NodeDepth(45));
            Console.WriteLine("The level is: {0}", tree.NodeLevel(45));

            tree.CheckValue(45);
            tree.CheckValue(22);

            tree.NodeRemove(76);

            tree.ViewTree();

            Console.WriteLine("In this tree has {0} nodes.", tree.NodeQuantity());
        }
    }
}
