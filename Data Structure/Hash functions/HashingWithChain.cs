using System;
using System.Collections.Generic;
using System.Linq;


namespace A10
{
    public class Program
    {
        public static void Main()
        {
            int BUCKET_COUNT = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[] commands = new string[n];
            for (int i = 0; i < n; i++)
            {
                commands[i] = Console.ReadLine();
            }
            HashingChain hashingchain = new HashingChain(BUCKET_COUNT);
            int j = 0;
            string[] result = new string[n];
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        hashingchain.Add(arg);
                        break;
                    case "del":
                        hashingchain.Delete(arg);
                        break;
                    case "find":
                        if (hashingchain.Find(arg))
                        {
                            result[j] = "yes";
                            j++;
                        }
                        else
                        {
                            result[j] = "no";
                            j++;
                        }
                        break;
                    case "check":
                        long index;
                        index = long.Parse(arg);
                        string row = hashingchain.Check((int)index);
                        if (row == "") row = "\n";
                        result[j] = row;
                        j++;
                        break;
                }
            }
            for (int i = 0; result[i]!= null; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
        public static string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            HashingChain hashingchain = new HashingChain((int)bucketCount);

            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        hashingchain.Add(arg);
                        break;
                    case "del":
                        hashingchain.Delete(arg);
                        break;
                    case "find":
                        if (hashingchain.Find(arg)) result.Add("yes");
                        else result.Add("no");
                        break;
                    case "check":
                        long index;
                        index = long.Parse(arg);
                        string row = hashingchain.Check((int)index);
                        if (row == "")
                            row = "-";
                        result.Add(row);
                        break;
                }
            }
            return result.ToArray();
        }
    }
    public class HashingChain
    {
        public List<List<string>> hashedchain;
        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public int cardinality;
        public HashingChain(int cardinality)
        {
            hashedchain = new List<List<string>>();
            for (int i = 0; i < cardinality; i++)
            {
                hashedchain.Add(new List<string>());
            }
            this.cardinality = cardinality;
        }
        public long PolyHash(string str)
        {
            long ans = 0;
            for (int i = str.Length - 1; i >= 0; i--)
                ans = ((ans * ChosenX + str[i]) % BigPrimeNumber);

            return (long)ans % cardinality;
        }
        public void Add(string str)
        {
            int index = (int)PolyHash(str);
            for (int i = 0; i < hashedchain[index].Count; i++)
            {
                if (hashedchain[index][i] == str)
                {
                    return;
                }
            }
            hashedchain[index].Add(str);
        }

        public bool Find(string str)
        {
            int index = (int)PolyHash(str);
            for (int i = 0; i < hashedchain[index].Count; i++)
            {
                if (hashedchain[index][i] == str)
                {
                    return true;
                }
            }
            return false;
        }

        public void Delete(string str)
        {
            int index = (int)PolyHash(str);
            for (int i = 0; i < hashedchain[index].Count; i++)
            {
                if (hashedchain[index][i] == str)
                {
                    hashedchain[index].RemoveAt(i);
                    return;
                }
            }
        }

        public string Check(int i)
        {
            string result = "";
            for (int j = hashedchain[i].Count - 1; j >= 0; j--)
            {
                result += (hashedchain[i][j] + " ");
            }
            return result.TrimEnd();
        }
    }
}
