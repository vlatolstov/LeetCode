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
        public string FindLatestTime(string s)
        {
            StringBuilder sb = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '?')
                {
                    switch (i)
                    {
                        case 0:
                            if (s[i + 1] <= '1' || s[i + 1] == '?') sb.Append('1');
                            else sb.Append('0');
                            break;
                        case 1:
                            if (sb[0] == '0') sb.Append('9');
                            else sb.Append('1');
                            break;
                        case 3:
                            sb.Append('5');
                            break;
                        case 4:
                            sb.Append('9');
                            break;
                    }
                }
                else sb.Append(s[i]);
            }
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

