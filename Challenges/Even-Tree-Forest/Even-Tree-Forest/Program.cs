using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_Tree_Forest
{
    public static class IsDebug
    {
        public static bool V
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }

#if DEBUG
    public class ExpectedResults
    {
        public List<int> R;
        //protected static string EXPECTED_FILE = "output01.txt";
        public ExpectedResults(int t)
        {
            string file = string.Format("output{0:00}.txt", t);
            Console.WriteLine("expected results file name: {0}", file);
            string[] expectedLines = File.ReadAllLines(file);
            R = new List<int>(expectedLines.Length);
            foreach (string s in expectedLines)
            {
                R.Add(Convert.ToInt32(s));
            }

        }
        public bool IsMatch(int index, int val)
        {
            return (R[index] == val);
        }
    }
#endif

    public class NodeData<T>
    {
        public T Parent { get; set; }
        public T Val { get; set; }
        public int Count { get; set; }
        public NodeData(T parent, T value)
        {
            Parent = parent;
            Val = value;

        }
    }
    public class Node<T>
    {
        // Private member-variables
        private T data;
        private NodeList<T> neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }
    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }
    public class NTreeNode<T> : Node<T>
    {
        public NTreeNode() : base() { }
        public NTreeNode(T data) : base(data, null) { }
        public NTreeNode(T data, NTreeNode<T> left, NTreeNode<T> right)
        {
            base.Value = data;
            NodeList<T> children = new NodeList<T>(3);
            children[0] = left;
            children[1] = right;
            
            base.Neighbors = children;
        }

        public NTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (NTreeNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[0] = value;
            }
        }

        public NTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (NTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(3);

                base.Neighbors[1] = value;
            }
        }
    }

    class Solution
    {
        static void Main(string[] args)
        {
#if DEBUG
            ExpectedResults xr = new ExpectedResults(0);
#endif
            int[] NM = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int N = NM[0];
            int M = NM[1];
            for (int m = 0; m < M; ++m)
            {
                int[] edge = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                //edges.Add(edge[0], edge[1]);
                if (IsDebug.V)
                {
#if DEBUG
                    string IsPass = "FAIL";
                    if (xr.IsMatch(0, count))
                    {
                        IsPass = "PASS";
                    }
                    Console.WriteLine("expected: {0:d} actual: {1:d} {2}", xr.R[0], count, IsPass);
#endif
                }
#if true
                Console.Write(count);
#endif
            }
        }
    }
}
