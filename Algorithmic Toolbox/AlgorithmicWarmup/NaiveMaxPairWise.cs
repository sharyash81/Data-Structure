using System;

namespace A2
{
    public class Program
    {
        public static void Main()
        {
            int n  = int.Parse(Console.ReadLine());
            string [] s = Console.ReadLine().Split();
            int [] a = new int [n];
            for (int i = 0 ; i < n ; i++)
            {
                a[i] = int.Parse(s[i]);
            }
            Console.WriteLine(Solve(a));
        }
        public static long Solve(int[] numbers)
        {
            long max = 0;
            for(int i = 0 ; i < numbers.Length ; i++)
            {
                for (int j = i+1 ; j < numbers.Length ; j++)
                {
                    if (numbers[i] * numbers[j] > max)
                    {
                        max = numbers[i] * numbers[j];
                    }
                }
            }
            return max ; 
        }
    }
}

