using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        Console.WriteLine(sol.MinFallingPathSum(new int[][]
        { new int[] { 1,2,3},
        new int[] { 4,5,6},
        new int[] { 7,8,9},
        }));
        Console.WriteLine(sol.MinFallingPathSum(new int[][]
        { new int[] { 7}
        }));
        int[][] matrix = new int[][]
{
    new int[] { -73, 61, 43, -48, -36 },
    new int[] { 3, 30, 27, 57, 10 },
    new int[] { 96, -76, 84, 59, -15 },
    new int[] { 5, -49, 76, 31, -7 },
    new int[] { 97, 91, 61, -46, 67 }
};
        Console.WriteLine(sol.MinFallingPathSum(matrix));
        int[][] matrix2 = new int[][] {
    new int[] { -2, -18, 31, -10, -71, 82, 47, 56, -14, 42 },
    new int[] { -95, 3, 65, -7, 64, 75, -51, 97, -66, -28 },
    new int[] { 36, 3, -62, 38, 15, 51, -58, -90, -23, -63 },
    new int[] { 58, -26, -42, -66, 21, 99, -94, -95, -90, 89 },
    new int[] { 83, -66, -42, -45, 43, 85, 51, -86, 65, -39 },
    new int[] { 56, 9, 9, 95, -56, -77, -2, 20, 78, 17 },
    new int[] { 78, -13, -55, 55, -7, 43, -98, -89, 38, 90 },
    new int[] { 32, 44, -47, 81, -1, -55, -5, 16, -81, 17 },
    new int[] { -87, 82, 2, 86, -88, -58, -91, -79, 44, -9 },
    new int[] { -96, -14, -52, -8, 12, 38, 84, 77, -51, 52 }
};
        Console.WriteLine(sol.MinFallingPathSum(matrix2));

        int[][] matrix3 = new int[][]
    {
    new int[] { 50, -18, -38, 39, -20, -37, -61, 72, 22, 79 },
    new int[] { 82, 26, 30, -96, -1, 28, 87, 94, 34, -89 },
    new int[] { 55, -50, 20, 76, -50, 59, -58, 85, 83, -83 },
    new int[] { 39, 65, -68, 89, -62, -53, 74, 2, -70, -90 },
    new int[] { 1, 57, -70, 83, -91, -32, -13, 49, -11, 58 },
    new int[] { -55, 83, 60, -12, -90, -37, -36, -27, -19, -6 },
    new int[] { 76, -53, 78, 90, 70, 62, -81, -94, -32, -57 },
    new int[] { -32, -85, 81, 25, 80, 90, -24, 10, 27, -55 },
    new int[] { 39, 54, 39, 34, -45, 17, -2, -61, -81, 85 },
    new int[] { -77, 65, 76, 92, 21, 68, 78, -13, 39, 22 }
    };
        Console.WriteLine(sol.MinFallingPathSum(matrix3)); //-807
    }



    public class Solution
    {
        public int MinFallingPathSum(int[][] grid)
        {
            int length = grid.Length;
            if (length == 0) return 0;
            if (length == 1) return grid[0].Min();

            int minSum = int.MaxValue;

            Dictionary<int, Dictionary<int, int>> graph = new();

            for (int i = 0; i < length; i++)
            {
                graph.Add(i, new Dictionary<int, int>());
                for (int j = 0; j < length; j++)
                {
                    graph[i].Add(j, grid[i][j]);
                }
            }

            foreach (var raw in graph)
            {
                var cur = raw.Value.OrderBy(r => r.Value).FirstOrDefault();
                SumOfOtherRaws(raw.Key, cur.Key, cur.Value);
            }

            return minSum;


            void SumOfOtherRaws(int curRaw, int curCol, int curSum)
            {
                int skip = curCol;
                for (int j = curRaw; j < length; j++)
                {
                    if (j == curRaw) continue;
                    else
                    {
                        var raw = graph[j].Where(r => r.Key != skip).OrderBy(r => r.Value).FirstOrDefault();
                        curSum += raw.Value;
                        skip = raw.Key;
                    }
                }

                skip = curCol;
                for (int j = curRaw; j >= 0; j--)
                {
                    if (j == curRaw) continue;
                    else
                    {
                        var raw = graph[j].Where(r => r.Key != skip).OrderBy(r => r.Value).FirstOrDefault();
                        curSum += raw.Value;
                        skip = raw.Key;
                    }
                }

                minSum = Math.Min(curSum, minSum);
            }
        }
    }
}

