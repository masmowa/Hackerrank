using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// find the length of the smallest possible substring that can be replaced to make S a steady gene?
/// </summary>
/// 
/* 
 * A gene is represented as a string of length n (where n is divisible by 4), 
composed of the letters  A, C, T, and G. It is considered to be steady if 
each of the four letters occurs exactly n/4 times.  For example, GACT and 
AAGTGCCT are both steady genes.

Bear Limak is a famous biotechnology scientist who specializes in modifying 
bear DNA to make it steady. Right now, he is examining a gene represented as 
a string s. It is not necessarily steady. Fortunately, Limak can choose one 
(maybe empty) substring of s and replace it with any string of the same length.

Modifying a large substring of bear genes can be dangerous. 
Given a string S, can you help Limak find the length of the 
smallest possible substring that he can replace to make S a steady gene?

Note: A substring of a string S is a subsequence made up of zero or more 
consecutive characters of S.

 * Input Format

The first line contains an interger n divisible by 4, denoting the length of a string s. 
The second line contains a string s of length n. Each character is one of the four: A, C, T, G.

 * Constraints
4 <= n <= 500,000

n is divisible by 4 

 * Subtask

4 <= n <= 2000 in tests worth 30% points.
Output Format

On a new line, print the minimum length of the substring replaced to make  stable.

 * Sample Input

8  
GAAATAAA
Sample Output

5
Explanation

One optimal solution is to replace a substring AAATA with TTCCG, resulting in GTTCCGAA. 
The replaced substring has length 5, so we print 5 on a new line.
 */
namespace BearAndSteadyGene
{
    public static class IsDebug
    {
        public static bool V
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }
    public class GeneFragment
    {
        public int N { get; protected set; }
        public string S { get; protected set; }
        public int Limit { get; protected set; }
        public int MaxIndex { get; protected set; }
        public int FinalSubstringLength { get; protected set; }

        // count each letter in the Gene Fragment
        public Dictionary<char, int> LetterCount;
        public GeneFragment(int n, string s)
        {
            LetterCount = new Dictionary<char, int>()
            {
                { 'A',0},
                { 'T',0},
                { 'G',0},
                { 'C',0},
            };
            N = n;
            S = s;
            MaxIndex = 0;
            FinalSubstringLength = ProblemConstants.INVALID_SUBSTR_LEN;
            Limit = S.Length / ProblemConstants.MIN_GENE_LEN;
            CountGeneLetters();
            FindSubstitutionLength();
        }
        protected void CountGeneLetters()
        {
            char[] g = S.ToCharArray();
            // find spot where letterCount[index] > n/4 
            for (int i = 0; i < S.Length; ++i)
            {
                LetterCount[g[i]]++;
                if (!IsValid())
                {
                    MaxIndex = i + 1;
                    LetterCount[g[i]]--;
                    break;
                }
            }


        }
        public void FindSubstitutionLength()
        {
            int minIndex = 0;
            int maxIndex = MaxIndex;
            int substringLength = 0;
            char[] g = S.ToCharArray();

            // adjust the length of the substring 
            for (minIndex = -1; minIndex < (N - 1) && maxIndex < N && minIndex < maxIndex; ++minIndex)
            {
                while (!IsValid() && maxIndex < N)
                {
                    LetterCount[g[maxIndex]]--;
                    maxIndex++;
                }
                // is MaxIndes past the end of the string or one of the character counts invalid?
                if (maxIndex > N || !IsValid())
                {
                    break;
                }
                // save the current substring length
                substringLength = Math.Max(0, (maxIndex - minIndex - 1));
                if (substringLength < FinalSubstringLength)
                {
                    FinalSubstringLength = substringLength;
                }
                // adjust the count of the next letter in the set
                LetterCount[g[minIndex + 1]]++;
            }
        }
        protected bool IsValid()
        {
            return (LetterCount['A'] <= Limit && LetterCount['C'] <= Limit && LetterCount['T'] <= Limit && LetterCount['G'] <= Limit);
        }
    }
    public class ProblemConstants
    {
        public const int MIN_GENE_LEN = 4;
        public const int MAX_GENE_LEN = 500000;
        public const int GENE_DIVISOR = 4;
        public const int BEST_N_MAX = 2000;
        public const int INVALID_SUBSTR_LEN = 999999;
    }
    class Program
    {
        public static void ValidateInput(int min, int high, int val)
        {
            if (val < min || val > high || ((val % ProblemConstants.GENE_DIVISOR) != 0))
            {
                throw new ArgumentOutOfRangeException("Input out of range");
            }
        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            GeneFragment GF = new GeneFragment(t, s);
            Console.WriteLine(GF.FinalSubstringLength);
        }
    }
}
