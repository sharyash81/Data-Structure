using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace hw3_q3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int full_tank = int.Parse(Console.ReadLine());
            int numOfGas = int.Parse(Console.ReadLine());
            List<int> gas = new List<int>(numOfGas);
            gas.Add(0);
            string[] s = Console.ReadLine().Split();
            for (int i = 0; i < numOfGas; i++)
            {
                gas.Add(int.Parse(s[i]));
            }
            gas.Add(lenght);
            Console.WriteLine(Refill(full_tank, gas, gas.Count - 2));

        }
        public static int Refill(int fulltank, List<int> gas, int n)
        {
            /*int j = 0,result = 0,lastpos = 0, currentpos = 0; 
            while(j<n)
            {
                while(gas[j] - lastpos < fulltank && j < n)
                {
                    j++;
                    currentpos = j;
                }
                if (currentpos == lastpos) return -1;
                else
                {
                    lastpos = gas[j-1];
                    result++;
                }
            }*/
            int num = 0, currentpos = 0;
            while (currentpos <= n)
            {
                int lastrefill = currentpos;
                while (currentpos <= n && gas[currentpos + 1] - gas[lastrefill] <= fulltank)
                {
                    currentpos++;
                }
                if (currentpos == lastrefill)
                {
                    return -1;
                }
                if (currentpos <= n)
                {
                    num++;
                }
            }
            return num;
        }
    }
}
