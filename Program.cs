using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);
        Console.WriteLine(sol.SumOfLeftLeaves(root));
    }

    public class Solution
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            int sum = 0;
            if (root.left != null) sum += LeftLeafSearchAndCount(root.left, true);
            if (root.right != null)  sum += LeftLeafSearchAndCount(root.right, false);
            return sum;
        }

        int LeftLeafSearchAndCount(TreeNode node, bool currIsLeft)
        {
            int currSum = 0;
            var curr = node;
            switch (curr.left == null, curr.right == null)
            {
                case (true, true):
                    if (currIsLeft) currSum += curr.val;
                    break;
                case (true, false):
                    currSum += LeftLeafSearchAndCount(curr.right, false);
                    break;
                case (false, true):
                    currSum += LeftLeafSearchAndCount(curr.left, true);
                    break;
                case (false, false):
                    currSum += LeftLeafSearchAndCount(curr.left, true);
                    currSum += LeftLeafSearchAndCount(curr.right, false);
                    break;
            };
            return currSum;
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

