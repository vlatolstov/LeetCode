using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        var case1 = new char[][]
        {
            new char[] {'1', }
        }


    }

    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            int count = 0;
            //edge cases check
            if (grid == null || grid.Length == 0) return count;

            //spots iterator
            for (int m = 0; m < grid.Length; m++)
            {
                for (int n = 0; n < grid[m].Length; n++)
                {
                    if (grid[m][n] == '1') //island found
                    {
                        count++;
                        MarkIsland(ref grid, m, n); //mark all connected land in reccursive way
                    }
                }
            }
            return count;


            void MarkIsland(ref char[][] grid, int m, int n)
            {
                if (grid[m][n] == '1')
                {
                    grid[m][n] = '2';
                    //up
                    if (m > 0) MarkIsland(ref grid, m - 1, n);
                    //down
                    if (m < grid.Length - 1) MarkIsland(ref grid, m + 1, n);
                    //left
                    if (n > 0) MarkIsland(ref grid, m, n - 1);
                    //right
                    if (n < grid[m].Length - 1) MarkIsland(ref grid, m, n + 1);
                }
                else return;
            }
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

