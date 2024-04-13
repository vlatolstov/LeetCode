using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();
        var matrix = new char[][] { new char[] { '1', '0', '1', '0', '0' }, new char[] { '1', '0', '1', '1', '1' }, new char[] { '1', '1', '1', '1', '1' }, new char[] { '1', '0', '0', '1', '0' } };
        Console.WriteLine(sol.MaximalRectangle(matrix));

    }


    public class Solution
    {
        public int MaximalRectangle(char[][] matrix)
        {
            int maxSqr = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        int lenght = 1;
                        int width = 1;
                        int x = i + 1;
                        int y = j + 1;

                        while (y < matrix[i].Length && matrix[i][y] == '1')
                        {
                            lenght++;
                            y++;
                        }

                        while (x < matrix.Length && matrix[x][j] == '1')
                        {
                            bool sameLenght = true;
                            for (int k = j; k < lenght; k++)
                            {
                                if (matrix[x][k] != '1')
                                {
                                    sameLenght = false;
                                }
                            }
                            if (!sameLenght) break;
                            else
                            {
                                width++;
                                x++;
                            }
                        }
                        int currSqr = lenght * width;
                        if (currSqr > maxSqr) maxSqr = currSqr;
                    }
                }
            }
            return maxSqr;
        }
    }
}

