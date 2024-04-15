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
            int midInd;

            switch (nums1.Length > 0, nums2.Length > 0)
            {
                case (false, false):
                    return 0d;
                case (false, true):
                    midInd = nums2.Length / 2;
                    if (nums2.Length % 2 == 0) return nums2[midInd];
                    else return ((double)(nums2[midInd] + nums2[midInd + 1])) / 2;
                case (true, false):
                    midInd = nums1.Length / 2;
                    if (nums1.Length % 2 == 0) return nums1[midInd];
                    else return ((double)(nums1[midInd] + nums1[midInd + 1])) / 2;
                case (true, true):
                    int sumLength = nums1.Length + nums2.Length;
                    for (int i = 0; i < (sumLength / 2); i++)
                    {
                        switch (f < nums1.Length, s < nums2.Length)
                        {
                            case (true, true):
                                if (nums1[f] >= nums2[s]) s++;
                                else f++;
                                break;
                            case (false, true):
                                s++;
                                break;
                            case (true, false):
                                f++;
                                break;
                            default:
                                throw new Exception("wat");
                        };
                    }
                    if (f >= nums1.Length)
                    {
                        return sumLength % 2 == 0 ? ((double)(nums2[s] + nums2[s + 1])) / 2 : (double)nums2[s];
                    }
                    if (s >= nums2.Length)
                    {
                        return sumLength % 2 == 0 ? ((double)(nums1[f] + nums1[f + 1])) / 2 : (double)nums1[f];
                    }
                    else
                    {
                        if (sumLength % 2 == 0)
                        {
                            return ((double)(nums1[f] + nums2[s])) / 2;
                        }
                        else
                        {
                            return f > s == true ? nums2[s] : nums1[f];
                        }
                    }

            }
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

