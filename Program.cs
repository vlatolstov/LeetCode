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

        int[][] matrix = new int[][] {
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
        Console.WriteLine(sol.MinFallingPathSum(matrix));

    }

    public class Solution
    {
        public int MinFallingPathSum(int[][] grid)
        {
            int length = grid.Length;
            if (length == 0) return 0;
            if (length == 1) return grid[0].Min();

            int minSum = int.MaxValue;

            for (int i = 0; i < length; i++)
            {
                DFS(0, i, 0);
            }

            return minSum;

            void DFS(int curRaw, int curCol, int curSum)
            {
                //if (curSum > minSum) return;
                if (curRaw >= length)
                {
                    minSum = minSum < curSum ? minSum : curSum;
                    return;
                }
                curSum += grid[curRaw][curCol];
                for (int i = 0; i < length; i++)
                {
                    if (i != curCol) DFS(curRaw + 1, i, curSum);
                }
            }
        }
    }
}

