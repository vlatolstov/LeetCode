using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();


        //case1
        var x = new int[] { 1, 2, 3, 0, 0, 0 };
        var y = new int[] { 4, 5, 6 };
        sol.Merge(x, 3, y, 3);
        foreach (int i in x)
        {
            Console.Write(i + " ");
        };
        Console.WriteLine();
        //case2
        x = new int[] { 1, 2, 3, 4, 0, 0, 0 };
        y = new int[] { -50, 4, 754 };
        sol.Merge(x, 4, y, 3);
        foreach (int i in x)
        {
            Console.Write(i + " ");
        };
        Console.WriteLine();
        //case3
        x = new int[] { 4, 5, 6, 0, 0, 0 };
        y = new int[] { 1, 2, 3 };
        sol.Merge(x, 3, y, 3);
        foreach (int i in x)
        {
            Console.Write(i + " ");
        };

    }

    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int insertions = 0;
            int step = 0;
            int i = 0;
            int j = 0;
            while (insertions != n)
            {
                if (nums1[i] == nums2[j] || nums1[i] > nums2[j])
                {
                    Insert(nums1, i, nums2[j]);
                    insertions++;
                    i += 2;
                    j++;
                    step++;
                }
                else if (step >= m)
                {
                    nums1[i] = nums2[j];
                    insertions++;
                    i++;
                    j++;
                }
                else
                {
                    i++;
                    step++;
                }
                if (i > nums1.Length - 1) i = nums1.Length - 1;
            }
        }

        int[] Insert(int[] arr, int atIndex, int insert)
        {
            if (atIndex > arr.Length - 1) atIndex = arr.Length - 1;
            for (int i = arr.Length - 1; i > atIndex; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[atIndex] = insert;
            return arr;
        }
    }

    int[] Insert(int[] arr, int atIndex, int insert)
        {
            if (atIndex > arr.Length - 1) atIndex = arr.Length - 1;
            for (int i = arr.Length - 1; i > atIndex; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[atIndex] = insert;
            return arr;
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

