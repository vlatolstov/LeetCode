using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        Console.WriteLine(sol.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        Console.WriteLine(sol.Trap(new int[] { 4, 2, 0, 3, 2, 5 }));

    }

    public class Solution
    {
        public int Trap(int[] height)
        {
            int drops = 0;

            //finding the val and ind of max height
            List<int> list = new(height);
            int max = list.Max(); 
            int maxI = list.FindIndex(i => i == max);
            
            //lower bound between this and max
            int bound = 0;

            //from start 
            int i = 0;
            while (i != maxI)
            {
                if (height[i] < bound) drops += bound - height[i];
                if (height[i] > bound) bound = height[i];
                i++;
            }

            //from end
            i = height.Length - 1;
            bound = 0;
            while (i > maxI)
            {
                if (height[i] < bound) drops += bound - height[i];
                if (height[i] > bound) bound = height[i];
                i--;
            }
            return drops;
        }
    }



}