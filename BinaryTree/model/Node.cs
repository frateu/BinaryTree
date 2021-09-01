using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.model
{
    class Node
    {
        public Node(double value)
        {
            Value = value;
        }
        public Node right { get; set; }
        public Node left { get; set; }
        public double Value { get; set; }
    }
}
