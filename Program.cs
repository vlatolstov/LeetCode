using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        Console.WriteLine(sol.RemoveKdigits("1432219", 3));
    }

    public class Solution
    {
        public string RemoveKdigits(string num, int k)
        {

            int min = int.Parse(num);

            for (int i = 0; i <= num.Length - k; i++)
            {
                List<char> temp = num.ToCharArray().ToList();
                for (int j = i; j < i + k; j++)
                {
                    temp.RemoveAt(j);
                }
                var curr = int.Parse(new string(temp));
                if (curr < min) min = curr;
            }

            return min.ToString();
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

