using System;
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
        public List<ulong> R;
        protected static string EXPECTED_FILE = "output01.txt";
        public ExpectedResults(ulong t)
        {
            string[] expectedLines = File.ReadAllLines(EXPECTED_FILE);
            R = new List<ulong>(expectedLines.Length);
            foreach (string s in expectedLines)
            {
                R.Add(Convert.ToUInt64(s));
            }

        }
        public bool IsMatch(int index, ulong val)
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
        static void Main(string[] args)
        {
            int[] NM = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int N = NM[0];
            int M = NM[1];
            for (int m = 0; m < M; ++m)
            {
                int[] Edge = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            }
        }
    }
}
