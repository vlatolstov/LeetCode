using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var sol = new Solution();

    }

    public class Solution
    {
        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> restrictions = new(deadends);
            HashSet<string> visited = new();
            Queue<string> queue = new();
            int move = 0;

            queue.Enqueue("0000");
            visited.Add("0000");

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    string curr = queue.Dequeue();
                    if (restrictions.Contains(curr)) continue;
                    if (curr == target) return move;

                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = -1; k <= 1; k += 2)
                        {
                            char[] currArr = curr.ToCharArray();
                            int digit = (currArr[j] - '0' + k + 10) % 10;
                            currArr[j] = (char)(digit + '0');
                            string next = new string(currArr);
                            if (!restrictions.Contains(next) && !visited.Contains(next))
                            {
                                queue.Enqueue(next);
                                visited.Add(next);
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}