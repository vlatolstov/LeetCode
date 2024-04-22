using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        Console.WriteLine(sol.MinMutation("AAAAAAAA", "CCCCCCCC", new string[] 
            { 
                "AAAAAAAA", 
                "AAAAAAAC", 
                "AAAAAACC", 
                "AAAAACCC", 
                "AAAACCCC", 
                "AACACCCC", 
                "ACCACCCC", 
                "ACCCCCCC", 
                "CCCCCCCA" }));


    }

    public class Solution
    {
        public int MinMutation(string startGene, string endGene, string[] bank)
        {
            char[] genes = new char[] { 'A', 'T', 'G', 'C' };
            HashSet<string> valid = new(bank);
            HashSet<string> visited = new();
            Queue<string> q = new();

            int steps = 0;

            q.Enqueue(startGene);
            visited.Add(startGene);

            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var cur = q.Dequeue();
                    if (cur == endGene) return steps;

                    for (int j = 0; j < cur.Length; j++)
                    {
                        for (int g = 0; g < genes.Length; g++)
                        {
                            if (cur[j] == genes[g]) continue;
                            var curArr = cur.ToCharArray();
                            curArr[j] = genes[g];
                            var next = new string(curArr);

                            if (valid.Contains(next) && !visited.Contains(next))
                            {
                                q.Enqueue(next);
                                visited.Add(next);
                            }
                        }
                    }
                }
                steps++;
            }
            return -1;
        }
    }
}