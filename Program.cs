using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        var case1 = new int[][]
        {
            new int[] {1, 0, 0},
            new int[] {0, 1, 1},
            new int[] {0, 1, 1}
        };
        var ans1 = sol.FindFarmland(case1);
        foreach (var place in ans1)
        {
            foreach (var coord in place)
            {
                Console.Write(coord + " ");
            }
            Console.WriteLine();
        }
        var case2 = new int[][]
        {
            new int[] {1, 1},
            new int[] {1, 1}
        };
        var ans2 = sol.FindFarmland(case2);
        foreach (var place in ans2)
        {
            foreach (var coord in place)
            {
                Console.Write(coord + " ");
            }
            Console.WriteLine();
        }
        var case3 = new int[][]
        {
            new int[] { 0 }
        };
        var ans3 = sol.FindFarmland(case3);
        foreach (var place in ans3)
        {
            foreach (var coord in place)
            {
                Console.Write(coord + " ");
            }
            Console.WriteLine();
        }

    }

    public class Solution
    {
        public int[][] FindFarmland(int[][] land)
        {
            List<int[]> res = new();

            for (int i = 0; i < land.Length; i++)
            {
                for (int j = 0; j < land[i].Length; j++)
                {
                    if (land[i][j] == 1)
                    {
                        var corners = new List<int> { i, j };
                        DFS(land, i, j, corners);
                        res.Add(corners.ToArray());
                    }
                }
            }
            return res.ToArray();
        }

        void DFS(int[][] land, int i, int j, List<int> corners)
        {
            if (i >= land.Length || j >= land[i].Length || land[i][j] != 1) return;

            land[i][j] = 2;

            if (((i + 1 < land.Length 
                && land[i + 1][j] != 1)
                || i == land.Length -1)
                && ((j + 1 < land[i].Length 
                && land[i][j + 1] != 1)
                || j == land[i].Length -1) 
                && corners.Count != 4)
            {
                corners.Add(i);
                corners.Add(j);
            }

            DFS(land, i, j + 1, corners);
            DFS(land, i + 1, j, corners);
        }
    }
}


