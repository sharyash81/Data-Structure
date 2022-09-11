using System;
using System.Collections.Generic;
using System.Linq;


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
            Console.WriteLine(Solve(a, b));
        }
        public static long Solve(long[] seq1, long[] seq2)
        {
            int n = seq1.Length;
            int m = seq2.Length;
            long[,] dp = new long[n + 1, m + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (seq1[i - 1] == seq2[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return dp[n, m];
        }
    }
}
