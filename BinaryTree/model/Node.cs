using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.model
{
    class Node
    {
        public Node(int Value, Node Father)
        {
            value = Value;
            father = Father;
        }
        public Node father { get; set; }
        public Node right { get; set; }
        public Node left { get; set; }
        public int value { get; set; }
    }
}
