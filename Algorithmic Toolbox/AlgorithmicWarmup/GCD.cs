using System;


namespace A3
{
    public class Program
    {
        public  static void Main()
        {
            string [] s = Console.ReadLine().Split();
            long a = long.Parse(s[0]);
            long b = long.Parse(s[1]);
            Console.WriteLine(Solve(a,b));
        }
        public static long Solve(long a, long b)
        {
            return gcd(a,b);
        }
        public static long gcd(long a , long b)
        {
            if (b==0) return a;
	        else return gcd(b,a%b);
        }
        
    }
}
