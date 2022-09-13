using System;
using System.Collections.Generic;

namespace A7
{
    public class Program
    {
        public static void Main()
        {
            string[] s = Console.ReadLine().Split();
            int n = int.Parse(s[0]);
            int m = int.Parse(s[1]);
            string[] s1 = Console.ReadLine().Split();
            long[] gB = new long[m];
            for (int i = 0; i < m; i++)
            {
                gB[i] = long.Parse(s1[i]);
            }
            Console.WriteLine(Solve(n, gB));
        }
        public static long Solve(long W, long[] goldBars)
        {
            long n = goldBars.Length;
            long[,] dp = new long[W + 1, n + 1];
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = 0;
                dp[i, 0] = 0;
            }
            for (int i = 1; i < W + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (i >= goldBars[j - 1])
                    {
                        dp[i, j] = goldBars[j - 1] + dp[i - goldBars[j - 1], j - 1];
                    }
                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i, j]);
                }
            }
            return dp[W, n];
        }
    }
}
