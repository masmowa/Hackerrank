using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLCDTest
{
    class Program
    {
        public static int lcs(string sX, string sY)
        {
            int m = sX.Length;
            int mm = m + 1;
            int n = sY.Length;
            int nn = n + 1;
            int[][] L = new int[mm][];
            char[] X = sX.ToCharArray();
            char[] Y = sY.ToCharArray();

            // C# does sparce arrays in the C++ nomenclatrue, matrix is int [,] C = new int[mm, nn]; 
            for (int i = 0; i < mm; ++i)
            {
                L[i] = new int[nn];
            }

            // the following steps build matrix L[m+1][n+1] in bottom up fashon.
            // Note: that L[i][j] contains length of LCS of X[0..i-1] and Y[0..j-1]
            for (int i = 0; i <= m; ++i)
            {
                for (int j = 0; j <= n; ++j)
                {
                    //// work around index out of bounds
                    //// original written in C++ did not do bounds checking
                    //int im1 = (i > 0) ? i - 1 : 0;
                    if (i == 0 || j == 0)
                    {
                        L[i][j] = 0;
                    }
                    else if (X[i - 1] == Y[j - 1])
                    {
                        L[i][j] = L[i - 1][j - 1] + 1;
                    }
                    else
                    {
                        L[i][j] = Math.Max(L[i - 1][j], L[i][j - 1]);
                    }
                }
            }
            // L[m][n] contains the LCS for X[0..n-1], Y[..m-1]
            return L[m][n];
        }
        static void Main(string[] args)
        {
            string X = "AGGTAB";
            string Y = "GXTXAYB";

            Console.WriteLine("Length of LCS is {0:d}", lcs(X, Y));
        }
    }
}
