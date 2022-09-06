using System;

namespace A3
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
            return (pissano() * (n / 60) + pissano(n % 60)) % 10;
        }
        public static long pissano(long m = 60)
        {
            if (m < 3) return m;
            long i = 1,x = 0 , y = 1 , z = 1 ;
            long total = x + y + z;
            while (z != 1 || y != 0)
            {
                i++;
                x = y;
                y = z;
                z = (x + y) % 10;
                total += z;
                if (m - 1 == i) break;
            }
            return total;
        }
    }
}