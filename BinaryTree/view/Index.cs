using System;
using BinaryTree.controller;

namespace BinaryTree
{
    class Index
    {
        static void Main(string[] args)
        {
            int verfChos = -1;
            Console.Write("Insert the Root of the Binary Tree: ");
            int root = Convert.ToInt32(Console.ReadLine());
            Tree tree = new Tree(root);
            do
            {
                Console.WriteLine("\n---Binary Tree---" +
                                    "\n\nOptions:" +
                                    "\n1 - Add a Node" +
                                    "\n2 - Node Degree" +
                                    "\n3 - Node Height" +
                                    "\n4 - Node Depth" +
                                    "\n5 - Node Level" +
                                    "\n6 - Check Node" +
                                    "\n7 - Remove Node" +
                                    "\n8 - View Tree" +
                                    "\n9 - Nodes Quantity" +
                                    "\n10 - Invert the Tree" +
                                    "\n11 - All Paths" +
                                    "\n0 - Exit");
                Console.Write("Number: ");
                verfChos = Convert.ToInt32(Console.ReadLine());
                switch (verfChos) 
                {
                    case 1:
                        Console.Write("Insert the Node: ");
                        int node = Convert.ToInt32(Console.ReadLine());
                        tree.Add(node);
                        break;
                    case 2:
                        Console.Write("Insert the Node: ");
                        int nodeDegree = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("The degree is: {0}", tree.NodeDegree(nodeDegree));
                        break;
                    case 3:
                        Console.Write("Insert the Node: ");
                        int nodeHeight = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("The height is: {0}", tree.NodeHeight(nodeHeight));
                        break;
                    case 4:
                        Console.Write("Insert the Node: ");
                        int nodeDepht = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("The depth is: {0}", tree.NodeDepth(nodeDepht));
                        break;
                    case 5:
                        Console.Write("Insert the Node: ");
                        int nodeLevel = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("The level is: {0}", tree.NodeLevel(nodeLevel));
                        break;
                    case 6:
                        Console.Write("Insert the Node: ");
                        int nodeCheck = Convert.ToInt32(Console.ReadLine());
                        tree.CheckValue(nodeCheck);
                        break;
                    case 7:
                        Console.Write("Insert the Node: ");
                        int nodeRemove = Convert.ToInt32(Console.ReadLine());
                        tree.NodeRemove(nodeRemove);
                        break;
                    case 8:
                        tree.ViewTree();
                        break;
                    case 9:
                        tree.NodeQuantity();
                        break;
                    case 10:
                        tree.InvertTree();
                        break;
                    case 11:
                        tree.AllPaths();
                        break;
                }
            } while (verfChos != 0);
        }
    }
}
