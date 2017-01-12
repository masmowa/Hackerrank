using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day25_RunningTimeAndComplexity
{
    class Solution
    {
#if DEBUG
        static public bool IsDebug = true;
#else
        static public bool IsDebug = false;
#endif
        static List<int> knowPrimes = new List<int>() { 2, 3, 5, 7, 11, 13 };
        static string PrimeOrNot(int val)
        {
            if (val == 1)
            {
                return "Not prime";
            }
            if (knowPrimes.Contains(val))
            {
                return ("Prime");
            }
            foreach (int v in knowPrimes)
            {
                if (val % v == 0)
                {
                    return ("Not prime");
                }
            }
            int divMax = (int)Math.Sqrt(val);
            divMax++;
            if (divMax > 13)
            {
                for (int div = 13+1; div < divMax; div++)
                {
                    if (IsDebug)
                    {
                        Console.Write("div: {0:d} ", div);
                    }
                    if (val % div == 0)
                    {
                        return ("Not prime");
                    }
                }
            }

            return ("Prime");

        }
        static void Main(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                if (IsDebug)
                {
                    Console.Write("val: {0:d} : ", data);
                }
                Console.WriteLine(PrimeOrNot(data));
            }
        }
    }
}
