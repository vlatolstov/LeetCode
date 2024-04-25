using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        //Console.WriteLine(sol.LongestIdealString("acfgbd", 2));
        //Console.WriteLine(sol.LongestIdealString("abcd", 3));
        Console.WriteLine(sol.LongestIdealString("abfgkajsnsdfnwwwkdjksmdjkrnksmdnfsdhertfddgdjhrkjeretfehqwsdfjhtyjwedfsdmfm", 7));
    }

    public class Solution
    {
        public int LongestIdealString(string s, int k)
        {
            if (s.Length == 1) return 1;

            
            Queue<string> q = new();

            var first = s[0].ToString();
            q.Enqueue(first);

            for (int i = 1; i < s.Length; i++)
            {
                var nextChar = s[i];

                int size = q.Count;
                for (int j = 0; j < size; j++)
                {
                    var cur = q.Dequeue();

                    var difference = Math.Abs(cur[^1] - nextChar);
                    if (difference <= k)
                    {
                        var newString = new string(cur + nextChar);
                        q.Enqueue(newString);
                    }
                    else
                    {
                        q.Enqueue(cur);
                        q.Enqueue(s[i].ToString());
                    }
                }
            }
            int longest = 0;
            while(q.Count > 0)
            {
                var lenght = q.Dequeue().Length;
                longest = longest > lenght ? longest : lenght;
            }
            
            return longest;
        }
    }
}

