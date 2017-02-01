using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace rooted_tree
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
    public class Data<T>
    {
        public T Parent { get; set; }
        public T Value { get; set; }
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

    class Solution
    {
        static void Main(string[] args)
        {
#if DEBUG
            ExpectedResults xr = new ExpectedResults(0);
#endif
            int[] NER = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int N = NER[0]; // Number of nodes
            int E = NER[1]; // number of actions (queries) Update + Report
            int R = NER[2]; // Root (? index?)
            for (int i = 0; i < N; ++i)
            {
                // node numbers connected by edge
                int[] XY = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            }
        }
    }
}
