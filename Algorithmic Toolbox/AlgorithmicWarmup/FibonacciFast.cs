using System;

namespace A3
{
    public class Program
    {
        public static void Main()
        {
            int n =  int.Parse(Console.ReadLine());
            Console.WriteLine(Solve(n));
        }
        public static long Solve(long n)
        {
            if(n < 1) return 0;
            long [] fib_array = new long[n+1];
            fib_array[0] = 0;
            fib_array[1] = 1;
            for (int i = 2 ; i <= n;i++)   fib_array[i] = fib_array[i-1] + fib_array[i-2];
            return fib_array[n];
        }
   }
}