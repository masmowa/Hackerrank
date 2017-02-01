using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Matrix Tracing
/// find the number of choices for dumped into M x N matrix
/// How many ways can you distribute a string of length M + N - 1
/// in a matrix of dimensions M x N
/// </summary>
/// <see cref="https://www.hackerrank.com/challenges/matrix-tracing"/> 
namespace Matrix_Tracing
{
    public class ProblemConstants
    {
        public const ulong MIN_INPUT = 1;
        public const ulong MAX_CASES = 1000;
        public const ulong MAX_MN = 2000001;
        public const ulong MAX_LINEVAL = 3;
        public const ulong LIMIT_MOD = (ulong)(1000000007);
        public const ulong LIMIT_MOD_M2 = (ulong)(1000000005);
        public const ulong MATRIX_RC = 2;
        public const ulong THE_MAX = 2000033;
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
    public class ExpectedResults
    {
#if DEBUG
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
#endif
    }

    /// <summary>
    /// let w = (n + m - 2)
    /// let x = (m - 1)
    /// let y = (n - 1)
    /// need to compute w! / (x! * y!)
    /// We are just permutating a set of n-1 moves right and m-1 moves down
    /// while for large values we do 
    /// T = w! % p
    /// U = x! % p
    /// V = y! % p
    /// F(n+m - 1) = T / (U * V)
    /// </summary>
    public class WordPermutationInMultiset : ProblemConstants
    {
        public static ulong[] factorial = new ulong[THE_MAX];
        public static ulong[] inverse = new ulong[THE_MAX];

        public ulong M { get; protected set; }
        public ulong N { get; protected set; }
        public ulong S { get; protected set; }
        public ulong T { get; protected set; }
        public ulong U { get; protected set; }
        //public ulong V { get; protected set; }
        //public ulong W { get; protected set; }
        //public ulong XA { get; protected set; }

        public WordPermutationInMultiset()
        {
            Initialize();
        }

        /// <summary>
        /// raise a to power n (a^n)
        /// X^(-1) mod(p) can be written as X^(p-2) mod(p)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ulong FastModPower(ulong a, ulong n)
        {
            ulong ret = 1;
            ulong b = a;

            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    // ODD
                    ret = (ret * b) % LIMIT_MOD;
                }
                b = (b * b) % LIMIT_MOD;

                n >>= 1;    // n / 2
            }
            return ret;
        }
        /// <summary>
        /// compute M! / N! wher M > N and N <= M - 1
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ulong FactoralMoverN(ulong m, ulong n)
        {
            ulong a = 1;
            for (ulong i = m; i > (m -n); i--)
            {
                a = a * i;
            }
            return a;
        }
        protected void Initialize()
        {
            factorial[0] = 1;
            inverse[0] = 1;
            factorial[1] = 1;
            inverse[1] = 1;
            for (ulong i = 2; i < THE_MAX; ++i)
            {
                factorial[i] = (i * factorial[i - 1]) % LIMIT_MOD;
                // X^(-1) mod(p) can be written as X^(p-2) mod(p)
                inverse[i] = (FastModPower(factorial[i], LIMIT_MOD_M2) % LIMIT_MOD);

            }
        }
        /// <summary>
        /// (m + n - 2)! / (m - 1)! * (n - 1)!
        /// permutating a set of n-1 moves right and m-1 moves down.
        /// </summary>
        /// <param name="n">rows</param>
        /// <param name="m">columns</param>
        /// <returns></returns>
        public ulong Choose(ulong n, ulong m)
        {
            // number of rows
            M = m;
            // number of columns
            N = n;
            // compute the number of characters in the word
            S = M + N - 2;
            T = M - 1;
            U = N - 1;
            if (S < T || S < U) { return 1; }

            ulong invMult = (inverse[T] * inverse[U]) % LIMIT_MOD;
            ulong result = (invMult * factorial[S]) % LIMIT_MOD;

            return result;
        }
    }
    class Solution : ProblemConstants
    {
        static void CheckValidInput(ulong min, ulong max, ulong val, string name)
        {
            if (val < min || val > max)
            {
                throw new ArgumentOutOfRangeException(string.Format("Argument {0}, val: {1:d} out of range", name, val));
            }
        }
        static void CheckValidInput(int min, int max, int val, string name)
        {
            if (val < min || val > max)
            {
                throw new ArgumentOutOfRangeException(string.Format("Argument {0}, val: {1:d} out of range", name, val));
            }
        }
        static void testFastExponentiation(ulong m, ulong n)
        {

        }
        static void testNumeratorFactorial(ulong m, ulong n)
        {

        }
        static void Main(string[] args)
        {
            int testcases = Convert.ToInt32(Console.ReadLine());
            CheckValidInput((int)MIN_INPUT, (int)MAX_CASES, testcases, "test cases");

            WordPermutationInMultiset wmc = new WordPermutationInMultiset();
#if DEBUG
            ExpectedResults xr = new ExpectedResults(1);
#endif
            for (int t = 0; t < testcases; ++t)
            {
                string items = Console.ReadLine().Trim();
                ulong[] RC = items.Split(' ').Select(x => Convert.ToUInt64(x)).ToArray();
                string[] label = new string[] { "M", "N" };
                for (int i=0; i< RC.Length; i++)
                {
                    CheckValidInput((int)MIN_INPUT, (int)MAX_MN, RC[i], label[i]);
                }
                if (IsDebug.V)
                {
                    Console.WriteLine("M, N ({0:d}, {1:d}); ", RC[0], RC[1]);
                }
                if (IsDebug.V)
                {
                    Console.WriteLine("M, N ({0:d}, {1:d}); M + N - 1 = {2:d}; ", RC[0], RC[1], wmc.S);
                    Console.Write("Answer = ");
                }
                ulong ans = wmc.Choose(RC[0], RC[1]);
                Console.WriteLine(ans);
                if (IsDebug.V)
                {
#if DEBUG
                    Console.WriteLine("XR: {0:d}; r = {1}", ans, xr.IsMatch(t, ans).ToString());
                    if(!xr.IsMatch(t, ans))
                    {
                        Console.WriteLine("FAIL");
                        break;
                    }
#endif
                }
            }
        }
    }
}
