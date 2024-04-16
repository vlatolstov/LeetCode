using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        sol.AddOneRow(TreeNode.CreateTree(new int[] { 4, 2, 6, 3, 1, 5 }), 1, 1);


    }

    public class Solution
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            return AddingToTheDepth(root, val, depth - 1);
        }
        TreeNode AddingToTheDepth(TreeNode node, int val, int depth)
        {
            int curDepth = depth - 1;
            if (curDepth == 0)
            {
                var leftTemp = node.left;
                var rightTemp = node.right;
                node.left = new TreeNode(val, leftTemp);
                node.right = new TreeNode(val, null, rightTemp);
            }
            else if (curDepth < 0)
            {
                return new TreeNode(val, node);
            }
            else
            {
                switch (node.left == null, node.right == null)
                {
                    case (true, true):
                        break;
                    case (false, true):
                        AddingToTheDepth(node.left, val, curDepth);
                        break;
                    case (true, false):
                        AddingToTheDepth(node.right, val, curDepth);
                        break;
                    case (false, false):
                        AddingToTheDepth(node.left, val, curDepth);
                        AddingToTheDepth(node.right, val, curDepth);
                        break;
                }
            }
            return node;
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
        if (index >= values.Length || values[index] == null)
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


