using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        var tree = TreeNode.CreateTree(new int[] { 0, 1, 2, 3, 4, 3, 4 });
        Console.WriteLine(sol.SmallestFromLeaf(tree));
    }

    public class Solution
    {
        string smallestString = null;
        public string SmallestFromLeaf(TreeNode root)
        {
            DFS(root);
            return smallestString;
        }

        void DFS(TreeNode node, string current = "")
        {
            if (node == null) return;

            char currentChar = (char)(node.val + 97);
            current = currentChar + current;

            if (node.left == null || node.right == null)
            {
                SmallestCheck(current);
            }

            DFS(node.left, current);
            DFS(node.right, current);
        }

        void SmallestCheck(string current)
        {
            if (smallestString == null || string.Compare(current, smallestString) < 0)
            {
                smallestString = current;
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

    public static TreeNode CreateTree(int[] values, int index = 0)
    {
        if (index >= values.Length)
        {
            return null;
        }

        TreeNode node = new TreeNode(values[index]);
        node.left = CreateTree(values, 2 * index + 1);
        node.right = CreateTree(values, 2 * index + 2);
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

