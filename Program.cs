using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        Console.WriteLine(sol.SumNumbers(root));

        TreeNode root2 = new TreeNode(4);
        root2.left = new TreeNode(9);
        root2.right = new TreeNode(0);
        root2.left.left = new TreeNode(5);
        root2.left.right = new TreeNode(1);
        Console.WriteLine(sol.SumNumbers(root2));

    }

    public class Solution
    {
        public int SumNumbers(TreeNode root)
        {
            int sum = 0;
            var sb = new StringBuilder();
            SeqOfDigits(root, sb, new StringBuilder());
            string[] digits = sb.ToString().Split('-');
            foreach (var d in digits)
            {
                if (int.TryParse(d, out int i)) sum += i;
            }
            return sum;
        }

        StringBuilder SeqOfDigits(TreeNode root, StringBuilder all, StringBuilder curr)
        {
            switch (root.left == null, root.right == null)
            {
                case (true, true):
                    curr.Append(root.val);
                    curr.Append('-');
                    all.Append(curr);
                    curr.Remove(curr.Length - 2, 2);
                    break;
                case (false, true):
                    curr.Append(root.val);
                    SeqOfDigits(root.left, all, curr);
                    break;
                case (true, false):
                    curr.Append(root.val);
                    SeqOfDigits(root.right, all, curr);
                    break;
                case (false, false):
                    curr.Append(root.val);
                    SeqOfDigits(root.left, all, curr);
                    SeqOfDigits(root.right, all, curr);
                    break;
            }
            return curr;
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

