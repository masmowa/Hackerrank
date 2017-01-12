using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FactorialBI
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            BigInteger F = Factorial(n);
            Console.WriteLine(F.ToString());
        }

        /// <summary>
        /// use recursion to compute the factorial of a number
        /// 
        /// factorial definition = N * ( (N - 1) * ( (N - 2) * ( ... ) ) ); 
        /// </summary>
        /// <remarks>
        /// Input consists of a single integer N, where 1 <= N <= 100.
        /// </remarks>
        /// <param name="n">number to compute factorial of</param>
        /// <returns>n!</returns>
        static BigInteger Factorial(int n)
        {
            BigInteger F0 = 1;
            if (n == 1)
            {
                return n;
            }
            else
            {
                F0 = Factorial(n - 1);
            }
            BigInteger F = F0 * n;
            return F;
        }
    }
}
