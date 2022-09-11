using System;
using System.Collections.Generic;
using System.Linq;

namespace A6
{
    public class Program
    {

        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long[] ans = Solve(n);
            Console.WriteLine(ans.Count() - 1);
            string s = "";
            for (int i = 0; i < ans.Count(); i++)
            {
                s += (ans[i].ToString() + " ");
            }
            Console.WriteLine(s.TrimEnd());
        }
        public static long[] Solve(long n)
        {
            long[] dp = new long[n + 1];
            dp[0] = 0;
            dp[1] = 0;
            List<long> ans = new List<long>();
            for (int i = 2; i <= n; i++)
            {
                long min = long.MaxValue;
                if (i % 2 == 0) min = Math.Min(dp[i / 2], dp[i - 1]);
                if (i % 3 == 0) min = Math.Min(dp[i / 3], min);
                min = Math.Min(min, dp[i - 1]);
                dp[i] = min + 1;
            }
            ans.Add(n);
            while (n > 1)
            {
                if (n % 3 == 0 && dp[n / 3] == dp[n] - 1)
                {
                    n /= 3;
                }
                else if (n % 2 == 0 && dp[n / 2] == dp[n] - 1)
                {
                    n /= 2;
                }
                else n--;
                ans.Add(n);
            }
            ans.Reverse();
            return ans.ToArray();
        }
    }
}
