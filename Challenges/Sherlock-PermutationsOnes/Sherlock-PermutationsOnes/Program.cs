#define CALC_PERMUTATIONS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock_PermutationsOnes
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
    public class ProblemConsts
    {
        public const long MOD_PRIME = 1000000007;
        public const long MOD_PRIME_M2 = (MOD_PRIME - 2);
        public const long MAX_RANGE = 2000;
        public const long MAX_RANGE1 = 2001;
        public const long THE_MAX = 1000033;


    }
    public class CalcPerm : ProblemConsts
    {
        public static long[,] comb = new long[MAX_RANGE1, MAX_RANGE1];
        public long N { get; protected set; }
        public long M { get; protected set; }
        public CalcPerm()
        {
            for (int i = 0; i < MAX_RANGE; ++i)
            {
                comb[i, 0] = 1;
                for (int j = 1; j < MAX_RANGE; ++j)
                {
                    // OK, I found a solution to short circuit the (i == 0) -1 index-out-of range issue
                    // this answer works properly for the sample data.
                    if (i == 0 || j == i )
                    {
                        comb[i, j] = 1;
                    }
                    //else if (j == 1)
                    //{
                    //    comb[i, j] = 1;
                    //}
                    else
                    {
                        comb[i, j] = (comb[i - 1, j] + comb[i - 1, j - 1] % MOD_PRIME);
                    }
                }
            }
        }
        public long permutation(long items, long picks)
        {
            return comb[items, picks];
        }

    }
    public class CountUniquePerms : ProblemConsts
    {
        public static long[] factorial = new long[THE_MAX];
        public static long[] inverse = new long[THE_MAX];

        public CountUniquePerms()
        {
            Initialize();
        }

        public long ModPower(long a, long n)
        {
            long ret = 1;
            long b = a;
            while (n > 0)
            {
                // If the value is odd
                if ((n & 1) == 1)
                {
                    ret = (ret * b) % MOD_PRIME;
                }
                b = b * b % MOD_PRIME;
                // n = n / 2;
                n >>= 1;
            }
            return ret;
        }
        protected void Initialize()
        {
            factorial[0] = 1;
            inverse[0] = 1;
            factorial[1] = 1;
            inverse[1] = 1;

            for (long i = 2; i < THE_MAX; ++i)
            {
                factorial[i] = (i * factorial[i-1]) % MOD_PRIME;
                inverse[i] = ModPower(factorial[i], MOD_PRIME_M2);
                //if ((i % 100) == 0)
                //{
                //    Console.Write("{0:d} ", i);
                //}
            }
        }

        // nCr = n! / (r! * (n -r)!)
        public long choose(long n, long r)
        {
            if (n < r) { return 1; }

            long invMult = (inverse[r] * inverse[n - r]) % MOD_PRIME;
            long result = (invMult * factorial[n]) % MOD_PRIME;

            return result;
        }

    }
    class Solution
    {

        static void CheckParams(long n, long min, long max)
        {
            if (n > max || n < min)
            {
                throw new ArgumentOutOfRangeException("Input out of range");
            }
        }
        static void TestCalcPermutations()
        {

        }
        static void Main(string[] args)
        {
#if CALC_PERMUTATIONS
            // this method / compute binomial table
            // is throwing index out of range, because 0 - 1 < 0 which is not in the range of the table
            // not sure how to fix the calculation.
            // obviously the C/C++ code didn't do range checking so accessing a memory location "below"
            // the range of the alocated memory didn't "crash" the application 
            CalcPerm cp = new CalcPerm();
            int t = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int[] NM = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                int zeros = NM[0];
                CheckParams(zeros, 1, 1000);
                int ones = NM[1];
                CheckParams(ones, 1, 1000);
                int items_to_select_from = zeros + ones - 1;
                //int to_choose = ((ones - 1) > 0) ? ones - 1 : 1;
                int to_choose = (ones - 1);
                if (IsDebug.V && false)
                {
                    Console.Write("nCk(n[{0:d}], k[{1:d}]); = ", items_to_select_from, to_choose);
                }
                Console.WriteLine(cp.permutation(zeros + ones - 1, to_choose));
            }
#else
            // this method / which computes the unique permutations in a table
            // is not working for me.  for zeros = 1 ones = 1, it prints 0
            // in fact any input where zeros <= ones will print 0
            // so I am not sure how to fix this algorithm either.
            CountUniquePerms cup = new CountUniquePerms();
            int t = Convert.ToInt32(Console.ReadLine());
            
            // 1 <= t <= 200
            CheckParams(t, 1, 200);
            for (int t0 = 0; t0 < t; ++t0)
            {
                int[] NM = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                int zeros = NM[0];
                CheckParams(zeros, 1, 1000);
                int ones = NM[1];
                // I figured it out nCk means
                // N elements is the sum of 1's and 0's
                // k is elements to choose
                // since we are fixing the choices to have A[0] == 1 so K == N - 1
                // count the total number of items to pick from
                long N = NM.Sum() - 1;
                // this is the total number of items to choose from N
                long K = N - 1;
                CheckParams(ones, 1, 1000);
                long m = (zeros - 1);
                m = (m > 0) ? m : 1;
                long n = m + ones;
                Console.WriteLine(cup.choose(N, K));
            }

#endif
        }
    }
}
