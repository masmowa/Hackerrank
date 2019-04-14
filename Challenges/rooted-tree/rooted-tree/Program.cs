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
    public class Data
    {
        public Data() {}
        public Data(int parentId, int thisId) { ParentID = parentId; ID = thisId; Count = 0; }
        public Data(int parentId, int thisId, int count) { ParentID = parentId; ID = thisId; Count = count; }
        public int ParentID { get; set; }
        public int Value { get; set; }
        public int ID { get; set; }
        public int Count { get; set; }

        override public string ToString() { return string.Format("{0:d} -> {1:d}.V = {2:d}", ParentID, ID, Value); }
    }
    public class Node<T> : Data
    {
        // Private member-variables
        private NodeList<T> children = null;
        public Node<T> Parent = null;

        public Node() { }
        public Node(Data data) : this(data, null, null) { }
        public Node(Data data, Node<T> parent) : this(data, parent, null) { }
        public Node(Data data, Node<T> parent, NodeList<T> children)
        {
            this.Parent = parent;
            this.data = data;
            this.children = children;
        }

        public Data data {
            get {
                return this;
            }
            set
            {
                this.ParentID = value.ParentID;
                this.Value = value.Value;
                this.ID = value.ID;
                this.Count = value.Count;
            }
        }
        protected NodeList<T> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }
        public void AddChild(Data data)
        {
            Node<T> node = new Node<T>(data, this);
            if (this.Children == null)
            {
                this.Children = new NodeList<T>();
            }
            if (IsDebug.V)
            {
                Console.WriteLine(this.ID + ".AddChild(" + node.ID + ")");
            }
            this.Children.Add(node);
        }
        public Node<T> InsertChild(Data data, int parentId)
        {
            if (IsDebug.V)
            {
                Console.WriteLine("[" + this.ID + "].InsertChild(" + data + ", " + parentId + ")");
            }
            Node<T> where = FindById(parentId);
            if (where != null && where.ID.Equals(parentId))
            {
                where.AddChild(data);
            }
            return where;
        }
        public Node<T> FindById(int id)
        {
            if (IsDebug.V)
            {
                Console.WriteLine("this[" + this.ID +"].FindById(" + id + ")");
            }
            Node<T> n = this;
            while (n != null)
            {
                if (n.ID.Equals(id))
                {
                    break;
                }
                if (n.Children != null)
                {
                    foreach (Node<T> node in n.Children)
                    {
                        n = node.FindById(id);
                        if (n != null && n.ID.Equals(id))
                        {
                            break;
                        }
                    }
                }
                else if (!n.ID.Equals(id)) {
                    // no children and not a match
                    break;
                }
            }
            return n;
        }
        public void Update(int distance, int V, int K)
        {
            int oldv = this.Value;
            this.Value += V + (distance * K);
            if (IsDebug.V)
            {
                Console.WriteLine("[" + this.ID + "].Value[" + oldv + "] => [" + this.Value + "]");
            }
        }
        public void UpdeChildren(int distance, int V, int K)
        {
            if (this.Children != null)
            {
                foreach (Node<T> node in this.Children)
                {
                    node.Update(distance + 1, V, K);
                    node.UpdeChildren(distance + 1, V, K);
                }
            }
        }
        /// <summary>
        /// Update
        /// update it's value by adding V + d*K, 
        /// where V and K are the parameters of the query 
        /// and d is the distance of the node from T. 
        /// Note that V is added to node T.
        /// </summary>
        /// <param name="nodeId">search for this node</param>
        /// <param name="V">add V to node value</param>
        /// <param name="K">konstant value</param>
        public void UpdateAction(int nodeId, int V, int K)
        {
            Node<T> start = this.FindById(nodeId);
            int distance = 0;
            start.UpdeChildren(distance, V, K);
            start.Update(distance, V, K);
        }
        public int SumChildren(int endId)
        {
            int result = 0;
            if (this.Children != null)
            {
                foreach (Node<T> n in this.Children)
                {
                    if (n.ID <= endId)
                    {
                        result += n.SumChildren(endId);
                        result += n.Value;
                    }
                }

            }
            return result;
        }
        protected void Report()
        {
            Console.Write(" " + this.ID + ":" + this.Value);
        }
        protected void ReportChildren()
        {
            if (this.Children != null)
            {
                foreach (Node<T> node in this.Children)
                {
                    node.Report();
                    node.ReportChildren();
                }
            }

        }
        protected void ReportValues()
        {
            Console.Write("[" + this.ID + ":" + this.Value);
            this.ReportChildren();
            Console.WriteLine("]");


        }
        public void Query(int startId, int endId)
        {
            int result = 0;
            if (IsDebug.V)
            {
                this.ReportValues();
            }
            Node<T> n = this.FindById(endId);
            if (n != null)
            {
                while (n.ID != startId)
                {
                    result += n.Value;
                    n = n.Parent;
                }
            }
            Console.WriteLine(result);
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
        public Node<T> FindById(int id)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.ID.Equals(id))
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
            ExpectedResults xr = new ExpectedResults(15);
#endif
            int[] NAR = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            //  N is the number of nodes present, 
            // E is the total number of queries (update + report), and R is root of the tree.
            int N = NAR[0]; // Number of nodes
            int A = NAR[1]; // number of Actions (queries) Update + Report
            int R = NAR[2]; // Root (ID)
            if (IsDebug.V)
            {
                Console.WriteLine(string.Join(" ", NAR));
            }

            Data d = new Data(0, R);
            Node<int> root = new Node<int>(d);

            if (IsDebug.V)
            {
                Console.WriteLine("build tree with " + N + " nodes");
            }
            // note, since root is 1, and there are 6 entries, begin counting at 1
            for (int i = 1; i < N; ++i)
            {
                string line = Console.ReadLine();
                if (IsDebug.V)
                {
                    Console.WriteLine("Input [" + line + "]");
                }
                string[] vals = line.Split(' ');
                int[] NC = line.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                // node numbers connected by edge
                //int[] NC = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                if (root != null)
                {
                    Data data = new Data(NC[0], NC[1]);
                    //Node < int > node = new Node<int>(data, root);
                    root.InsertChild(data, NC[0]);
                }

            }
            if (IsDebug.V)
            {
                Console.WriteLine("Read " + A + " Actions");
            }
            for (int j = 0; j < A; ++j)
            {
                string[] Act = Console.ReadLine().Split(' ');
                if (Act[0] == "Q")
                {
                    if (IsDebug.V)
                    {
                        Console.WriteLine("Action[" + Act[0] + "] start[" + Act[1] + "] last [" + Act[2] + "]");
                    }
                    root.Query(Convert.ToInt32(Act[1]), Convert.ToInt32(Act[2]));
                    // perform query
                }
                else if (Act[0] == "U")
                {
                    if (IsDebug.V)
                    {
                        Console.WriteLine("Action[" + Act[0] + "] start[" + Act[1] + "] Val [" + Act[2] + "] Konst [" + Act[3] + "]");
                    }
                    // perform update
                    // T is the parent of nodes to be updated
                    // For every node which is the descendent of the node T (nodeId)
                    int nodeID = Convert.ToInt32(Act[1]);
                    // update it's value by adding V + d*K, 
                    // where V and K are the parameters of the query 
                    // and d is the distance of the node from T. 
                    // Note that V is added to node T.
                    int V = Convert.ToInt32(Act[2]);
                    int K = Convert.ToInt32(Act[3]);
                    root.UpdateAction(nodeID, V, K);
                } 
            }
        }
    }
}
