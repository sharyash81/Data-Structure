using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace h3_q6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> a = Solve(n);
            Console.WriteLine(a.Count);
            foreach (var i in a )
            {
                Console.Write(i + " ");
            }
        }
        public static List<int> Solve(long n)
        {
            int i = 1;
            long d = n;
            List<int> a = new List<int>();
            while (i * (i + 1) / 2 <= n)
            {
                d -= i;
                a.Add(i);
                i++;
            }
            for (int j = a.Count-1; j >= 0;j--)
            {
              if (d == 0) break;
              a[j] += 1;
              d--;
            }
            return a;
        }

    }
}
