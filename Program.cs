﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

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

    }

    public class Solution
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            List<Path> paths = new();
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

            foreach (var way in graph)
            {
                Queue<Path> variations = new();
                List<Path> all = new();
                var path = new Path(way.Key, way.Key);
                //int maxHeight = 0;

                variations.Enqueue(path);
                path.visited.Add(way.Key);

                while (variations.Count > 0)
                {
                    int size = variations.Count;
                    for (int k = 0; k < size; k++)
                    {
                        var cur = variations.Dequeue();
                        //maxHeight = Math.Max(cur.height, maxHeight);
                        for (int u = 0; u < graph[cur.position].Count; u++)
                        {
                            if (!cur.visited.Contains(graph[cur.position][u]))
                            {
                                cur.visited.Add(u);
                                cur.height++;
                                cur.position = u;
                                variations.Enqueue(new Path(cur));
                            }
                        }
                        if (cur.visited.Count == graph[cur.position].Count)
                        {
                            all.Add(cur);
                        }
                    }
                }
                Path max = null;
                for (int y = 0; y < all.Count; y++)
                {
                    if (max == null) max = all[y];
                    else max = max.height > all[y].height ? max : all[y];
                }
                if (max != null) paths.Add(max);
            }

            int min = paths.Select(p => p.height).Min();
            return paths.Where(p => p.height == min).Select(p => p.root).ToList();
        }

        public class Path
        {
            public int root;
            public int height;
            public int position;
            public HashSet<int> visited = new();

            public Path(int r, int p)
            {
                root = r;
                position = p;
            }
            public Path(Path source)
            {
                root = source.root;
                height = source.height;
                position = source.position;
                visited = new HashSet<int>(source.visited);
            }
        }
    }
}

