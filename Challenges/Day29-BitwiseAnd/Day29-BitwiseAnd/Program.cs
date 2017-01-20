using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day29_BitwiseAnd
{
    class Solution
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
                int[] S = new int[n];
                for (int i = 0; i < n; i++)
                {
                    S[i] = i + 1;
                }
                int andb = 0;
                int maxSoFar = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        andb = S[i] & S[j];
                        if (andb > maxSoFar && andb < k)
                        {
                            maxSoFar = andb;
                        }
                    }
                }
                Console.WriteLine(maxSoFar);
            }
        }
    }
}
