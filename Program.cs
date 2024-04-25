using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        Console.WriteLine(sol.LongestIdealString("acfgbd", 2));
        Console.WriteLine(sol.LongestIdealString("rnksmdnfsdhertf", 7));
        Console.WriteLine(sol.LongestIdealString("nksmdnfsdhert", 7));
        Console.WriteLine(sol.LongestIdealString("abcd", 3));
        //lenght 75, answ 49   
        Console.WriteLine(sol.LongestIdealString("abfgkajsnsdfnwwwkdjksmdjkrnksmdnfsdhertfddgdjhrkjeretfehqwsdfjhtyjwedfsdmfm", 7));
    }

    public class Solution
    {
        public int LongestIdealString(string s, int k)
        {
            int[] all = new int[27];

            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                int index = c - 'a';

                int max = int.MinValue;

                int left = Math.Max(index - k, 0);
                int right = Math.Min(index + k, 26);

                for (int j = left; j <= right; j++)
                {
                    max = Math.Max(max, all[j]);
                }

                all[index] = max + 1;
            }

            int res = int.MinValue;
            foreach (int i in all) res = Math.Max(i, res);

            return res;
        }
    }
}

