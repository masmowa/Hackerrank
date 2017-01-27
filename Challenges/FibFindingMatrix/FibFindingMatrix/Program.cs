using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// find fibonacci(n) with Fi = { A, B }
/// </summary>
/// <see cref="https://www.hackerrank.com/contests/infinitum10/challenges/fibonacci-finding-easy"/> 
/// <see cref="http://fusharblog.com/solving-linear-recurrence-for-programming-contest/"/> 
namespace FibFindingMatrix
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
    public class ProblemConstants
    {
        public const uint MIN_INPUT = 1;
        public const uint MAX_CASES = 1000;
        public const uint MAX_LINEVAL = 3;
        public const uint LIMIT_MOD = (uint)(1000000007);
        public const uint MATRIX_RC = 2;
    }

    /// <summary>
    /// fast matrix fi Binocci computation
    /// </summary>
    /// <see cref="https://www.nayuki.io/page/fast-fibonacci-algorithms"/> 
    /// <seealso cref="https://www.nayuki.io/res/fast-fibonacci-algorithms/fastfibonacci.java"/> 
    /// <seealso cref="https://www.nayuki.io/res/fast-fibonacci-algorithms/fastfibonacci.cs"/>
    /// <seealso cref="https://en.wikipedia.org/wiki/Matrix_exponential"/>
    /// <seealso cref="https://ronzii.wordpress.com/2011/07/09/using-matrix-exponentiation-to-calculated-nth-fibonacci-number/"/>
    /// <seealso cref="https://en.wikipedia.org/wiki/Exponentiation_by_squaring"/>
    /// <seealso cref="http://www.ams.org/journals/mcom/1987-48-177/S0025-5718-1987-0866113-7/S0025-5718-1987-0866113-7.pdf"/>
    /// <seealso cref="https://www.dotnetperls.com/fibonacci"/>
    /// <seealso cref="http://rosettacode.org/wiki/Fibonacci_n-step_number_sequences#C.23"/>
    /// <seealso cref="http://fusharblog.com/solving-linear-recurrence-for-programming-contest/"/>
    /* 
        * Fast matrix method. Easy to describe, but has a constant factor slowdown compared to doubling method.
        * [0 1]^n   [ F(n-1) F(n)  ]
        * [1 1]   = [F(n)  F(n+1)].
         */
    public class FastBonacci : ProblemConstants
    {
        //private static int[] G = new int[] { 1, 1, 1, 0 };
        // Transform Matrix T
        private static ulong[,] T = new ulong[,] {
            { 0, 1 },   // row 0 F(k-1)
            { 1, 1 }    // ROW 1
        };

        public ulong[,] Pwr(ulong[,] A, ulong ex)
        {
            if (ex == 1)
            {
                return A;
            }
            if ((ex % 2) == 1)
            {
                return Multiply(A, Pwr(A, ex - 1));
            }
            ulong [,] X = new ulong[,] { { 0, 0 }, { 0, 0 } };
            X = Pwr(A, ex / 2);
            return Multiply(X, X);
        }
        public ulong[,] Power(ulong[,] matrix, ulong n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("N must be >= 0");
            }
            ulong[,] result = new ulong[,]
            {
                { 1, 0 },
                { 0, 1 }
            };
            // exponentiation by squaring
            while (n > 0)
            {
                if (n % 2 != 0)
                {
                    // odd
                    result = MatrixMultiply(result, matrix);
                }
                n /= 2;
                matrix = MatrixMultiply(matrix, matrix);
            }
            return result;
        }
        public ulong[,] MatrixMultiply(ulong[,] m1, ulong[,] m2)
        {
            int nrow = m1.GetLength(0);
            int ncol = m1.GetLength(1);
            return new ulong[,]
            {
                 {(((m1[0,0] * m2[0,0])  % LIMIT_MOD) + ((m1[0,1] * m2[1, 0]) % LIMIT_MOD)  % LIMIT_MOD),
                  ((((m1[0,0] * m2[0,1])  % LIMIT_MOD) + ((m1[0,1] * m2[1, 1])  % LIMIT_MOD)) % LIMIT_MOD) },
                 {((((m1[1,0] * m2[0,0])  % LIMIT_MOD) + ((m1[1,1] * m2[1, 0])  % LIMIT_MOD)) % LIMIT_MOD) ,
                  ((((m1[1,0] * m2[0,1])  % LIMIT_MOD) + ((m1[1,1] * m2[1, 1])  % LIMIT_MOD)) % LIMIT_MOD) }
            };
        }
        public ulong[,] Multiply(ulong[,] m1, ulong[,] m2)
        {
            ulong nrow = (ulong)m1.GetLength(0);
            ulong ncol = (ulong)m1.GetLength(1);
            ulong[,] res = new ulong[,] { { 0, 0 }, { 0, 0 } };
            for (ulong i=0; i < nrow; ++i)
            {
                for (ulong j=0; j < ncol; ++j)
                {
                    for (ulong k=0; k < ncol; ++k)
                    {
                        res[i, j] = (res[i, j] + m1[i, k] * m2[k, j]) % LIMIT_MOD;
                    }
                }
            }
            return res;
        }
        public ulong Fib(ulong n)
        {
            ulong[,] TN = new ulong[,] {
                { 0, 0 },   // row 0
                { 0, 0 }    // ROW 1
            };
            TN = Power(T, n);
            return TN[0, 1];
        }
        public ulong Fib(ulong n, ulong[] F)
        {
            ulong res = 0;
            ulong[,] TN = new ulong[,] {
                { 0, 0 },   // row 0
                { 0, 0 }    // ROW 1
            };
            if (n <= 1)
            {
                return F[n];
            }
            else
            {
                TN = Pwr(T, n - 1);
                res = 0;
                for (ulong i= 0; i < MATRIX_RC; ++i)
                {
                    res = (res + ((TN[1, i] * F[i]) % LIMIT_MOD)) % LIMIT_MOD;
                }
            }

            return res;
        }
        public ulong FastFibonacciMatrix(ulong n)
        {
            return 0;
        }

        //static void Run(string[] args)
        //{
        //    for (int i = 1; i <= 46; i++)
        //        Console.WriteLine("{0,4} FibN = {1,10} FibLogN = {2,10}",
        //            i, FibN(i), FibLogN(i));
        //}
    }
    public class ExpectedResults
    {
        public List<ulong> R;
        protected static string EXPECTED_FILE = "output01.txt";
        //protected static string EXPECTED_FILE = "output00.txt";
        public ExpectedResults(uint t)
        {
            string[] expectedLines = File.ReadAllLines(EXPECTED_FILE);
            R = new List<ulong>(expectedLines.Length);
            foreach (string s in expectedLines)
            {
                R.Add(Convert.ToUInt32(s));
            }

        }
        public bool IsMatch(int index, ulong val)
        {
            if (IsDebug.V)
            {
                Console.Write("[{0:d}] val = {1:d} expected = {2:d}; ", index, val, R[index]);
            }
            return (R[index] == val);
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
        static void Main(string[] args)
        {
            uint testcases = Convert.ToUInt32(Console.ReadLine());
            List<ulong> fibVals = new List<ulong>();
            CheckValidInput(MIN_INPUT, MAX_CASES, testcases, "Testcases");
            ExpectedResults xr = new ExpectedResults(1);
            for (uint t = 0; t < testcases; t++)
            {
                if (IsDebug.V)
                {
                    Console.WriteLine("Case {0:d} [", t);
                }

                uint[] InputValues = Console.ReadLine().Split(' ').Select(x => Convert.ToUInt32(x)).ToArray();
                CheckValidInput(MIN_INPUT, MAX_LINEVAL, (uint)InputValues.Length, "INPUT COUNT");
                foreach (uint v in InputValues)
                {
                    CheckValidInput(MIN_INPUT, LIMIT_MOD, v, "Bonacci value");
                }
                if (IsDebug.V)
                {
                    Console.WriteLine("input: {0}", string.Join(" ", InputValues));
                }

                fibVals.Add(InputValues[0]);
                fibVals.Add(InputValues[1]);
                //uint F0 = InputValues[0];
                //uint F1 = InputValues[1];
                uint N = (uint)InputValues[2];
                FastBonacci fb = new FastBonacci();

                ulong fibval = fb.Fib(N, fibVals.ToArray());
                if (IsDebug.V)
                {
                    if (xr.IsMatch((int)t, fibval))
                    {
                        Console.WriteLine(" PASS ");
                    }
                    else
                    {
                        Console.WriteLine(" FAIL!! ");
                        break;
                    }
                }
                fibVals.Clear();
            }
        }
    }
}
