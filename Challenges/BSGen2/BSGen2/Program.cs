using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSGen2
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
    public class ProblemConstants
    {
        public const int MIN_GENE_LEN = 4;
        public const int MAX_GENE_LEN = 500000;
    }
    public class DNAFragment
    {
        public int N { get; protected set; }
        public string S { get; protected set; }
        public int Limit { get; protected set; }
        public Dictionary<char, int> Contents { get; protected set; }
        public int MinLength { get; protected set; }
        public DNAFragment(int n, string s)
        {
            N = n;
            S = s;
            Limit = S.Length / ProblemConstants.MIN_GENE_LEN;
            int negLimit = -1 * Limit;
            Contents = new Dictionary<char, int>()
            {
                { 'A', negLimit },
                { 'T', negLimit },
                { 'G', negLimit },
                { 'C', negLimit },
            };
            MinLength = int.MaxValue;

            InitContents();
            FindSubstitutionLength();

        }
        protected void InitContents()
        {
            for (int i = 0; i < S.Length; ++i)
            {
                Contents[S[i]] = Contents[S[i]] + 1;
            }
        }
        protected void FindSubstitutionLength()
        {
            int tail = 0;
            int head = 0;
            int lastLength = MinLength;

            while (tail < S.Length && head < S.Length)
            {
                if (!IsValid())
                {
                    Contents[S[head]] = Contents[S[head]] - 1;
                    head++;
                }
                else
                {
                    MinLength = Math.Min(MinLength, head - tail);
                    if (lastLength != MinLength)
                    {
                        if (IsDebug.V)
                        {
                            Console.Write("replacement change from: {0:d} to {1:d}; [head, tail][{2:d}, {3:d}]"
                                , lastLength
                                , MinLength
                                , head
                                , tail
                                );
                            string d = S.Substring(tail, MinLength);
                            Console.WriteLine(" value = {0}", d);
                        }
                        lastLength = MinLength;
                    }
                    Contents[S[tail]] = Contents[S[tail]] + 1;
                    tail++;
                }
            }
            if (IsDebug.V)
            {
                Console.WriteLine("head = {0:d}; tail = {1:d}; delta = {2:d};", head, tail, MinLength);
            }
        }
        protected bool IsValid()
        {
            return (Contents['A'] <= 0 && Contents['C'] <= 0 && Contents['T'] <= 0 && Contents['G'] <= 0);
        }
    }
    class Solution
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            DNAFragment GF = new DNAFragment(t, s);
            Console.WriteLine(GF.MinLength);
        }
    }
}
