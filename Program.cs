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
            Dictionary<int, int> indexes = new();

            for (int i = 0; i < score.Length; i++)
            {
                indexes.Add(score[i], i);
            }

            HashSet<int> values = new(score);
            string[] anwser = new string[score.Length];

            int place = 1;
            while (values.Count > 0)
            {
                var cur = values.Max();
                int i = indexes[cur];

                switch (place)
                {
                    case 1:
                        anwser[i] = "Gold Medal";
                        break;
                    case 2:
                        anwser[i] = "Silver Medal";
                        break;
                    case 3:
                        anwser[i] = "Bronze Medal";
                        break;
                    default:
                        anwser[i] = place.ToString();
                        break;
                }

                place++;
                values.Remove(cur);
            }

            return anwser;
        }
    }
}
