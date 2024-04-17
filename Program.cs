using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        var tree1 = TreeNode.CreateTree(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1 });
        foreach (var list in sol.PathSum(tree1, 22))
        {
            foreach (int num in list) Console.Write(num + ",");
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");

        var tree2 = TreeNode.CreateTree(new int?[] { 1, 2, 3 });
        foreach (var list in sol.PathSum(tree2, 5))
        {
            foreach (int num in list) Console.Write(num + ",");
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");

        var tree3 = TreeNode.CreateTree(new int?[] { 1, 2 });
        foreach (var list in sol.PathSum(tree3, 0))
        {
            foreach (int num in list) Console.Write(num + ",");
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");

        var tree4 = TreeNode.CreateTree(new int?[0]);
        foreach (var list in sol.PathSum(tree4, 1))
        {
            foreach (int num in list) Console.Write(num + ",");
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");

    }

    public class Solution
    {
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            List<IList<int>> result = new();
            List<int> path = new();
            if (root == null) return result;
            else path.Add(root.val);
            DFS(root, root.val);
            return result;



            void DFS(TreeNode node, int currSum)
            {
                if (node.left == null && node.right == null && currSum == targetSum)
                {
                    List<int> temp = new();
                    temp.AddRange(path);
                    result.Add(temp);
                }

                if (node.left != null)
                {
                    path.Add(node.left.val);
                    DFS(node.left, currSum + node.left.val);
                    path.RemoveAt(path.Count - 1);
                }
                if (node.right != null)
                {
                    path.Add(node.right.val);
                    DFS(node.right, currSum + node.right.val);
                    path.RemoveAt(path.Count - 1);
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

        public static TreeNode CreateTree(int?[] values, int index = 0)
        {
            if (index >= values.Length || values[index] == null)
            {
                return null;
            }
            TreeNode node = new TreeNode();
            node.left = CreateTree(values, 2 * index + 1);
            node.right = CreateTree(values, 2 * index + 2);
            node.val = (int)values[index];
            return node;
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
}

