using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Create program that processes segments of a 6x6 2D array in 3x3 segments
/// </summary>
/// <objective>
/// increase knowledge of 2D arrays
/// </objective>
/// <Context>
/// given 6x6 2D array, A:
/// 1 1 1 0 0 0
/// 0 1 0 0 0 0
/// 1 1 1 0 0 0
/// 0 0 0 0 0 0
/// 0 0 0 0 0 0
/// 0 0 0 0 0 0
/// we define an hourglass in A to be a subset of values with indices falling 
/// in this pattern in A's graphical representation
/// a b c
///   d  
/// e f g
/// there are 16, 3x3 segments in A (a 6x6 array); and an Hourglass
/// sum is the sum of an hourglass's values
/// </Context>
/// <task>
/// Calculate the hourglass sum for every hourglass in A, 
/// then print the maximum hourglass sum.
/// </task>
/// <input-format>
/// There are 6 lines of input, where each line contains 6 space-separated 
/// integers describing 2D Array A; every value in A will be in the 
/// inclusive range of -9 to 9.
/// </input-format>
/// <constraints>
/// -9 <= a[i][j] <= 9
/// 0 <= i, j <= 5 (index of array)
/// </constraints>
/// <output-format>
/// Print the largest (maximum) hourglass sum found in A.
/// </output-format>
/// <sample-input>
/// 1 1 1 0 0 0
/// 0 1 0 0 0 0
/// 1 1 1 0 0 0
/// 0 0 2 4 4 0
/// 0 0 0 2 0 0
/// 0 0 1 2 4 0
/// </sample-input>
/// <sample-output>
/// 19
/// </sample-output>
/// <explanation>
/// A contains the following hourglasses:
/// 1 1 1   1 1 0   1 0 0   0 0 0
///   1       0       0       0
/// 1 1 1   1 1 0   1 0 0   0 0 0
/// 
/// 0 1 0   1 0 0   0 0 0   0 0 0
///   1       1       0       0
/// 0 0 2   0 2 4   2 4 4   4 4 0
/// 
/// 1 1 1   1 1 0   1 0 0   0 0 0
///   0       2       4       4
/// 0 0 0   0 0 2   0 2 0   2 0 0
/// 
/// 2 4 4
///   2  
/// 1 2 4
/// 
/// The hourglass with the maximum sum (19) is:
/// 
/// 0 2 4   2 4 4   4 4 0
///   0       2       0
/// 0 0 1   0 1 2   1 2 4   2 4 0
/// 
/// </explanation>
namespace Day11_2D_Arrays
{
    class Solution
    {
#if DEBUG
        static bool IsDebug = true;
#else
        static bool IsDebug = false;
#endif
        static int MAXRCINDEX = 3;   // Last starting index for row or column of 6x6 array when extracting 3x3 array

        static int ComputeHoureglasssSum(int[][] arr, int rowstart, int colstart)
        {
            int result = 0;
            const int INDEXMAX = 2; // index of 3x3 array 0, 1, 2
            const int I_MAX_RC = 3; // row / col max index

            if (rowstart > MAXRCINDEX || colstart > MAXRCINDEX)
            {
                Console.WriteLine("starting index to large ({0:d}, {1:d}", rowstart, colstart);
                return 0;
            }
            //int rowmax = rowstart + INDEXMAX;
            //int colmax = colstart + INDEXMAX;
            for (int i = 0; i < I_MAX_RC; ++i)
            {
                int row = i + rowstart;
                for (int j = 0; j < I_MAX_RC; ++j)
                {
                    int col = j + colstart;
                    // skip r = 1, c = 0, 2
                    if ((i % 2 != 0) && (j % 2 == 0))
                    {
                        result += 0;
                    }
                    else
                    {
                        result += arr[row][col];
                    }
                }
            }
            if (IsDebug)
            {
                Console.WriteLine("[{0:d}][{1:d}] = {2:d}", rowstart, colstart, result);
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[][] arr = new int[6][];
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }
            int houreglassMax = -64;
            bool firstmax = true;
            for (int i=0; i <= MAXRCINDEX; ++i)
            {
                int val = 0;
                for (int j=0; j <= MAXRCINDEX; ++j)
                {
                    val = ComputeHoureglasssSum(arr, i, j);
                    if (firstmax)
                    {
                        houreglassMax = val;
                        firstmax = false;
                    }
                    //houreglassMax = (Math.Abs(houreglassMax) < Math.Abs(val)) ? val : houreglassMax;
                    houreglassMax = ((houreglassMax) < (val)) ? val : houreglassMax;
                }
            }
            if (IsDebug)
            {
                Console.Write("Max Hourglass value: ");
            }
            Console.WriteLine(houreglassMax.ToString());    
        }
    }
}
