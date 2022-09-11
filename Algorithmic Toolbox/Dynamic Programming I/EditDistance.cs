using System;
namespace A6
{
    public class Program
    {
        public static void Main()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Console.WriteLine(Solve(a, b));
        }
        public static long Solve(string str1, string str2)
        {
            long m = str1.Length;
            long n = str2.Length;
            long[,] dp = new long[m + 1, n + 1];
            for (int i = 0; i < m + 1; i++)
                dp[i, 0] = i;
            
            for (int j = 0; j < n + 1; j++)
                dp[0, j] = j;
            

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (str1[i - 1] == str2[j - 1]) dp[i, j] = dp[i - 1, j - 1];
                    else  p[i, j] = Min(dp[i - 1, j], dp[i, j - 1], dp[i - 1, j - 1]) + 1;
                }
            }
            return dp[m, n];
        }
        public static long Min(params long[] a)
        {
            long min = long.MaxValue;
            foreach (var i in a)
                if (i < min) min = i;
            return min;
        }
    }
}
