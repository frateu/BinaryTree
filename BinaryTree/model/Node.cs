using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.model
{
    class Node
    {
        public Node(double value, Node Father)
        {
            Value = value;
            father = Father;
        }
        public Node father { get; set; }
        public Node right { get; set; }
        public Node left { get; set; }
        public double Value { get; set; }
    }
}
