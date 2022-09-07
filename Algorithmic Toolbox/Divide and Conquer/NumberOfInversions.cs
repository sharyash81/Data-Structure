using System;
using System.Collections.Generic;
using System.Linq;
namespace A5
{
    public class Program
    {
        public static void Main()
        {
            long count = 0 ;
            int n = int.Parse(Console.ReadLine());
            string [] s = Console.ReadLine().Split();
            long [] a = new long [n];
            for (int i = 0 ; i < n ; i++)
            {
                a[i] = long.Parse(s[i]);
            }
            MergeSort(n,a,ref count);
            Console.WriteLine(count);
        }

        public static long[] MergeSort(long n, long[] a ,ref long count)
        {
            if (n==1) return a;
            long mid = n / 2;
            long[] b = new long[mid];
            long[] c = new long[n - mid];
            for (long i = 0; i < mid; i++)    b[i] = a[i];
            for (long i = mid ; i < n ; i++)    c[i-mid] = a[i];
            b = MergeSort((long)b.Length, b,ref count);
            c = MergeSort((long)c.Length, c,ref count);
            List<long> result = new List<long>();
            long j = 0, k = 0;
            while (j < b.Length && k < c.Length)
            {
                if (b[j] <= c[k])
                {
                    result.Add(b[j]);
                    j++;
                }
                else
                {
                    count += (mid - j);
                    result.Add(c[k]);
                    k++;
                }
            }
            for (; j < b.Length; j++)   result.Add(b[j]);
            for (; k < c.Length; k++)   result.Add(c[k]);
            return result.ToArray();
        }
    }
}
