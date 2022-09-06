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
            int max1_index = 0;
            int max2_index = numbers.Length-1;
            for (int i = 0 ; i‌< numbers.Length ; i++)
            {
                if (numbers[i] > numbers[max1_index])
                {
                    max1_index = i;
                }
            }
            for (int i = 0 ; i < numbers.Length ; i++)
            {
                if (i != max1_index && numbers[max2_index] < numbers[i])
                {
                    max2_index = i;
                }
            }
            return numbers[max1_index] * numbers[max2_index];
        }
    }
}

