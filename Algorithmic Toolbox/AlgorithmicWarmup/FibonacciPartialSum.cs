using System;

namespace A3
{
    public class Program
    {
        public static void Main()
        {
            string [] s = Console.ReadLine().Split();
            long a = long.Parse(s[0]);
            long b = long.Parse(s[1]);
            Console.WriteLine(Solve(a,b));
        }
        public static long Solve(long a, long b)
        {
            return result(a,b);
        }
        public static long result(long m , long n)
        {
            long result = Solve1(n) - Solve1(m -1);
            if (m >= n) result = Solve1(m) - Solve1(n -1);
            if (result > 0 ) return result;
            else return (result + 10)%10;
        }
        public static long Solve1(long n)
        {
            return (pissano() * (n / 60) + pissano(n % 60)) % 10;
        }
        public static long pissano(long m = 60)
        {
            if (m < 3 ) return m;
            long i = 1,x = 0 , y = 1 , z = 1;
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