using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        Console.WriteLine(sol.ValidPath(3, new int[][] { new int[] { 0, 1 }, new int[] { 1,2 }, new int[] { 2,0 } }, 0, 2));
        //n = 3, edges = [[0,1],[1,2],[2,0]], source = 0, destination = 2
        //n = 6, edges = [[0,1],[0,2],[3,5],[5,4],[4,3]], source = 0, destination = 5
    }

    public class Solution
    {
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            var graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var queue = new Queue<int>();
            var visited = new HashSet<int>();

            queue.Enqueue(source);
            visited.Add(source);

            while(queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (vertex == destination) return true;

                foreach (var neighbor in graph[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
            return false;
        }
    }
}