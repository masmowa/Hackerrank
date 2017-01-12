using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_ScopeMaxDiff
{
    class Difference
    {
        private int[] elements;
        public int maximumDifference;

        public Difference(int[] a)
        {
            elements = a;
            maximumDifference = 0;
        }

        public void computeDifference()
        {
            for (int i=0; i<elements.Length-1; ++i)
            {
                for (int j= i+1; j < elements.Length; ++j)
                {
                    int diff = Math.Abs(elements[i] - elements[j]);
                    if (maximumDifference < (diff))
                    {
                        maximumDifference = diff;
                    }
                }
            }
        }
    }
    class Solution
    {
        static void Main(string[] args)
        {
            Convert.ToInt32(Console.ReadLine());

            int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            Difference d = new Difference(a);

            d.computeDifference();

            Console.Write(d.maximumDifference);
        }
    }
}
