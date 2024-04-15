using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        TreeNode root = new TreeNode(0);
        root.left = new TreeNode(1);

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
            int num;
            Stack<(TreeNode, int)> stack = new();
            stack.Push((root, 0));

            while (stack.Count > 0)
            {
                var top = stack.Pop();
                root = top.Item1;
                num = top.Item2;

                if (root != null)
                {
                    num = (num * 10) + root.val;
                    if (root.left == null && root.right == null)
                    {
                        sum += num;
                    }
                    else
                    {
                        stack.Push((root.left, num));
                        stack.Push((root.right, num));
                    }
                }
            }
            return sum;
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

