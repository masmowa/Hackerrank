using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Calculator class with single method int power(int, int)
/// the power method takes two integers, n and p, as parameters
///  and returns the integer result of n^p. 
///  if either n or p is negative throw an exception with the message
///  "n and p should be non-negative."
/// </summary>
namespace Day17_MoreExceptions_CalcPower
{
    class Calculator
    {
        public int power(int n, int p)
        {
            int result = 1;
            if (n < 0 || p < 0)
            {
                throw new Exception("n and p should be non-negative");
            }
            for (int i = 0; i < p; ++i)
            {
                result *= n;
            }
            return result;
        }
    }
    class Solution
    {
        static void Main(string[] args)
        {
            int T = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < T; ++i)
            {
                try
                {
                    int[] np = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                    Calculator c = new Calculator();
                    int res = c.power(np[0], np[1]);

                    Console.WriteLine(res);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
