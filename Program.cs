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
            if (s.Length == 1) return 1;

            int longest = 0;

            List<Seq> list = new();

            for (int i = 0; i < s.Length; i++)
            {
                foreach (var cur in list)
                {
                    if (Math.Abs(cur.Ch - s[i]) <= k)
                    {
                        cur.Change(s[i]);
                        longest = longest > cur.Lenght ? longest : cur.Lenght;
                    }
                }
                if (s.Length - 1 - i > longest) list.Add(new Seq(s[i]));
            }

            return longest;
        }

        public class Seq
        {
            public char Ch { get; private set; }
            public int Lenght { get; private set; }

            /// <summary>
            /// Creates a new sequence of chars. 
            /// </summary>
            /// <param name="c">current char.</param>
            /// <param name="l">total lenght.</param>
            public Seq(char c, int l = 1)
            {
                Ch = c;
                Lenght = l;
            }

            /// <summary>
            /// sets new last char and icrease lenght by 1.
            /// </summary>
            /// <param name="c">change last char.</param>
            public void Change(char c)
            {
                Ch = c;
                Lenght++;
            }
        }
    }
}

