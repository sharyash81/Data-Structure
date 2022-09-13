using System;
using System.Collections.Generic;
using System.Linq;
namespace A7
{
    public class Program
    {
        public static void Main()
        {
            string s = Console.ReadLine();
            Console.WriteLine(Solve(s));
        }
        public static long Solve(string expression)
        {
            int len = expression.Length;
            long[] num = new long[len-len/2];
            string[] op = new string[len / 2];
            for (int i = 0 ; i < len ; i++)
            {
                if (i%2==0)
                {   
                    num[i/2] = expression[i]-'0';
                }
                else op[(i-1)/2] = expression[i].ToString();
            }
            return MinAndMax((len/2)+1,num, op);
        }
        public static long MinAndMax(int n , long[] nums, string[] op)
        {
            long[,] min = new long[n, n];
            long[,] max = new long[n, n];
            for (int i = 0; i < n; i++)
            {
                min[i, i] = nums[i];
                max[i, i] = nums[i];
            }

            for (int i = 0; i < (n - 1); i++)
            {
                for (int j = 0; j < (n - i - 1); j++)
                {
                    int k = i + j + 1;
                    long minimum = int.MaxValue;
                    long maximum = int.MinValue;
                    long a, b, c, d;
                    for (int s = j; s < k; s++)
                    {
                        if (op[s] == "+")
                        {
                            a = max[j, s] + max[s + 1, k];
                            b = min[j, s] + min[s + 1, k];
                            c = max[j, s] + min[s + 1, k];
                            d = min[j, s] + max[s + 1, k];
                        }
                        else if (op[s] == "-")
                        {
                            a = max[j, s] - max[s + 1, k];
                            b = min[j, s] - min[s + 1, k];
                            c = max[j, s] - min[s + 1, k];
                            d = min[j, s] - max[s + 1, k];
                        }
                        else
                        {
                            a = max[j, s] * max[s + 1, k];
                            b = min[j, s] * min[s + 1, k];
                            c = max[j, s] * min[s + 1, k];
                            d = min[j, s] * max[s + 1, k];
                        }
                        minimum = Math.Min(minimum ,Math.Min(Math.Min(Math.Min(a,b),c),d));
                        maximum = Math.Max(maximum,Math.Max(Math.Max(Math.Max(a,b),c),d));
                    }
                    min[j, k] = minimum;
                    max[j, k] = maximum;
                }
            }
            return max[0, n - 1];
        }
    }
}