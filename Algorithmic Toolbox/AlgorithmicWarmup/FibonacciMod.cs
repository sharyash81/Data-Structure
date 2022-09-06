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
        public static long Solve(long a , long b)
        {
            long i = 1 , x = 0 , y = 1 , z = 1 ; 
            while (z != 1 || y!= 0)
            {
                i++;
                x = y;
                y = z;
                z = (x + y)%b; 
            }
            long index = a % (i);
            return fib(index,b);
        }
        public static long fib(long n,long mod )
        {
            if (n‌‌ <= 1 ) return n;
            long a = 0, b = 1, c = 1;
            for (long i = 2; i <= n ; i++)
            {
                c = (a + b)%mod;
                a = b;
                b = c;
            }
            return c;
        }       
    }
}