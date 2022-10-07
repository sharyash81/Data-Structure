using System;
using System.Collections.Generic;
using System.Linq;
namespace A11
{
    public class BinarySearchTreeNode<T>
    {
        public BinarySearchTreeNode<T> parent;
        public T key;
        public BinarySearchTreeNode<T> left;
        public BinarySearchTreeNode<T> right;
        //public BinarySearchTreeNode<T> parent;
        //public int level;
        public BinarySearchTreeNode()
        {
        }

        public BinarySearchTreeNode(T key)
        {
            this.key = key;
        }
    }
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0 ) Console.WriteLine("CORRECT");
            else
            {
                long[][] array = new long[n][];
                for (int i = 0; i < n; i++)
                {
                    string[] s = Console.ReadLine().Split();
                    array[i] = new long[] { long.Parse(s[0]), long.Parse(s[1]), long.Parse(s[2]) }; 
                }
                if (Solve(array))
                {
                    Console.WriteLine("CORRECT");
                }
                else Console.WriteLine("INCORRECT");
            }
        }

        public static bool Solve(long [][] array)
        {
            int n = array.GetLength(0);
            BinarySearchTreeNode<long>[] nodes = new BinarySearchTreeNode<long>[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new BinarySearchTreeNode<long>(array[i][0]);
            }
            for (int i = 0; i < n; i++)
            {
                if (array[i][1] == -1)
                {
                    nodes[i].left = null;
                }
                else
                {
                    nodes[i].left = nodes[array[i][1]];
                }
                if (array[i][2] == -1)
                {
                    nodes[i].right = null;
                }
                else
                {
                    nodes[i].right = nodes[array[i][2]];
                }
            }
            BinarySearchTreeNode<long> root = nodes[0];
            return checker(root,int.MinValue,int.MaxValue);
        }         
        public static bool checker(BinarySearchTreeNode<long> node , long min ,long max)
        {
            if (node.key < min || node.key > max) return false;
            if (node.right!=null && node.left!=null) return (checker(node.left,min,node.key - 1) && checker(node.right,node.key,max));
            if (node.left!=null) return checker(node.left,min,node.key -1);
            if (node.right!=null) return checker(node.right,node.key,max);
            return true;
        }
    }
}
