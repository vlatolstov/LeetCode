using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

        Console.WriteLine(sol.Tribonacci(4));
        Console.WriteLine(sol.Tribonacci(25));
    }

    public class Solution
    {
        //The Tribonacci sequence Tn is defined as follows: 
        //T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0. 
        public int Tribonacci(int n)
        {
            List<int> list = new() { 0, 1, 1 };

            for (int i = 2; i <= n; i++)
            {
                list.Add(list[i] + list[i - 1] + list[i - 2]);
            }

            return list[n];
        }
    }
}