using System;
using System.Collections.Generic;

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
            List <int> mylist = fib(n%60);
            return (mylist[0] * mylist[1])%10;
        }
        public static List<int> fib(long n)
        {
            if (n < 2 ) return new List<int>(2){(int)n-1,(int)n};
            List<int> mylist = new List<int>(2);
            int a = 0 , b = 1;
            int c = a + b ; 
            for(int i = 2 ; i<= n ;i++)
            {
                a = b ;
                b = c ;
                c = (a+b)%10;
            }
            mylist.Add(b);
            mylist.Add(c);
            return mylist;           
        }
    }
}