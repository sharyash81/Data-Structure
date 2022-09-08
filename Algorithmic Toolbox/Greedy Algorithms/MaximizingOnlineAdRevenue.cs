using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace hw3_q4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[] a = new long[n];
            long[] b = new long[n];
            string[] s1 = Console.ReadLine().Split();
            string[] s2 = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                a[i] = long.Parse(s1[i]);
                b[i] = long.Parse(s2[i]);

            }
            Console.WriteLine(Solve(n, a, b));
        }
        public static long Solve(long n ,long [] a , long [] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            long total = 0;
            for (long i =  n - 1; i >= 0; i--)
            {
                total += a[i] * b[i];
            }
            return total;
        }
    }
}
