using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Objective: Today, we're working with binary numbers. 
 ***/
/// <summary>
/// x
/// </summary>
/// <task>
/// Given a base- integer, , convert it to binary(base-10). Then find and print the base-10 integer denoting the maximum number of consecutive 1's in n's binary representation.
/// </task>
/// <input-format>
/// A single integer, n
/// </input-format>
/// <output-format>
/// Print a single base-10 integer denoting the maximum number of consecutive 1's in the binary representation of n.
/// </output-format>
/// <sample-input name="1">
/// 5
/// </sample-input>
/// <sample-output name="1">
/// 1
/// </sample-output>
/// <sample-input name="2">
/// 13
/// </sample-input>
/// <sample-output name="2">
/// 2
/// </sample-output>

namespace BinaryDay10
{
    class Solution
    {
#if DEBUG
        public static bool IsDebug = true;
#else
        public static bool IsDebug = false;
#endif
        public static Stack<int> GetValueAsBinary(int val)
        {
            Stack<int> binDigits = new Stack<int>();
            int workv = val;
            while (workv > 0)
            {
                int remainder = workv % 2;
                workv = workv / 2;
                binDigits.Push(remainder);
            }
            if (IsDebug)
            {
                foreach (int r in binDigits)
                {
                    Console.Write(r.ToString());
                }
                Console.WriteLine();
            }
            return binDigits;
        }

        public static int CountMaxConsecutiveBinaryOnes(int val)
        {
            int result = 0;
            Stack<int> binDigits = GetValueAsBinary(val);

            int maxonedigits = 0;
            int onescount = 0;
            foreach (int digit in binDigits)
            {
               
                if (digit == 0)
                {
                    if (maxonedigits < onescount)
                    {
                        maxonedigits = onescount;
                    }
                    onescount = 0;
                }
                else
                {
                    onescount++;
                }
            }
            if (maxonedigits < onescount)
            {
                maxonedigits = onescount;
            }
            result = maxonedigits;
            return result;
        }
        static void Main(string[] args)
        {
            string sn;
            sn = Console.ReadLine();
            if (IsDebug)
            {
                Console.WriteLine(sn);
            }
            int n = Convert.ToInt32(sn);
            int count = CountMaxConsecutiveBinaryOnes(n);
            Console.WriteLine(count.ToString());
        }
    }
}
