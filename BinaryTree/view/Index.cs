using System;
using BinaryTree.controller;
using BinaryTree.model;

namespace BinaryTree
{
    class Index
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree(27);
            tree.Add(13);
            tree.Add(48);
            tree.Add(5);
            tree.Add(25);
            tree.Add(2);
            tree.Add(8);
            tree.Add(32);
            tree.Add(40);
            tree.Add(57);
            tree.Add(50);
            tree.Add(77);

            tree.ViewTree();
            Console.WriteLine("In this tree has {0} nodes.", tree.NodeQuantity());

            Console.WriteLine("The degree is: {0}", tree.NodeDegree(25));
            Console.WriteLine("The height is: {0}", tree.NodeHeight(32));
            Console.WriteLine("The depth is: {0}", tree.NodeDepth(40));
            Console.WriteLine("The level is: {0}", tree.NodeLevel(8));

            tree.CheckValue(45);
            tree.CheckValue(32);

            tree.NodeRemove(13);

            tree.ViewTree();
        }
    }
}
