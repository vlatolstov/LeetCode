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
        Console.WriteLine(sol.RemoveKdigits("10200", 1));
        Console.WriteLine(sol.RemoveKdigits("10", 2));
    }

    public class Solution
    {
        public string RemoveKdigits(string num, int k)
        {
            int min = int.Parse(num);
            for (int j = 0; j < k; j++)
            {
                StringBuilder sb = new(min.ToString());
                for (int i = 0; i < sb.Length; i++)
                {
                    var temp = sb[i];
                    sb.Remove(i, 1);
                    int curr = 0;
                    if (int.TryParse(sb.ToString(), out int result))
                    {
                        curr = result;
                    }
                    if (curr < min) min = curr;
                    sb.Insert(i, temp);
                }
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

