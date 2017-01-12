using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20_Sorting
{
    class Bubble
    {
        int[] target;
        int numberOfSwaps;
        public Bubble(int[] x)
        {
            target = new int[x.Length];
            target = x;
            numberOfSwaps = 0;
        }
        public void Swap( int i, int j)
        {
            int temp = target[i];
            target[i] = target[i + 1];
            target[i + 1] = temp;

        }
        public void Sort()
        {
            int endPosition = target.Length - 1;
            int swapPosition = 0;
            while (endPosition > 0)
            {
                swapPosition = 0;
                for (int i = 0; i < endPosition; ++i)
                {
                    if (target[i] > target[i+1])
                    {
                        Swap(i, i + 1);
                        numberOfSwaps++;
                        swapPosition = i;
                    }
                }
                endPosition = swapPosition;
            }
        }
        public void PrintResults()
        {
            Console.WriteLine("Array is sorted in {0:d} swaps.", numberOfSwaps);
            Console.WriteLine("First Element: {0:d}", target[0]);
            Console.WriteLine("Last Element: {0:d}", target[target.Length -1]);

        }
    }
    class Solution
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            Bubble b = new Bubble(a);
            b.Sort();
            b.PrintResults();
        }
    }
}
