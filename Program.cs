using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();



    }

    public class Solution
    {
        public string SmallestFromLeaf(TreeNode root)
        {
            Stack<int> vals = new();
            vals.Push(root.val);
            if (root.left == null && root.right == null) return FromValsToString(vals);

            int depth = 0;
        }

        string FromValsToString(Stack<int> vals)
        {
            StringBuilder sb = new();
            while (vals.Count > 0) sb.Append((char)(vals.Pop() + 97));
            return sb.ToString();
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

