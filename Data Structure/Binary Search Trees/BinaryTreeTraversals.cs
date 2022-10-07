using System;
using System.Collections.Generic;


namespace A11
{
    public static class ExtensionMethods
    {
        public static T[][] ToJaggedArray<T>(this T[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex + 1;

            T[][] jaggedArray = new T[numberOfRows][];
            for (int i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (int j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }
            return jaggedArray;
        }
    }
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[][] array = new long[n][];
            for (int i = 0; i < n; i++)
            {
                string[] s = Console.ReadLine().Split();
                array[i] = new long[] { long.Parse(s[0]), long.Parse(s[1]), long.Parse(s[2]) }; 
            }
            long[][] ans = Solve(array);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(ans[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static long[][] Solve(long[][] array)
        {
            int n = array.GetLength(0);
            //Console.WriteLine(n);
            long[,] ans = new long[3, n];
            BinarySearchTreeNode<long>[] nodes = createBST(array);
            long[] inorder = inOrder(nodes);
            //        Console.WriteLine("RR");
            long[] postorder = PostOrder(nodes);
            //          Console.WriteLine("FF");
            long[] preorder = PreOrder(nodes);
            //Console.WriteLine("BB");
            for (int i = 0; i < n; i++)
            {
                //   Console.WriteLine(inorder[i]);
                ans[0, i] = inorder[i];
            }
            for (int i = 0; i < n; i++)
            {
                ans[1, i] = preorder[i];
                // Console.WriteLine("bye");
            }
            for (int i = 0; i < n; i++)
            {
                ans[2, i] = postorder[i];
                //Console.WriteLine("pis");
            }
            //Console.WriteLine("AA");
            return ans.ToJaggedArray();

        }
        public static void Print(long[][] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static long[][] Solve1(long[][] array)
        {
            int n = array.GetLength(0);
            //Console.WriteLine(n);
            long[][] ans = new long[3][];
            BinarySearchTreeNode<long>[] nodes = createBST(array);
            long[] inorder = inOrder(nodes);
            //        Console.WriteLine("RR");
            long[] postorder = PostOrder(nodes);
            //          Console.WriteLine("FF");
            long[] preorder = PreOrder(nodes);
            Console.WriteLine("BB");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(inorder[i]);
                ans[0][i] = inorder[i];
            }
            for (int i = 0; i < n; i++)
            {
                ans[1][i] = preorder[i];
                Console.WriteLine("bye");
            }
            for (int i = 0; i < n; i++)
            {
                ans[2][i] = postorder[i];
                Console.WriteLine("pis");
            }
            Console.WriteLine("AA");
            return ans;
        }
        public static long[] inOrder(BinarySearchTreeNode<long>[] nodes)
        {
            //            nodes.ToList().ForEach(x => Console.Write(x.key + " "));
            if (nodes.Length == 0) return null;
            List<long> ans = new List<long>();
            Stack<BinarySearchTreeNode<long>> s = new Stack<BinarySearchTreeNode<long>>();
            BinarySearchTreeNode<long> current = nodes[0];
            while (current != null || s.Count > 0)
            {
                while (current != null)
                {
                    s.Push(current);
                    current = current.left;
                }
                current = s.Pop();
                ans.Add(current.key);
                current = current.right;
            }
            return ans.ToArray();
        }
        public static long[] PostOrder(BinarySearchTreeNode<long>[] nodes)
        {
            List<long> ans = new List<long>();
            Stack<BinarySearchTreeNode<long>> s1 = new Stack<BinarySearchTreeNode<long>>();
            Stack<BinarySearchTreeNode<long>> s2 = new Stack<BinarySearchTreeNode<long>>();
            if (nodes[0] == null) return null;
            s1.Push(nodes[0]);
            while (s1.Count > 0)
            {
                BinarySearchTreeNode<long> tmp = s1.Pop();
                s2.Push(tmp);
                if (tmp.left != null) s1.Push(tmp.left);
                if (tmp.right != null) s1.Push(tmp.right);
            }
            while (s2.Count > 0)
            {
                ans.Add(s2.Pop().key);
            }
            return ans.ToArray();
        }
        public static long[] PreOrder(BinarySearchTreeNode<long>[] nodes)
        {
            if (nodes[0] == null) return null;
            List<long> ans = new List<long>();
            Stack<BinarySearchTreeNode<long>> s1 = new Stack<BinarySearchTreeNode<long>>();
            s1.Push(nodes[0]);
            while (s1.Count > 0)
            {
                BinarySearchTreeNode<long> node = s1.Peek();
                ans.Add(node.key);
                s1.Pop();
                if (node.right != null)
                {
                    s1.Push(node.right);
                }
                if (node.left != null)
                {
                    s1.Push(node.left);
                }
            }
            return ans.ToArray();
        }
        public static BinarySearchTreeNode<long>[] createBST(long[][] array)
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
            return nodes;
        }
    }
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
}

