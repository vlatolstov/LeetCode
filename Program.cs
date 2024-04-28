using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        int[][] array = new int[][]
        {
            new int[] {0, 1},
            new int[] {0, 2},
            new int[] {2, 3},
            new int[] {2, 4},
            new int[] {2, 5}
        };
        foreach (int i in sol.SumOfDistancesInTree(6, array))
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        int[][] array2 = new int[][] { };
        foreach (int i in sol.SumOfDistancesInTree(1, array2))
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        int[][] array3 = new int[][] { new int[] { 1, 0 } };
        foreach (int i in sol.SumOfDistancesInTree(2, array3))
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

    }

    public class Solution
    {
        public int[] SumOfDistancesInTree(int n, int[][] edges)
        {
            if (n == 1) return new int[] { 0 };
            var graph = new Dictionary<int, IList<int>>();
            var answer = new int[n];

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                graph[edges[i][0]].Add(edges[i][1]);
                graph[edges[i][1]].Add(edges[i][0]);
            }

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                HashSet<int> visited = new();
                visited.Add(i);
                sum = CheckAllDestinations(i, visited, 0, 0);

                visited.Clear();
                answer[i] = sum;
            }

            return answer;

            int CheckAllDestinations(int position, HashSet<int> visited, int sum, int length)
            {
                if (!visited.Contains(position))
                {
                    sum += length;
                    visited.Add(position);
                }
                foreach (var destination in graph[position])
                {
                    if (!visited.Contains(destination))
                    {
                        sum += CheckAllDestinations(destination, visited, 0, length + 1);
                    }
                }
                return sum;
            }
        }
    }
}