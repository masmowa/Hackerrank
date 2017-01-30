#define CLASSY_VERSION
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCrTable
{
#if CLASSY_VERSION
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
        public const int MIN_INPUT = 1;
        public const int MAX_T = 200;
        public const int MAX_N = 1000;
        public const long PROBLEM_LIMIT = 1000000000;
    }
    public class NCRTBL : ProblemConstants
    {
        public long N { get; protected set; }
        public long RowLimit { get; protected set; }
        public long[,] NcrTbl { get; protected set; }

        public NCRTBL(int n)
        {
            N = n;
            RowLimit = N + 1;
            NcrTbl = new long[RowLimit, RowLimit];

            InitContents();

        }
        protected void InitContents()
        {

            for (int i = 0; i < RowLimit; i++)
            {
                long jmax = i + 1;
                for (long j = 0; j < jmax; j++)
                {
                    if (j == 0 || j == i)
                    {
                        NcrTbl[i,j] = 1;
                    }
                    else
                    {
                        NcrTbl[i, j] = (NcrTbl[i - 1, j - 1] + NcrTbl[i - 1, j]) % PROBLEM_LIMIT;
                    }
                }
            }
        }
        public void PrintRow(int row)
        {
            int collength = NcrTbl.GetLength(1);
            //var row = NcrTbl.GetRow(N);
            for (int i = 0; i < RowLimit; i++)
            {
                if (NcrTbl[row, i] == 0)
                {
                    break;
                }
                Console.Write("{0} ",NcrTbl[row, i]);
            }
            Console.WriteLine();
        }
        protected bool IsValid()
        {
            return false;
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
        /// <summary>
        /// print binomal item for row n
        /// </summary>
        /// <see cref="https://www.hackerrank.com/challenges/ncr-table"/> 
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const int MIN_INPUT = 1;
            const int MAX_T = 200;
            const int MAX_N = 1000;
            const long PROBLEM_LIMIT = 1000000000;

            int t = Convert.ToInt32(Console.ReadLine());
            int tt = t;
            List<int> tcVals = new List<int>();
            CheckValidInput(MIN_INPUT, MAX_T, t, "T");
            while (t > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                CheckValidInput(MIN_INPUT, MAX_N, n, "N");
                tcVals.Add(n);
                t--;
            }
            int max = 0;
            foreach (int val in tcVals)
            {
                if (val > max)
                {
                    max = val;
                }
            }
#if CLASSY_VERSION
            // compute the table once
            NCRTBL ncr = new NCRTBL(max);
            foreach (int val in tcVals)
            {
                ncr.PrintRow(val);
            }
#else
            // UN-CLASSY-VERSION
            long RowLimit = max + 1;
            long[,] NcrTbl = new long[RowLimit, RowLimit];

            for (int i = 0; i < RowLimit; i++)
            {
                long jmax = i + 1;
                for (long j = 0; j < jmax; j++)
                {
                    if (j == 0 || j == i)
                    {
                        NcrTbl[i, j] = 1;
                    }
                    else
                    {
                        NcrTbl[i, j] = (NcrTbl[i - 1, j - 1] + NcrTbl[i - 1, j]) % PROBLEM_LIMIT;
                    }
                }
            }

            // pre-fill table with pascal values
            foreach (int row in tcVals)
            {
                for (int i = 0; i < RowLimit; i++)
                {
                    if (NcrTbl[row, i] == 0)
                    {
                        break;
                    }
                    Console.Write("{0} ", NcrTbl[row, i]);
                }
                Console.WriteLine();

            }
        }
#endif
    }
}
