using System;
using System.Collections.Generic;
namespace A8
{
    public class Program
    {
        public static void Main()
        {
            string s = Console.ReadLine();
            long a = Solve(s);
            if (a==-1) Console.WriteLine("Success");
            else Console.WriteLine(a);
        }
        public static long Solve(string str)
        {
            Stack<char> stack = new Stack<char>();
            int n = str.Length;
            int first = -1;
            for (int i = 0 ; i < n ; i++)
            {
                if(str[i]=='[' || str[i] == '(' || str[i] == '{')
                {
                    stack.Push(str[i]);
                    if (first == -1) first = i+1;
                }
                else if (str[i]==']' || str[i] == ')' || str[i] == '}')
                {
                    if (stack.Count == 0)   return i+1;
                    char top = stack.Pop();
                    if (stack.Count == 0) first = -1;
                    if (!((str[i] == ']' && top=='[') || (str[i] == ')' && top=='(') || (str[i] == '}' && top == '{')))
                    {
                        return i+1;
                    }
                }
            }
            if (stack.Count != 0) return first;
            return -1;
        }
    }
}
