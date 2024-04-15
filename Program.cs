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

            var digits = SeqOfDigits(root, new List<int>(), 0);
            foreach (var d in digits)
            {
                sum += d;
            }
            return sum;
        }

        List<int> SeqOfDigits(TreeNode root, List<int> digits, int curr)
        {
            curr = (curr * 10) + root.val;
            switch (root.left == null, root.right == null)
            {
                case (true, true):
                    digits.Add(curr);
                    break;
                case (false, true):
                    SeqOfDigits(root.left, digits, curr);
                    break;
                case (true, false):
                    SeqOfDigits(root.right, digits, curr);
                    break;
                case (false, false):
                    SeqOfDigits(root.left, digits, curr);
                    SeqOfDigits(root.right, digits, curr);
                    break;
            }
            return digits;
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

