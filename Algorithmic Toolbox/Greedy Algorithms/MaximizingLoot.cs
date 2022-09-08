using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace hw3_q2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split();
            int n = int.Parse(s[0]);
            int W = int.Parse(s[1]);
            List<Food> myfood = new List<Food>(n);
            for (int i = 0; i < n; i++)
            {
                string[] s1 = Console.ReadLine().Split();
                myfood.Add(new Food(int.Parse(s1[0]), int.Parse(s1[1])));
            }
            myfood = myfood.OrderByDescending(x => x.vpu).ToList();
            int j = 0;
            double total_value = 0;
            while (j < n && W > 0)
            {
                if (W >= myfood[j].weight)
                {
                    W -= myfood[j].weight;
                    total_value += myfood[j].value;
                }
                else
                {
                    total_value += (double)(myfood[j].value) * (double)W / myfood[j].weight;
                    W = 0;
                }
                j++;
            }
            Console.WriteLine(String.Format("{0:0.0000}", total_value));
        }
        public static long min(long a, long b)
        {
            if (a < b) return a;
            return b;
        }
    }
    class Food
    {
        public int value;
        public int weight;
        public double vpu;
        public Food(int value, int weight)
        {
            this.value = value;
            this.weight = weight;
            this.vpu = (double)value / (double)weight;
        }
    }
}
