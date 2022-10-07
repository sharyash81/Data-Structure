using System;
using System.Collections.Generic;

namespace A11
{
    public class Node
    {
        public long Key;
        public long Sum;
        public Node Left;
        public Node Right;
        public Node Parent;
        public Node(Node left, Node right, Node parent, long key, long sum)
        {
            this.Key = key;
            this.Sum = sum;
            this.Right = right;
            this.Left = left;
            this.Parent = parent;
        }
    }
    public class Program
    {
        public static readonly Dictionary<char, Func<string, string>> CommandDict = new Dictionary<char, Func<string, string>>
        {
            ['+'] = Add,
            ['-'] = Del,
            ['?'] = Find,
            ['s'] = Sum
        };

        public static long M = 1000000001;

        public static long X = 0;
        public static Node root = null;

        protected static List<long> Data;

        public static Node Find(ref Node root, long key)
        {
            Node node = root;
            Node last = root;
            Node next = null;
            while (node != null)
            {
                if (node.Key >= key && (next == null || node.Key < next.Key)) next = node;
                last = node;
                if (node.Key == key) break;
                if (node.Key < key) node = node.Right;
                else node = node.Left;
            }
            Splay(last, ref root);
            return next;
        }
        public static void Split(Node root, long key, ref Node left, ref Node right)
        {
            right = Find(ref root, key);
            Splay(right, ref root);
            if (right == null)
            {
                left = root;
                return;
            }
            left = right.Left;
            right.Left = null;
            if (left != null) left.Parent = null;
            Update(left);
            Update(right);
        }
        public static Node Merge(Node left, Node right)
        {
            if (left == null) return right;
            if (right == null) return left;
            Node min_right = right;
            while (min_right.Left != null)
            {
                min_right = min_right.Left;
            }
            Splay(min_right, ref right);
            right.Left = left;
            Update(right);
            return right;
        }
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] s = new string[n];
            for (int i = 0; i < n; i++)
            {
                s[i] = Console.ReadLine();
            }
            string[] ans = Solve(s);
            for (int i = 0; i < ans.Length; i++)
            {
                Console.WriteLine(ans[i]);
            }
        }
        public static string[] Solve(string[] lines)
        {
            X = 0;
            root = null;
            Data = new List<long>();
            List<string> result = new List<string>();
            foreach (var line in lines)
            {
                char cmd = line[0];
                string args = line.Substring(1).Trim();
                var output = CommandDict[cmd](args);
                if (cmd == 's') X = long.Parse(output) % M;
                if (null != output)
                    result.Add(output);
            }
            return result.ToArray();
        }

        private static long Convert(long i)
            => i = (i + X) % M;

        private static string Add(string arg)
        {
            long x = Convert(long.Parse(arg));
            Node left = null;
            Node right = null;
            Node newNode = null;
            Split(root, x, ref left, ref right);
            if (right == null || right.Key != x) newNode = new Node(null, null, null, x, x);
            Node newnode = Merge(left, newNode);
            root = Merge(newnode, right);
            return null;
        }

        private static string Del(string arg)
        {
            long x = Convert(long.Parse(arg));
            if (!Find(x) || root == null) return null;
            Node left = null;
            Node middle = null;
            Node right = null;
            Split(root, x, ref left, ref middle);
            Split(middle, x + 1, ref middle, ref right);
            if (middle == null || middle.Key != x)
            {
                Node newnode = Merge(left, middle);
                root = Merge(newnode, right);
            }
            else
            {
                middle = null;
                root = Merge(left, right);
            }
            return null;
        }
        public static string Find(string arg)
        {
            long x = Convert(int.Parse(arg));
            Node left = null;
            Node right = null;
            Split(root, x, ref left, ref right);
            if (right == null || right.Key != x)
            {
                root = Merge(left, right);
                return "Not found";
            }
            else
            {
                root = Merge(left, right);
                return "Found";
            }
        }
        public static bool Find(long x)
        {
            Node left = null;
            Node right = null;
            Split(root, x, ref left, ref right);
            if (right == null || right.Key != x)
            {
                root = Merge(left, right);
                return false;
            }
            else
            {
                root = Merge(left, right);
                return true;
            }
        }

        private static string Sum(string arg)
        {
            var toks = arg.Split();
            long from = Convert(long.Parse(toks[0]));
            long to = Convert(long.Parse(toks[1]));
            Node left = null;
            Node middle = null;
            Node right = null;
            Split(root, from, ref left, ref middle);
            Split(middle, to + 1, ref middle, ref right);
            long ans = 0;
            if (middle != null) ans = middle.Sum;
            root = Merge(left, Merge(middle, right));
            return ans.ToString();
        }
        public static void Update(Node node)
        {
            if (node == null) return;
            node.Sum = node.Key;
            if (node.Left != null) node.Sum += node.Left.Sum;
            if (node.Right != null) node.Sum += node.Right.Sum;
            if (node.Left != null) node.Left.Parent = node;
            if (node.Right != null) node.Right.Parent = node;
        }
        public static void SmallRotation(Node node)
        {
            Node parent = node.Parent;
            Node grandparent = node.Parent.Parent;
            if (parent == null) return;
            if (parent.Left == node)
            {
                Node tmp = node.Right;
                node.Right = parent;
                parent.Left = tmp;
            }
            else
            {
                Node tmp = node.Left;
                node.Left = parent;
                parent.Right = tmp;
            }
            Update(parent);
            Update(node);
            node.Parent = grandparent;
            if (grandparent != null)
            {
                if (grandparent.Left == parent) grandparent.Left = node;
                else grandparent.Right = node;
            }
        }
        public static void BigRotation(Node node)
        {
            if (node.Parent.Left == node && node.Parent.Parent.Left == node.Parent)
            {
                SmallRotation(node.Parent);
                SmallRotation(node);
            }
            else if (node.Parent.Right == node && node.Parent.Parent.Right == node.Parent)
            {
                SmallRotation(node.Parent);
                SmallRotation(node);
            }
            else
            {
                SmallRotation(node);
                SmallRotation(node);
            }
        }
        public static void Splay(Node node, ref Node root)
        {
            if (node == null || node.Parent == null) return;
            while (node.Parent != null)
            {
                if (node.Parent.Parent == null)
                {
                    SmallRotation(node);
                    break;
                }
                BigRotation(node);
            }
            root = node;
        }
    }
}
