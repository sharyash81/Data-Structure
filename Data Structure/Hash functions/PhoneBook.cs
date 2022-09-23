using System;
using System.Linq;
using System.Collections.Generic;

namespace A10
{
    public class Contact
    {
        public string Name;
        public int Number;

        public Contact(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }

    public class Program
    {
        protected static List<Contact> PhoneBookList;
        protected static Dictionary<string, string> Contacts;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = new string[n];
            for (int i = 0; i < n; i++)
            {
                commands[i] = Console.ReadLine();
            }
            string[] ans = Solve(commands);
            for (int i = 0; i < ans.Count(); i++)
            {
                Console.WriteLine(ans[i]);
            }
        }
        public static string[] Solve(string[] commands)
        {
            int lenght = commands.Length;
            PhoneBookList = new List<Contact>(lenght);
            Contacts = new Dictionary<string, string>();
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                var number = args[0];
                switch (cmdType)
                {
                    case "add":
                        Contacts[number] = args[1];
                        break;
                    case "del":
                        Contacts.Remove(number);
                        break;
                    case "find":
                        if (Contacts.ContainsKey(number))
                        {
                            result.Add(Contacts[number]);
                        }
                        else
                        {
                            result.Add("not found");
                        }
                        break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number)
        {
            for (int i = 0; i < PhoneBookList.Count; i++)
            {
                if (PhoneBookList[i].Number == number)
                {
                    PhoneBookList[i].Name = name;
                    return;
                }
            }
            PhoneBookList.Add(new Contact(name, number));
        }

        public string Find(int number)
        {
            for (int i = 0; i < PhoneBookList.Count; i++)
            {
                if (PhoneBookList[i].Number == number)
                    return PhoneBookList[i].Name;
            }
            return "not found";
        }

        public void Delete(int number)
        {
            for (int i = 0; i < PhoneBookList.Count; i++)
            {
                if (PhoneBookList[i].Number == number)
                {
                    PhoneBookList.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
