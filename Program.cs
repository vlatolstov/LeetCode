using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        var case1 = new int[] 
        { 2, 1, 3, 4 };
        Console.WriteLine(sol.MinOperations(case1, 1));

        var case2 = new int[] 
        { 2, 0, 2, 0 };
        Console.WriteLine(sol.MinOperations(case2, 0));


    }

    public class Solution
    {
        public int MinOperations(int[] nums, int k)
        {

            int XOR = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                XOR ^= nums[i];
            }

            string difference = Convert(XOR ^ k);

            int result = 0;
            for (int i = 0; i < difference.Length; i++)
            {
                if (difference[i] == '1') result++;
            }

            return result;

            static string Convert(int x)
            {
                if (x == 0) return new string("0");
                List<char> l = new();
                while (x > 0)
                {
                    l.Add((char)((x % 2) + 48));
                    x /= 2;
                }
                l.Reverse();
                return String.Concat(l);
            }
        }
    }
}