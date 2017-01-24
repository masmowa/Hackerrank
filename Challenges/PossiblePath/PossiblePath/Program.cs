using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PossiblePath
{
    class Solution
    {
        static void CheckValidInput(ulong min, ulong max, ulong val, string name)
        {
            if (val < min || val > max)
            {
                throw new ArgumentOutOfRangeException(string.Format("Argument {0}, val: {1:d} out of range", name, val));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://www.hackerrank.com/challenges/possible-path"/> 
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const int MIN_INPUT = 1;
            const ulong MAX_CASES = 1000;
            const ulong MAX_XY = (ulong)(1000000000000000000);
            //const ulong PROBLEM_LIMIT = 1000000000000000000;

            ulong remainder = ulong.MaxValue;
            ulong quotient = 0;
            ulong gcdQuotient = 0;
            ulong gcdStart = 0;

            ulong testcases = (ulong)Convert.ToInt32(Console.ReadLine());
            CheckValidInput(MIN_INPUT, MAX_CASES, testcases, "Testcases");
            for (ulong i = 0; i < testcases; i++)
            {
                ulong[] XY = Console.ReadLine().Split(' ').Select(x => Convert.ToUInt64(x)).ToArray();
                CheckValidInput(1, 4, (ulong)XY.Length, "INPUT COUNT");
                foreach (ulong v in XY)
                {
                    CheckValidInput(1, MAX_XY, v, "coord");
                }
                ulong startX = XY[0];
                ulong startY = XY[1];
                ulong destX = XY[2];
                ulong destY = XY[3];
                remainder = ulong.MaxValue;

                while (remainder != 0)
                {
                    remainder = startX % startY;
                    startX = startY;
                    startY = remainder;
                    if (remainder == 0)
                    {
                        quotient = startX;
                    }
                }
                gcdStart = quotient;
                remainder = ulong.MaxValue;

                while (remainder != 0)
                {
                    remainder = destX % destY;
                    destX = destY;
                    destY = remainder;
                    if (remainder == 0)
                    {
                        quotient = destX;
                    }
                }
                gcdQuotient = quotient;

                if (gcdQuotient == gcdStart)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }
    }
}
