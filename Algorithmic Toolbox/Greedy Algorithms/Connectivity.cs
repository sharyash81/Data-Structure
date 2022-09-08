using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q3Connectivity : Processor
    {
        public Q3Connectivity(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long a = first[1];
            long b = first[2];
            long [] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, b, p).ToString();
        }

        public long Solve(long n, long a, long b, long[] p)
        {
            p = p.ToList().OrderBy(x=>x).ToArray();
            long [] s = new long[n];
            long min = b;
            long max = a ;
            if ( a‌ < b )
            {
                min = a;
                max = b;
            }
            for (int i =0 ; i < n ; i++)
            {
                s[i] = min;
            }
            Console.WriteLine(max);
            for (int i = 0 ; i‌‌‌ < n-1 ; i++)
            {
                if (!((s[i] + p[i] >= p[i + 1]) && (p[i+1] - s[i+1] <= p[i])))
                { 
                    s[i] = max;
                    s[i + 1] = max;
                }
            }
            return s.ToList().Sum();
        }
    }
}
