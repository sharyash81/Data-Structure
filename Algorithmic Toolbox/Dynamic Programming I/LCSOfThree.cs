using System;
using System.Collections.Generic;

namespace A6
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[] a = new long[n];
            string[] s = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                a[i] = long.Parse(s[i]);
            }
            int m = int.Parse(Console.ReadLine());
            long[] b = new long[m];
            string[] s1 = Console.ReadLine().Split();
            for (int i = 0; i < m; i++)
            {
                b[i] = long.Parse(s1[i]);
            }
            int t = int.Parse(Console.ReadLine());
            long[] c = new long[t];
            string[] s2 = Console.ReadLine().Split();
            for (int i = 0; i < t; i++)
            {
                c[i] = long.Parse(s2[i]);
            }
            Console.WriteLine(Solve(a, b, c));
        }
        public static long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            int n = seq1.Length;
            int m = seq2.Length;
            int t = seq3.Length;
            long[,,] dp = new long[n + 1, m + 1, t + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    for (int k = 1; k <= t; k++)
                    {
                        if (seq1[i - 1] == seq2[j - 1] && seq1[i - 1] == seq3[k - 1])
                        {
                            dp[i, j, k] = dp[i - 1, j - 1, k - 1] + 1;
                        }
                        else
                        {
                            dp[i, j, k] = Math.Max(dp[i - 1, j, k], Math.Max(dp[i, j - 1, k], dp[i, j, k - 1]));
                        }
                    }
                }
            }
            return dp[n, m, t];
        }
    }
}
