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
        public ListNode RemoveNodes(ListNode head)
        {
            var nodes = new List<ListNode>();

            while (head != null)
            {
                nodes.Add(head);
                head = head.next;
            }

            var willStay = new bool[nodes.Count];
            int max = 0;
            for (int i = nodes.Count - 1; i >=0; i--)
            {
                if (nodes[i].val >= max)
                {
                    max = Math.Max(nodes[i].val, max);
                    willStay[i] = true;
                }
            }

            ListNode answer = null;
            ListNode cur = null;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (willStay[i])
                {
                    if (answer == null)
                    {
                        answer = nodes[i];
                        cur = answer;
                    }
                    else
                    {
                        cur.next = nodes[i];
                        cur = cur.next;
                    }
                }
            }

            return answer;
        }
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

