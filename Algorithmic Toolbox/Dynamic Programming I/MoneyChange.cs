using System;
using System.Collections.Generic;

namespace A6
{
    public class Program
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(Solve(n));
        }
        public static long Solve(long n)
        {
            if (n < 3) return n;
            if (n == 3) return 1;
            if (n == 4) return 1;
            long[] dp = new long[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 1;
            dp[4] = 1;
            for (int i = 5; i <= n; i++)
            {
                dp[i] = Min(dp[i - 1], dp[i - 3], dp[i - 4]) + 1;
            }
            return dp[n];
        }
        public static long Min(params long[] a)
        {
            long min = long.MaxValue;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min) min = a[i];
            }
            return min;
        }
    }
}
