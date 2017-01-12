using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/// <summary>
/// Given an array of  integers, can you find the sum of its elements?
/// Input Format
/// The first line contains an integer, , denoting the size of the array.
/// The second line contains  space-separated integers representing the array's elements.
/// Output Format
/// Print the sum of the array's elements as a single integer.
/// Sample Input
/// 6
/// 1 2 3 4 10 11
/// Sample Output
/// 31
/// </summary>

namespace SumNValues_Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            if (n != arr_temp.Length)
            {
                Console.WriteLine("parameter mismatch count {0:d} array length {1:d}", n, arr_temp.Length);
            }
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            int sum = 0;
            foreach (int val in arr)
            {
                sum += val;
            }
            Console.WriteLine(sum.ToString());
        }
    }
}
