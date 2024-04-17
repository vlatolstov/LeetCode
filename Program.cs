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

        //string x = "1,2,3,4,5";
        //var nums = x.Split(',');

        //Array.ConvertAll<string, int>(nums, new Converter<string, int>(StringToInt));




    }

    public class Solution
    {
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            List<IList<int>> result = new();
            DFS(root, "");
            return result;

            void DFS(TreeNode node, string currPath, int currSum = 0)
            {
                if (node == null) return;
                currPath += node.val.ToString();
                currSum += node.val;

                if (node.left == null && node.right == null)
                {
                    if (currSum == targetSum)
                    {
                        result.Add(
                            new List<int>(
                                Array.ConvertAll<string, int>(
                                currPath.Split(','), new Converter<string, int>(StringToInt))));
                    }
                }
                currPath += ',';
                DFS(node.left, currPath, currSum);
                DFS(node.right, currPath, currSum);

                int StringToInt(string str)
                {
                    return int.Parse(str);
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

