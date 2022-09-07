using System;
using System.Collections.Generic;
using System.Linq;
namespace A5
{
    public class Program
    {
        public static void Main()
        {
            string [] s = Console.ReadLine().Split();
            int NUMBER_OF_SEGMENTS = int.Parse(s[0]);
            int NUMBER_OF_POINTS = int.Parse(s[1]);
            long [] sS = new long [NUMBER_OF_SEGMENTS];
            long [] eS = new long [NUMBER_OF_SEGMENTS];
            for (int i = 0 ; i < NUMBER_OF_SEGMENTS ; i++)
            {
                string [] s1 = Console.ReadLine().Split();
                sS[i] = long.Parse(s1[0]);
                eS[i] = long.Parse(s1[1]);
            }
            string [] s2 = Console.ReadLine().Split();
            long [] p = new long [NUMBER_OF_POINTS];
            for (int i = 0 ; i < NUMBER_OF_POINTS ; i++)
            {
                p[i] = long.Parse(s2[i]);
            }
            long [] ans = Solve(p,sS,eS);
            string res ="";
            for (int i = 0 ; i < ans.Length ; i++)
            {
                res += (ans[i].ToString()+ " ");
            }
            Console.WriteLine(res.TrimEnd());
            
        }
        public static long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            int n = points.Count();
            int m = startSegments.Count();
            long[] ans = new long[n];
             List<List<long>> mypoints = new List<List<long>>();
             for (int i = 0; i < n; i++)
             {
                mypoints.Add(new List<long> { points[i], i });
             }

            List<List<long>> mysegments = new List<List<long>>();
            for (int i = 0; i < m ; i++)
            {
                mysegments.Add(new List<long> { startSegments[i], 1 });
                mysegments.Add(new List<long> { endSegment[i] + 1, 0 });
            }
            mysegments = mysegments.OrderBy(x => x[0]).ToList();
            mypoints = mypoints.OrderBy(x => x[0]).ToList();
            long count = 0;
            int j = 0;
            for (int i = 0; i < n; i++)
            {
               for (; j‌< 2 *m && mypoints[i][0] >= mysegments[j][0];j++)
                {
                    if (mysegments[j][1] == 0) count--;
                    count += mysegments[j][1];
                }
                ans[mypoints[i][1]] = count;
            }
            return ans;
        }
    }
}
