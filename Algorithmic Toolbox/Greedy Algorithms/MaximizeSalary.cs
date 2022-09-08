using System;

namespace h3_q7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] a = new long[n];
            string[] s = Console.ReadLine().Split();
            for(int i = 0; i < n;i++)
            {
                a[i] = long.Parse(s[i]);
            }
            long[] ans = Solve(a, n);
            foreach(var i in ans)
            {
                Console.Write(i);
            }
        }
        public static long[] Solve(long []a   , long n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n-1; j++)
                { 
                    if (Bigger(a[j+1],a[j]))
                    {
                        long tmp  = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = tmp;
                    }
                }

            }
            return a;
        }
        public static bool Bigger(long s1 , long s2 )
        {
            string ans1 = "";
            string ans2 = "";
            ans1 = s1.ToString() + s2.ToString();
            ans2 = s2.ToString() + s1.ToString();
            if (long.Parse(ans1) > long.Parse(ans2))
            {
                return true;
            }
            return false;
        }
    }
}
