using System;
using System.Collections.Generic;

namespace A5
{
    public class Program
    {
        public static void Main()
        {
            string[] s = Console.ReadLine().Split();
            string[] s1 = Console.ReadLine().Split();
            int n = int.Parse(s[0]);
            int m = int.Parse(s1[0]);
            long[] a = new long[n];
            long[] b = new long[m];
            for (int i = 1; i < n; i++)
            {
                a[i-1] = long.Parse(s[i]);
            }
            for (int i = 1; i < m; i++)
            {
                b[i-1] = long.Parse(s1[i]);
            }
            List<long> index = new List<long>();
            for (int i = 0; i < b.Length; i++)
            {
                int start = 0;
                int end = a.Length - 1;
                bool find = false;
                while (start <= end)
                {
                    int mid = start + ((end - start) / 2);
                    if (b[i] == a[mid])
                    {
                        index.Add(mid);
                        find = true;
                        break;
                    }
                    if (b[i] < a[mid]) end = mid - 1;
                    else start = mid + 1;
                }
                if (!find) index.Add(-1);
            }
            long[] c = index.ToArray();
            string s2 = "";
            for (int i = 0; i < c.Length; i++)
            {
                s2 += (c[i].ToString() + " ");
            }
            Console.WriteLine(s2.TrimEnd());

        }
    }
}
