using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// test if array is symetric around the center value
/*
determine if there exists an element in the array such that the sum of 
the elements on its left is equal to the sum of the elements on its 
right. If there are no elements to the left/right, then the sum is 
considered to be zero. Formally, find an i, such that, A[1] + A[2] + ... 
+ A[i-1] = A[i+1]+ A[i+2] +...+ A[N]. 
*/
namespace Sherlock_Array
{
    class Solution
    {
#if DEBUG
        static public bool IsDebug = true;
#else
        static public bool IsDebug = false;
#endif
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int[] A = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                if (testEqual(N, A))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }

            }
        }
        static bool testEqual(int N, int[] A)
        {
            int lsum = 0;
            int rsum = 0;
            int sum = 0;
            bool found = false;
            for (int i = 0; i < N; ++i)
            {
                rsum += A[i];
            }
#if true
            if (IsDebug)
            {
                Console.WriteLine("rsum = {0:d} lsum = {1:d}", rsum, lsum);
            }
            rsum -= A[0];
            if (IsDebug)
            {
                Console.WriteLine("rsum = {0:d} lsum = {1:d}", rsum, lsum);
            }
            found = (rsum == lsum);

            for (int i=1; i< N; ++i)
            {
                lsum += A[i - 1];
                rsum -= A[i];
                if (IsDebug)
                {
                    Console.WriteLine("rsum = {0:d} lsum = {1:d}", rsum, lsum);
                }
                if (rsum == lsum)
                {
                    found = true;
                    break;
                }
            }
#else
            rsum = sum;
            for (int i=0; i < N; i++)
            {
                lsum = sum - lsum;
                rsum -= A[i];
                if (rsum == lsum)
                {
                    found = true;
                    break;
                }

            }
#endif
            return found;
        }
    }
}
