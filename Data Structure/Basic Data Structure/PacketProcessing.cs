using System;
using System.Collections.Generic;
using System.Linq;

namespace A8
{
    public class Program
    {
        public static void Main()
        {
            string[] s = Console.ReadLine().Split();
            int BUFFER_SIZE = int.Parse(s[0]);
            int NUMBER_OF_PACKETS = int.Parse(s[1]);
            long[] aT = new long[NUMBER_OF_PACKETS];
            long[] pT = new long[NUMBER_OF_PACKETS];
            for (int i = 0; i < NUMBER_OF_PACKETS; i++)
            {
                string[] s1 = Console.ReadLine().Split();
                aT[i] = long.Parse(s1[0]);
                pT[i] = long.Parse(s1[1]);
            }
            long[] ans = Solve(BUFFER_SIZE, aT, pT);
            for (int i = 0; i < ans.Length; i++)
            {
                Console.WriteLine(ans[i]);
            }
        }
        public static long[] Solve(long bufferSize, long[] arrivalTimes, long[] processingTimes)
        {
            if (arrivalTimes.Length == 0) return new long[] { };
            int n = arrivalTimes.Length;
            long[] result = new long[n];
            long lastFin = 0;
            LinkedList<Packet> list = new LinkedList<Packet>();
            for (int i = 0; i < n; i++)
            {
                while (list.Count > 0)
                {
                    if (list.First.Value.handled > arrivalTimes[i]) break;
                    else
                    {
                        result[(int)list.First.Value.id] = list.First.Value.handled - list.First.Value.processing;
                        list.RemoveFirst();
                    }
                }
                if (list.Count < bufferSize)
                {
                    if (list.Count == 0)
                    {
                        Packet p = new Packet(i, processingTimes[i], arrivalTimes[i] + processingTimes[i]);
                        list.AddLast(p);
                    }
                    else
                    {
                        lastFin = list.Last.Value.handled;
                        Packet p = new Packet(i, processingTimes[i], lastFin + processingTimes[i]);
                        list.AddLast(p);
                    }
                }
                else result[i] = -1;
            }
            while (list.Count > 0)
            {
                result[(int)list.First.Value.id] = list.First.Value.handled - list.First.Value.processing;
                list.RemoveFirst();
            }
            return result;
        }
    }
    public class Packet
    {
        public long id;
        public long processing;
        public long handled;
        public Packet(long id, long p, long h)
        {
            this.id = id;
            this.processing = p;
            this.handled = h;
        }
    }
}