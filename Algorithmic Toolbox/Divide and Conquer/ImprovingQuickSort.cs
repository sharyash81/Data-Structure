using System;
using System.Collections.Generic;

namespace A5
{
    public class Program
    {
        public static void Main()
        {
            int n =  int.Parse(Console.ReadLine());
            long [] a = new long [n];
            string [] s = Console.ReadLine().Split();
            for (int i = 0 ; i < n ; i++)
            {
                a[i] = long.Parse(s[i]);
            }
            long [] ans = Solve(n,a);
            string s1 = "";
            for (int i = 0 ; i < n ; i++)
            {
                s1+=(ans[i].ToString()+" ");
            }
            Console.WriteLine(s1.TrimEnd());
        }
        public static long[] Solve(long n, long[] a)
        {
            RandomizedQuickSort_EqualElement(ref a,0,n-1);
            return a;
        }
        public static void RandomizedQuickSort_EqualElement(ref long[] A, long l, long r)
        {
            if (l >= r) return;
            Random R = new Random();
            long k = R.Next((int)l, (int)r + 1);
            Swap(ref A[l], ref A[k]);
            long[] m = Partition_EqualElement(ref A, l, r);
            RandomizedQuickSort_EqualElement(ref A, l, m[0] - 1);
            RandomizedQuickSort_EqualElement(ref A, m[1] + 1, r);
        }
        public static long[] Partition_EqualElement(ref long[] A, long l ,long r )
        {
            //Console.ForegroundColor = ConsoleColor.Blue;
            long x = A[l];
           // Console.WriteLine("PIVOT IS :" + x);
            long m1 = l;
            long m2 = r;
            for (long i = l; i<= r; i++)
            {
                if (A[i] < x )
                {
                    Swap(ref A[m1], ref A[i]);
                    m1++;
                }
                else if (A[i] > x)
                {
                    Swap(ref A[m2], ref A[i]);
                    m2--;
                    i--;
                }
                if (m2 == i) break;
            }
            return new long[] { m1, m2 };
        }
        public static void Swap(ref long a, ref long b)
        {
            long tmp = a;
            a = b;
            b = tmp;
        }
    }
}
