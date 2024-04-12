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
            int traped = 0;
            for (int i = 0; i < height.Length; i++)
            {
                traped += SpotCheck(height, i);
            }
            return traped;
        }

        int SpotCheck(int[] arr, int i)
        {
            int leftI = i;
            int leftH = 0;
            int rightI = i;
            int rightH = 0;
            int spot = arr[i];

            if (i == 0 || i == arr.Length - 1) return 0;
            while (leftI != 0)
            {
                leftI--;
                if (arr[leftI] > leftH && arr[leftI] > spot) leftH = arr[leftI];
            }
            while (rightI != arr.Length - 1)
            {
                rightI++;
                if (arr[rightI] > rightH && arr[rightI] > spot) rightH = arr[rightI];
            }
            if (leftH <= spot || rightH <= spot) return 0;
            var height = leftH > rightH ? rightH : leftH;
            return height - spot;
        }
    }



}