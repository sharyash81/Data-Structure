using System;

namespace A3
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Solve(n));
        }
        public static long Solve(long a)
        {
            return fib(a%60);
        }
        public static long fib(long n)
        {
            if (n‌‌ <= 1 ) return n;
            long a = 0, b = 1, c = 1;
            for (long i = 2; i <= n ; i++)
            {
                c = (a + b)%10;
                a = b;
                b = c;
            }
            return c;
        }
     }
}
