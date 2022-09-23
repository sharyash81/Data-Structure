using System;
using System.Collections.Generic;

namespace A10
{
    public class Program
    {
        public static void Main()
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            long x = 256;
            long p = 1000000007;
            int plenght = pattern.Length;
            int tlenght = text.Length;
            long[] occurrences = new long[tlenght];
            int index = 0;
            long h = 0;
            for (int i = pattern.Length - 1; i >= 0; i--) h = (x * h + pattern[i]) % p;
            long HashP = h;
            int lenght = text.Length;
            long[] H = new long[lenght - plenght + 1];
            string s = text.Substring(lenght - plenght);
            h = 0;
            for (int i = s.Length - 1; i >= 0; i--) h = (x * h + s[i]) % p;
            H[lenght - plenght] = h;
            long y = 1;
            for (int i = 0; i < plenght; i++) y = (y * x) % p;
            for (int i = lenght - plenght - 1; i >= 0; i--)
            {
                H[i] = (x * H[i + 1] + text[i] - y * text[i + plenght]) % p;
                while (H[i] < 0) H[i] += p;
            }
            for (int i = 0; i <= tlenght - plenght; i++)
            {
                if (HashP != H[i]) continue;
                if (text.Substring(i, plenght) == pattern)
                {
                    occurrences[index] = i;
                    index++;
                }
            }
            string ss = "";
            for (int i = 0; i < index; i++)
            {
                ss += (occurrences[i].ToString() + " ");
            }
            Console.WriteLine(ss.TrimEnd());
        }
    }
}
