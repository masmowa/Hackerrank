using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperStrings
{
    class Node
    {
        public Node left, right;
        public int data;
        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
    class Solution
    {
        static int countHeight(Node root, int direction)
        {
            int height = 0;
            if (root != null)
            {
                if (direction < 0)
                {
                    height = countHeight(root.right, direction);
                }
                else
                {
                    height = countHeight(root.left, direction);
                }
                height += 1;
            }
            return height;
        }
        static int getHeight(Node root)
        {
            int lheight = 0;
            int rheight = 0;
            if (root == null)
            {
                return -1;
            }
            rheight = getHeight(root.right);
            lheight = getHeight(root.left);
            return ((rheight > lheight) ? rheight : lheight) + 1;
        }

        static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }
        static void Main(String[] args)
        {
            Node root = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
            }
            int height = getHeight(root);
            Console.WriteLine(height);

        }
    }
}
