using System;
using System.Collections.Generic;

namespace A9
{
    public class Program
    {
        public static void Main()
        {
            List<Tuple<long,long>> ans = new List<Tuple<long, long>>();
            int n = int.Parse(Console.ReadLine());
            string [] s = Console.ReadLine().Split();
            long [] array = new long [n];
            for (int i  =0 ; i < n ; i++)
            {
                array[i] = long.Parse(s[i]);
            }
            for (int i = n/2 ; i >=0  ; i--)
            {
                SiftDown(i,ref array,ref ans);
            }
            Console.WriteLine(ans.Count);
            foreach(var i in ans)
            {
                Console.WriteLine(i.Item1 + " " + i.Item2) ;
            }
        }
        public static void SiftDown(int i,ref long [] array,ref List<Tuple<long,long>> ans)
        {
            int min = i ; 
            int l;
            int left_child_ind = 2 * i + 1 ;
            if (left_child_ind >= array.Length) l = -1;
            else l = left_child_ind;
            int r;
            int right_child_ind = 2 * i + 2 ;
            if (right_child_ind >= array.Length) r = -1;
            else r = right_child_ind;
            if (l!=-1 && array[l] < array[min]) min = l;
            if (r!=-1 && array[r] < array[min]) min = r;
            if (i!=min)
            {
                ans.Add(new Tuple<long, long>(i,min));
                long tmp = array[i];
                array[i] = array[min];
                array[min] = tmp;
                SiftDown(min,ref array,ref ans);
            }
        }
    }
}
