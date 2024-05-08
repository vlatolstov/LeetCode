using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();



    }

    public class Solution
    {
        public string[] FindRelativeRanks(int[] score)
        {
            List<(int, int)> adj = new();
           

            for (int i = 0; i < score.Length; i++)
            {
                adj.Add((score[i], i));
            }

            var res = new string[score.Length];
            int place = 1;

            var order = adj.OrderByDescending(i => i.Item1);

            foreach (var pair in order)
            {
                res[pair.Item2] = place switch
                {
                    1 => "Gold Medal",
                    2 => "Silver Medal",
                    3 => "Bronze Medal",
                    _ => place.ToString()
                };
                place++;
            }

            return res;
        }
    }
}
