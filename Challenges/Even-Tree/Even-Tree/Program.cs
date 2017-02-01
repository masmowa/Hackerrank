using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Even_Tree
{
    public class ProblemConstants
    {
        public const ulong MIN_INPUT = 2;
        public const ulong MAX_CASES = 100;
    }
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

    class Solution
    {
        static void CheckValidInput(int min, int max, int val, string name)
        {
            if (val < min || val > max)
            {
                throw new ArgumentOutOfRangeException(string.Format("Argument {0}, val: {1:d} out of range", name, val));
            }
        }

        /*
            I've used a simple version to count the child edges instead of vertices. 
            Here's the C# code which passed the test cases.
         */
        public static int CountChildEdges(Dictionary<int, int> edges, KeyValuePair<int, int> edge)
        {
            var count = 0;
            // tracing the tree, if the value of the edge matches the key of the next edge, increase count and follow the "link"
            foreach (var nextEdge in edges.Where(e => e.Value.Equals(edge.Key)))
            {
                count++;
                count += CountChildEdges(edges, nextEdge);
            }
            return count;
        }
        static void Main(string[] args)
        {
#if DEBUG
            ExpectedResults xr = new ExpectedResults(0);
#endif
            Dictionary<int, int> edges = new Dictionary<int, int>();
            int[] NM = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int N = NM[0];
            int M = NM[1];
            for (int m = 0; m < M; ++m)
            {
                int[] edge = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                edges.Add(edge[0], edge[1]);
            }
            // while (count % 2 != 0) count next edge
            int count = edges.Count(edge => CountChildEdges(edges, edge) % 2 != 0);
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
