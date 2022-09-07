using System;
using System.Collections.Generic;


namespace A5
{
    public class Program
    {

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long [] a = new long [n];
            string [] s = Console.ReadLine().Split();
            for (int i = 0 ; i < n ; i++)
            {
                a[i] = long.Parse(s[i]);
            }
            Console.WriteLine(Solve(n,a));
        }
        public static long Solve(long n, long[] a)
        {
            if (majoriy_element(n,a)==long.MinValue) return 0;
            return 1;
        }
        public static long majoriy_element(long n , long [] a)
        {
            if (n==1) return a[0];
            long mid = n/2;
            long [] b = new long[mid];
            long [] c = new long[n-mid];
            for (long i = 0 ; i‌ < mid ; i++) b[i] = a[i];
            for (long i = mid ; i < n ;i++) c[i-mid] = a[i];
            long leftmajority = majoriy_element(b.Length,b);
            long rightmajority = majoriy_element(c.Length,c);
            if (rightmajority == leftmajority) return leftmajority;
            int lcount = 0 ;
            int rcount = 0 ;
            for (int i = 0 ; i < a.Length ; i++)
            {
                if (a[i]==rightmajority) rcount++;
                if (a[i]==leftmajority) lcount++;
            }
            if (lcount > n/2) return leftmajority;
            if (rcount > n/2) return rightmajority;
            return long.MinValue;
        }
    }
}
