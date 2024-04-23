using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        var sw = new Stopwatch();
        sw.Start();
        var edges = new int[][]
        {
            new int[] { 1, 0 },
            new int[] { 1, 2 },
            new int[] { 1, 3 }
        };

        foreach (int i in sol.FindMinHeightTrees(4, edges))
        {
            Console.Write(i + " ");
        }
        var edges2 = new int[][]
        {
            new int[] { 3, 0 },
            new int[] { 3, 1 },
            new int[] { 3, 2 },
            new int[] { 3, 4 },
            new int[] { 5, 4 }
        };

        foreach (int i in sol.FindMinHeightTrees(6, edges2))
        {
            Console.Write(i + " ");
        }
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Stop();
    }

    public class Solution
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            
            Dictionary<int, List<int>> graph = new();

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            Queue<int> q = new();

            while (graph.Count > 2)
            {
                foreach (var node in graph)
                {
                    if (node.Value.Count == 1)
                    {
                        q.Enqueue(node.Key);
                    }
                }

                while (q.Count > 0)
                {
                    var key = q.Dequeue();
                    graph[graph[key][0]].Remove(key);
                    graph.Remove(key);
                }
                
            }
            return graph.Select(n => n.Key).ToList();
        }
    }
}

