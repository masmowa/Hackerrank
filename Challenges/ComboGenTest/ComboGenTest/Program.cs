using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// based on another Combinatorial set of classes
/// </summary>
/// <see cref="https://www.codeproject.com/Articles/2781/Combinatorial-algorithms-in-C"/>
/// <seealso cref="http://trycatch.me/combinatorics-in-net-part-i-permutations-combinations-variations/"/>
/// <seealso cref="https://www.codeproject.com/articles/26050/permutations-combinations-and-variations-using-c-g"
/// 
namespace ComboGenTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo");

            int[] intTest = new int[100];
            int intCount = 11;
            for (int i=0; i<intCount; i++)
            {
                intTest[i] = i;
            }

            Combinations<int> combs = new Combinations<int>(intTest.ToList<int>(), intTest.Length);


        }
    }
}
