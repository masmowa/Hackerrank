using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mutual_recurrences
{
    /// <summary>
    /// Mutual Recurrences
    /// </summary>
    /// <see cref="https://www.hackerrank.com/challenges/mutual-recurrences?h_r=next-challenge&h_v=zen"/> 
    class solution
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
            const int MIN_INPUT = 1;
            const ulong MAX_CASES = 1000;
            const ulong MAX_XY = (ulong)(1000000000000000000);
            //const ulong PROBLEM_LIMIT = 1000000000000000000;

            uint remainder = uint.MaxValue;
            uint quotient = 0;
            uint gcdQuotient = 0;
            uint gcdStart = 0;

            uint testcases = Convert.ToUInt32(Console.ReadLine());
            CheckValidInput(MIN_INPUT, MAX_CASES, testcases, "Testcases");
            for (ulong i = 0; i < testcases; i++)
            {
                uint[] XY = Console.ReadLine().Split(' ').Select(x => Convert.ToUInt32(x)).ToArray();
                CheckValidInput(1, 4, (ulong)XY.Length, "INPUT COUNT");
                foreach (ulong v in XY)
                {
                    CheckValidInput(1, MAX_XY, v, "coord");
                }
            }
        }
    }
}
