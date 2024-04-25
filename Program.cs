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
            var alphabet = new int[27];

            for (int i = s.Length - 1; i >=0; i--)
            {
                char c = s[i];
                int index = c - 'a';

                int left = Math.Max(0, index - k);
                int right = Math.Min(26, index + k);

                int longest = int.MinValue;
                for (int j = left; j <= right; j++)
                {
                    longest = Math.Max(longest, alphabet[j]);
                }

                alphabet[index] = longest + 1;
            }

            int max = int.MinValue;
            foreach (int i in alphabet) max = Math.Max(max, i);

            return max;
        }
    }
}

