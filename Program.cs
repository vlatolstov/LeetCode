using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        var matrix = new char[][] { new char[] { '1', '0', '1', '0', '0' }, new char[] { '1', '0', '1', '1', '1' }, new char[] { '1', '1', '1', '1', '1' }, new char[] { '1', '0', '0', '1', '0' } };
        Console.WriteLine(sol.MaximalRectangle(matrix));
        var matrix2 = new char[][] { new char[] { '1', '0', '1', '1', '1' }, new char[] { '0', '1', '0', '1', '0' }, new char[] { '1', '1', '0', '1', '1' }, new char[] { '1', '1', '0', '1', '1' }, new char[] { '0', '1', '1', '1', '1' } };
        Console.WriteLine(sol.MaximalRectangle(matrix2));
        var matrix3 = new char[][] { new char[] { '1', '1', '1', '1', '1', '1', '1', '1' }, new char[] { '1', '1', '1', '1', '1', '1', '1', '0' }, new char[] { '1', '1', '1', '1', '1', '1', '1', '0' }, new char[] { '1', '1', '1', '1', '1', '0', '0', '0' }, new char[] { '0', '1', '1', '1', '1', '0', '0', '0' } };
        Console.WriteLine(sol.MaximalRectangle(matrix3));
    }

}

class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return 0;
        }

        int numRows = matrix.Length;
        int numCols = matrix[0].Length;

        int maxArea = 0;
        int[] height = new int[numCols];

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                if (matrix[row][col] == '1')
                {
                    height[col]++;
                }
                else
                {
                    height[col] = 0;
                }
            }

            int area = LargestRectangleArea(height);
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }
    private int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;
        int n = heights.Length;

        for (int i = 0; i <= n; i++) 
        {
            while (stack.Count > 0 && (i == n || heights[stack.Peek()] >= heights[i]))
            {
                int h = heights[stack.Pop()];
                int w = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, h * w);
            }

            stack.Push(i); 
        }

        return maxArea;
    }
}

