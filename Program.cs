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
            int t = int.Parse(target);
            int move = 0;
            bool[] restr = new bool[10000];
            foreach (var end in deadends)
            {
                restr[int.Parse(end)] = true;
            }

            Queue<int> q = new();
            if (!restr[0])
            {
                q.Enqueue(0);
                restr[0] = true;
            }

            while(q.Count > 0)
            {
                int size = q.Count;

                for (int i = 0; i < size; i++)
                {
                    int scale = 1;
                    int cur = q.Dequeue();
                    if (cur == t) return move;

                    for (int j = 0; j < 4; j++)
                    {
                        int digit = (cur % (scale * 10)) / scale;
                        int dec = cur + (digit == 0 ? 9 : -1) * scale;
                        int inc = cur + (digit == 9 ? -9 : 1) * scale;

                        if (!restr[dec])
                        {
                            q.Enqueue(dec);
                            restr[dec] = true;
                        }

                        if (!restr[inc])
                        {
                            q.Enqueue(inc);
                            restr[inc] = true;
                        }
                        scale *= 10;
                    }
                }
                move++;
            }
            return -1;
        }
    }
}