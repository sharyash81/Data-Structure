using System;

namespace hw3_q1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Number_of_coins(n));
        }
        public static int Number_of_coins(int num)
        {
            int ten = num / 10;
            num %= 10;
            int five = num / 5;
            num %= 5;
            int one = num;
            return ten + five + one;
        }
    }
}
