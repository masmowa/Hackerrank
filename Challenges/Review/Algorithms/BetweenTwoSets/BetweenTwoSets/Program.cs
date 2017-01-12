using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Between Two Sets
/// Consider two sets of positive integers, 
/// A = {a1, a2, a3, ..., an-1, an}
/// Bb= {b1, b2, b3, ..., bm-1, bm}
/// We say that a positive integer, x, is between sets A and B if the following conditions are satisfied:
/// 1. All elements of A are factors of x (x % a1 == 0, x % a2 == 0, ...)
/// 2. x is a factor of all elements of B
/// </summary>
/// <input-format>
/// The first line contains two space-separated integers describing the respective values of n (the number of elements 
/// in set A) and m (the number of elements in set B).
/// The second line contains n distinct space-separated integers describing {a1, a2, a3, ..., an-1, an}
/// The third line contains m distinct space-separated integers describing {b1, b2, b3, ..., bm-1, bm}
/// </input-format>
/// <Constraints>
/// 1 <= n, m <= 10
/// 1 <= a[i] <= 100
/// 1 <= b[i] <= 100
/// </Constraints>
/// <output-format>
/// Print the number of integers that are considered to be between A and B.
/// </output-format>
/// <sample-input>
/// 2 3
/// 2 4
/// 16 32 96
/// </sample-input>
/// <sample-output>
/// 3
/// </sample-output>
/// <explanation>
/// The integers that are between A = {2, 4} and B = {16, 32, 96} are 4, 8, 16
/// </explanation>
namespace BetweenTwoSets
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            string[] b_temp = Console.ReadLine().Split(' ');
            int[] b = Array.ConvertAll(b_temp, Int32.Parse);
        }
    }
}
