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
        Console.WriteLine(sol.LongestIdealString("abcd", 3));
    }

    public class Solution
    {
        public int LongestIdealString(string s, int k)
        {
            if (s.Length == 1) return 1;
            HashSet<string> visited = new();

            Queue<(int, string)> q = new(); //int for current position in 's', string for current string

            

            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var cur = q.Dequeue();
                    var curPos = cur.Item1;
                    var curString = cur.Item2;
                    if (curPos < s.Length - 1)
                    {
                        var nextPos = curPos + 1;
                        var nextChar = s[nextPos];
                        var difference = Math.Abs(curString[^1] - nextChar);
                        if (difference <= k)
                        {
                            var newString = new string(curString + nextChar);
                            if (!visited.Contains(newString))
                            {
                                visited.Add(newString);
                                q.Enqueue((nextPos, newString));
                            }
                        }
                    }
                }
            }

            int longest = 0;
            foreach (var seq in visited)
            {
                longest = longest > seq.Length ? longest : seq.Length;
            }
            return longest;
        }
    }
}

