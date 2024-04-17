using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        var tree1 = TreeNode.CreateTree(new int?[] { 1, 2, 3, null, 5 });
        foreach (var str in sol.BinaryTreePaths(tree1)) Console.Write(str + ", ");
        Console.WriteLine();
        var tree2 = TreeNode.CreateTree(new int?[] { 1 });
        foreach (var str in sol.BinaryTreePaths(tree2)) Console.Write(str + ", ");
    }

    public class Solution
    {
        readonly string sep = "->";

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> answers = new();
            DFS(root, "");
            return answers;

            void DFS(TreeNode node, string cur)
            {
                if (node == null) return;
                if (cur == String.Empty) cur += node.val;
                else cur += sep + node.val;

                if (node.left == null && node.right == null) answers.Add(cur);

                DFS(node.left, cur);
                DFS(node.right, cur);
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

