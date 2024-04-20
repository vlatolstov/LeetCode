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
                        res.Add(FindCorners(land, i, j));
                    }
                }
            }
            return res.ToArray();
        }

        int[] FindCorners(int[][] land, int x, int y)
        {
            int dx = x;
            int dy = y;

            while (dx < land.Length - 1 && land[dx + 1][dy] == 1) dx++;
            while (dy < land[dx].Length - 1 && land[dx][dy + 1] == 1) dy++;

            for (int i = x; i <= dx; i++)
            {
                for (int j = y; j <= dy; j++)
                {
                    land[i][j] = 0;
                }
            }
            return new int[] { x, y, dx, dy };
        }
    }
}


