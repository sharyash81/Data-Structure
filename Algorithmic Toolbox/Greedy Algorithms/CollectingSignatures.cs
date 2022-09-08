using System;
using System.Collections.Generic;
using System.Linq;

namespace A4
{
    public class Program
    {

        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long[] st = new long[n];
            long[] et = new long[n];
            List<line> lines = new List<line>();
            for (int i = 0; i < n; i++)
            {
                string[] s = Console.ReadLine().Split();
                lines.Add(new line(long.Parse(s[0]), long.Parse(s[1])));
            }
            lines = lines.OrderBy(x => x.start).ToList();
            long current = lines[0].end;
            List<long> times = new List<long>();
            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i].start > current)
                {
                    times.Add(current);
                    current = lines[i].end;
                }
                else if (lines[i].end <= current) current = lines[i].end;
            }
            times.Add(current);
            Console.WriteLine(times.Count);
            string s1 ="";
            times.ForEach(x => s1+=(x.ToString()+" "));
            Console.WriteLine(s1.TrimEnd());
        }
    }
    public class line
    {
        public long start;
        public long end;
        public line(long start, long end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
