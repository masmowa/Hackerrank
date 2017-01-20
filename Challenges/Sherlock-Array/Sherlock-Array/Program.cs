using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
#if true
                if (testEqual(N, A))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }

#else
                if (N == 1)
                {
                    Console.WriteLine("YES");
                    continue;
                }
                else if (N <= 3)
                {
                    Console.WriteLine("NO");
                    continue;
                }
                int j = N - 1;
                int prevj = N;
                int i = 0;
                int previ = 0;
                int losum = A[i++];
                int hisum = A[j--];
                while (i < j)
                {
                    if (IsDebug)
                    {
                        Console.WriteLine("i: {0:d} : losum = {1:d} j: {2:d} : hisum = {3:d}", i, losum, j, hisum);
                    }
                    while (losum < hisum)
                    {
                        losum += A[i];
                        previ = i;
                        i++;
                    }
                    if (losum == hisum && i == j)
                    {
                        Console.WriteLine("YES");
                        break;
                    }
                    else if (losum != hisum && i == j)
                    {
                        Console.WriteLine("NO");
                        break;
                    }
                    else if (losum > hisum && i < j - 1)
                    {
                        while (losum > hisum && i < j)
                        {
                            hisum += A[j];
                            prevj = j;
                            j--;
                        }
                        if (losum == hisum && i == j)
                        {
                            Console.WriteLine("YES");
                            break;
                        }
                    }

                }
#endif
            }
            //if (IsDebug)
            //{
            //    Console.ReadLine();
            //}
        }
        static bool CheckValues(int v1, int v2) { return v1 == v2; }
        static bool checkIndexValues(int i, int j)
        {
            int nexti = i + 1;
            int nextj = j - 1;
            return (nexti == nextj);
        }
        static bool testEqual(int N, int[] A)
        {
            int lsum = 0;
            int rsum = 0;
            int sum = 0;
            bool found = false;
            for (int i = 0; i < N; ++i)
            {
                sum += A[i];
            }
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
            return found;
        }
    }
}
