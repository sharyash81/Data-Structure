
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q2Chocolate : Processor
    {
        public Q2Chocolate(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long[], long>)Solve);
        public static long Solve(long n, long[] a)
        {
            long [] s = new long[n];
            for (long i = 0 ; i < n ; i++)
            {
                s[i] = 1 ;
            }
            for (long i = 0; i < n - 1 ; i++)
            {
                if (a[i] < a[i+1])
                {
                    s[i + 1] = s[i] + 1;
                }
            }
            for (long i = n - 1; i > 0; i--)
            {
                if (a[i - 1] > a[i] && s[i - 1] <= s[i])
                {
                    s[i - 1] = s[i] + 1;
                }
            }
            return s.ToList().Sum();
        }
    }
}
