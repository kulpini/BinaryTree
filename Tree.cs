using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Tree
    {
        public class TreeNode
        {
            public int value;
            public TreeNode leftTree;
            public TreeNode rightTree;
            public TreeNode(int i)
            {
                value = i;
            }
        }

        public TreeNode root;
        public void Add(int i)
        {
            TreeNode node = new TreeNode(i);
            if (root == null)
                root = node;
            else
            {
                AddNode(root, i);
            }
        }

        private void AddNode(TreeNode node,int i)
        {
            if (i == node.value)
            {
                Console.WriteLine($"Node \"{i}\" already exists");
                return;
            }
            else if (i < node.value)
            {
                if (node.leftTree == null)
                {
                    node.leftTree = new TreeNode(i);
                    return;
                }
                else
                {
                    node = node.leftTree;
                    AddNode(node, i);
                }
            }
            else
            {
                if (node.rightTree == null)
                {
                    node.rightTree = new TreeNode(i);
                    return;
                }
                else
                {
                    node = node.rightTree;
                    AddNode(node, i);
                }
            }
        }

        public TreeNode Find(int i)
        {
            return Search(root, i);
        }

        private TreeNode Search(TreeNode node,int i)
        {
            if (i == node.value)
                return node;
            else if (i < node.value)
            {
                if (node.leftTree == null)
                    return null;
                else
                {
                    node = node.leftTree;
                    return Search(node, i);
                }
            }
            else
            {
                if (node.rightTree == null)
                    return null;
                else
                {
                    node = node.rightTree;
                    return Search(node, i);
                }
            }
        }

        public void Delete(int i)
        {
            TreeNode node = Find(i);
            if (node == null)
                Console.WriteLine($"Node \"{i}\" not found");
            else
            {
                DeleteNode(node);
            }
        }

        private void DeleteNode(TreeNode node)
        {
            int i = node.value;
            TreeNode parent = FindParent(root, i);
            if ((node.leftTree == null) && (node.rightTree == null))   // a "leaf" deleting
            {
                if (i < parent.value)
                    parent.leftTree = null;
                else
                    parent.rightTree = null;
            }
            else if ((node.leftTree != null) && (node.rightTree != null))
                Console.WriteLine($"Node \"{i}\' cannot be deleted, because it has two subnodes");
            else
            {
                if (node.leftTree!=null)
                {
                    if (i < parent.value)
                    {
                        parent.leftTree = node.leftTree;
                        node.leftTree = null;
                    }
                    else
                    {
                        parent.rightTree = node.leftTree;
                        node.leftTree = null;
                    }
                }
                else
                {
                    if (i < parent.value)
                    {
                        parent.leftTree = node.rightTree;
                        node.rightTree = null;
                    }
                    else
                    {
                        parent.rightTree = node.rightTree;
                        node.rightTree = null;
                    }
                }
            }
        }

        private TreeNode FindParent(TreeNode node, int i)
        {
            if (i < node.value)
            {
                if (node.leftTree == Find(i))
                    return node;
                else
                    return FindParent(node.leftTree, i);
            }
            else
            {
                if (node.rightTree == Find(i))
                    return node;
                else
                    return FindParent(node.rightTree, i);
            }
        }

        public void PrintTree()
        {
            Console.Clear();
            Print(Console.WindowWidth / 2, 0, root);
        }

        public void Print(int x, int y, TreeNode node, int delta = 0)
        {
            if (node != null)
            {
                if (delta == 0) delta = x / 2;
                Console.SetCursorPosition(x, y);
                Console.Write(node.value);
                Print(x - delta, y + 3, node.leftTree, delta / 2);
                Print(x + delta, y + 3, node.rightTree, delta / 2);
            }

        }
    }
}
