using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        var grid = new int[][]
        {
            new int[]{ 0, 1, 0, 0 },
            new int[]{ 1, 1, 1, 0 },
            new int[]{ 0, 1, 0, 0 },
            new int[]{ 1, 1, 0, 0 }
        };
        Console.WriteLine(sol.IslandPerimeter(grid));

    }

    public class Solution
    {
        public int IslandPerimeter(int[][] grid)
        {
            int per = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) per = DFS(grid, i, j);
                }
                if (per > 0) break;
            }
            return per;
        }

        int DFS(int[][] grid, int i, int j)
        {
            int per = 4;
            grid[i][j] = 2;

            //up
            if (i > 0 && grid[i - 1][j] == 1)
            {
                per -= 2;
                per += DFS(grid, i - 1, j);
            }

            //right
            if (j < grid[i].Length - 1 && grid[i][j + 1] == 1)
            {
                per -= 2;
                per += DFS(grid, i, j + 1);
            }

            //down
            if (i < grid.Length - 1 && grid[i + 1][j] == 1)
            {
                per -= 2;
                per += DFS(grid, i + 1, j);
            }

            //left
            if (j > 0 && grid[i][j - 1] == 1)
            {
                per -= 2;
                per += DFS(grid, i, j - 1);
            }
            return per;
        }
    }


}
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public static TreeNode CreateTree(int?[] values, int index = 0)
    {
        if (index >= values.Length || values[index] == null)
        {
            return null;
        }
        TreeNode node = new TreeNode();
        node.left = CreateTree(values, 2 * index + 1);
        node.right = CreateTree(values, 2 * index + 2);
        node.val = (int)values[index];
        return node;
    }
}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

