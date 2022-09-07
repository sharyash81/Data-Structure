using System;
using System.Collections.Generic;
using System.Linq;
namespace A5
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long [] sS = new long [n];
            long [] eS = new long [n];
            for (int i = 0 ; i < n ; i++)
            {
                string [] s = Console.ReadLine().Split();
                sS[i] = long.Parse(s[0]);
                eS[i] = long.Parse(s[1]);
            }
            Console.WriteLine(Solve(n,sS,eS));
        }
        public static double Solve(long n , long[] startSegments, long[] endSegment)
        {
            if (n==1) return int.MaxValue;
            if (n==2)
            {
                return Math.Round(Math.Sqrt(Math.Pow(startSegments[0] - startSegments[1], 2) + Math.Pow(endSegment[0] - endSegment[1], 2)),7);
            }
            List<Point> points = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                points.Add(new Point(startSegments[i], endSegment[i]));
            }
            Point[] a = points.OrderBy(x => x.start).ToArray();
            long mid = n / 2;
            long[] bx = new long[mid];
            long[] by = new long[mid];
            long[] cx = new long[n - mid];
            long[] cy = new long[n - mid];
            for (long i = 0; i < mid; i++)
            {
                bx[i] = a[i].start;
                by[i] = a[i].end;
            }
            for (long i = mid; i < n; i++)
            {
                cx[i - mid] = a[i - mid].start;
                cy[i - mid] = a[i - mid].end;
            }
            double dl = Solve(mid, bx, by);
            double dr = Solve(n - mid, cx, cy);
            double d = Math.Min(dl, dr);
            double midx = (bx[0] + cx[cx.Length-1]) / 2;
            List<Point> midpoints = points.Where(x => x.start > midx - d || x.start < midx + d).ToList();
            midpoints = midpoints.OrderBy(x => x.end).ToList();
            double min_distance = d * d;
            for (int i = 0; i < midpoints.Count - 1; i++)
            {
                for (int j = i + 1; j <= i + 7 && j < midpoints.Count; j++)
                {
                    double distance = Math.Pow((midpoints[i].start - midpoints[j].start), 2) + Math.Pow((midpoints[i].end - midpoints[j].end), 2);
                    if (distance < min_distance)    min_distance = distance;
                }
            }
            return Math.Round(Math.Sqrt(min_distance),7);
        }
    }
    public class Point
    {
        public long start ;
        public long end ;
        public Point(long start , long end)
        {
            this.start = start;
            this.end = end;
        }
    }
}