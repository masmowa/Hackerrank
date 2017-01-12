using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_BinarySearchTrees
{
    class Program
    {
        static List<int> knowPrimes = new List<int>() { 1, 2, 3, 5, 7, 11, 13, 17 };
        static void PrimeOrNot(int val)
        {
            if (knowPrimes.Contains(val) )
            {
                Console.WriteLine("Prime");
                return;
            }
            foreach (int v in knowPrimes)
            {
                if (val % v == 0)
                {
                    Console.WriteLine("Not Prime");
                    return;
                }
            }
            int div = (val - 1) / 2;
            while (div > 17)
            {
                if (val % div == 0)
                {
                    Console.WriteLine("Not Prime");
                    return;
                }
                else
                {
                    div = (div - 1) / 2;
                }
            }
            if (div <= 17)
            {
                Console.WriteLine("Prime");
            }

        }
        static void Main(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                PrimeOrNot(data);
            }
        }
    }
}
