using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16_LinkedList
{
    class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }

    }
    class Solution
    {
        public static Node insert(Node head, int data)
        {
            //Complete this method
            Node here = head;
            Node toInsert = new Node(data);

            if (here == null)
            {
                head = toInsert;
            }
            else
            {
                for (here = head; here != null; here = here.next)
                {
                    if (here.next == null)
                    {
                        here.next = toInsert;
                        break;
                    }
                }
            }
            return head;
        }
        public static void display(Node head)
        {
            Node start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }
        static void Main(string[] args)
        {

            Node head = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                head = insert(head, data);
            }
            display(head);
        }
    }
}
