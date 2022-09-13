using System;
using System.Collections.Generic;
using System.Linq;
namespace A7
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
            Console.WriteLine(Solve(n, a));
        }
        public static long Solve(long count, long[] souvenirs)
        {
            if (count == 0) return 0;
            long sum = souvenirs.Sum();
            if (sum % 3 != 0) return 0;
            long sum1 = sum / 3;
            long sum2 = sum1 * 2;
            bool[,,] dp = new bool[count + 1, sum2 + 1, sum2 + 1];
            dp[0, 0, 0] = true;
            for (int i = 1; i < count + 1; i++)
            {
                for (int j = 0; j < sum2 + 1; j++)
                {
                    for (int k = 0; k < j + 1; k++)
                    {
                        dp[i, j, k] = dp[i - 1, j, k];
                        if (j >= souvenirs[i - 1] && k >= souvenirs[i - 1]) dp[i, j, k] |= dp[i - 1, j - souvenirs[i - 1], k - souvenirs[i - 1]];
                        if (j >= souvenirs[i - 1]) dp[i, j, k] |= dp[i - 1, j - souvenirs[i - 1], k];
                    }
                }
            }
            if (dp[count, sum2, sum1]) return 1;
            return 0;
        }
    }
}
