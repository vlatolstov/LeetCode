using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        Console.WriteLine(sol.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
        Console.WriteLine(sol.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
        Console.WriteLine(sol.FindMedianSortedArrays(new int[] { 1, 2 }, Array.Empty<int>()));

    }

    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int f = 0;
            int s = 0;
            int[] sum = new int[nums1.Length + nums2.Length];
            int midIndex = sum.Length / 2;

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = (f < nums1.Length, s < nums2.Length) switch
                {
                    (true, true) => nums1[f] > nums2[s] == true ? nums2[s++] : nums1[f++],
                    (false, true) => nums2[s++],
                    (true, false) => nums1[f++],
                    _ => 0
                };
            }

            if (sum.Length % 2 == 0)
            {
                return (double)(sum[midIndex] + sum[midIndex - 1]) / 2;
            }
            else return (double)sum[midIndex];
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

