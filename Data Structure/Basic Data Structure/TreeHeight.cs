using System;
using System.Collections.Generic;
using System.Linq;

namespace A8
{
    public class Program
    {

        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long[] t = new long[n];
            string[] s = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                t[i] = long.Parse(s[i]);
            }
            Console.WriteLine(Solve(n, t));
        }
        public static long Solve(long nodeCount, long[] tree)
        {
            List<long>[] nei = new List<long>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                nei[i] = new List<long>();
            }
            Stack<long> stack = new Stack<long>();
            bool[] mark = new bool[nodeCount];
            long[] height = new long[nodeCount];
            long root = 0;
            for (int i = 0; i < nodeCount; i++)
            {
                if (tree[i] == -1)
                {
                    root = i;
                }
                else
                {
                    nei[i].Add(tree[i]);
                    nei[(int)tree[i]].Add(i);
                }
            }
            stack.Push(root);
            while (stack.Count != 0)
            {
                long i = stack.Pop();
                if (!mark[i])
                {
                    mark[i] = true;
                    foreach (var j in nei[(int)i])
                    {
                        if (!mark[j])
                        {
                            stack.Push(j);
                            height[j] = height[i] + 1;
                        }
                    }
                }
            }
            return height.Max() + 1;
        }
    }
}
