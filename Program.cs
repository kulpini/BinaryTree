using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree binaryTree = new Tree();
            binaryTree.Add(12);
            binaryTree.Add(7);
            binaryTree.Add(18);
            binaryTree.Add(15);
            binaryTree.Add(9);
            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.PrintTree();
            Console.ReadKey();
            binaryTree.Delete(18);
            binaryTree.PrintTree();
            Console.ReadKey();
        }
    }
}
