using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Fibonacci Finding
/// </summary>
/// <see cref="https://www.hackerrank.com/contests/infinitum10/challenges/fibonacci-finding-easy"/> 
namespace FibonacciFinding
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
    public class FastBonacci : ProblemConstants
    {
        private static int[] G = new int[] { 1, 1, 1, 0 };
        private static long[,] H = new long[,] { 
            { 1, 1 },   // row 0
            { 1, 0 }    // ROW 1
        };
        public long[,] MatrixPower(long[,] matrix, long n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("N must be >= 0");
            }
            long[,] result = new long[,]
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
        public long[,] MatrixMultiply(long[,] m1, long[,] m2)
        {
            int nrow = m1.GetLength(0);
            int ncol = m1.GetLength(1);
            return new long[,]
            {
                 {((m1[0,0] * m2[0,0]) + (m1[0,1] * m2[1, 0])),
                  ((m1[0,0] * m2[0,1]) + (m1[0,1] * m2[1, 1])) },
                 {((m1[1,0] * m2[0,0]) + (m1[1,1] * m2[1, 0])),
                  ((m1[1,0] * m2[0,1]) + (m1[1,1] * m2[1, 1])) }
            };
        }
        public long Fib(long n)
        {
            long[,] result = new long[,] {
                { 0, 0 },   // row 0
                { 0, 0 }    // ROW 1
            };
            result = MatrixPower(H, n);
            return result[0, 1];
        }
        public static int FibN(int n)
        {
            if (n <= 1) { return 1; }
            return 0;
        }
        public static int FibLogN(int n)
        {
            return 0;
        }
        /* 
         * Fast matrix method. Easy to describe, but has a constant factor slowdown compared to doubling method.
         * [1 1]^n   [F(n+1) F(n)  ]
         * [1 0]   = [F(n)   F(n-1)].
         */
         public long FastFibonacciMatrix(long n)
        {
            return 0;
        }

        static void Run(string[] args)
        {
            for (int i = 1; i <= 46; i++)
                Console.WriteLine("{0,4} FibN = {1,10} FibLogN = {2,10}",
                    i, FibN(i), FibLogN(i));
        }
    }
    class Solution
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
            const uint MIN_INPUT = 1;
            const uint MAX_CASES = 1000;
            const uint MAX_LINEVAL = 3;
            const uint LIMIT_MOD = (uint)(1000000007);
            //const ulong PROBLEM_LIMIT = 1000000000000000000;


            uint testcases = Convert.ToUInt32(Console.ReadLine());
            List<ulong> fibVals = new List<ulong>();
            CheckValidInput(MIN_INPUT, MAX_CASES, testcases, "Testcases");
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
                //fibVals.Add(InputValues[0]);
                //fibVals.Add(InputValues[1]);
                uint F0 = InputValues[0];
                uint F1 = InputValues[1];
                int N = (int)InputValues[2];
                for (int i = 2; i < N; ++i)
                {
                    uint fibval = (F0 + F1) % LIMIT_MOD;
                    if (false && IsDebug.V && ((i % 1001) == 0))
                    {
                        Console.WriteLine("F0 [{0:d}] F1[{1:d}] F0 + F1 = [{2:d}]", F0, F1, fibval);
                    }
                    if (IsDebug.V && ((N - i) < 3))
                    {
                        Console.WriteLine("F0 [{0:d}] F1[{1:d}] F0 + F1 = [{2:d}]", F0, F1, fibval);
                    }
                    F0 = F1;
                    F1 = fibval;

                }
                if (IsDebug.V)
                {
                    Console.WriteLine("N [{0:d}] [ {1:d} {2:d} ] output = {3:d}", N, F0, F1, F1);
                    Console.WriteLine("]");
                }
                Console.WriteLine(F1);
            }
        }
    }
}
