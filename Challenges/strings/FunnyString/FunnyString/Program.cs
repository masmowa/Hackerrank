using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyString
{
    class Solution
    {
#if DEBUG
        static bool IsDebug = true;
#else
        static bool IsDebug = false;
#endif
        const int MINIMUM = 32;

        static void FunnyOrNot(string S)
        {
            string prefix = "";
            char[] chArray = S.ToCharArray();
            Array.Reverse(chArray);
            string rev = new string(chArray);
            char[] sArray = S.ToCharArray();
            for (int i=1; i < S.Length; i++)
            {
                int h = i - 1;
                int dch = Math.Abs(sArray[i] - sArray[h]);
                int drch = Math.Abs(chArray[i] - chArray[h]);
                if (IsDebug)
                {
                    string eqop = ((dch == drch) ? "==" : "!=");
                    Console.WriteLine("|{0} - {1}| = {2} {3} |{4} - {5}| = {6}",
                        sArray[i], sArray[h], dch,
                        eqop,
                        chArray[i], chArray[h], drch);
                }
                if (dch != drch)
                {
                    prefix = "Not ";
                    break;
                }
            }
            Console.WriteLine("{0}Funny", prefix);
        }
        static void Main(string[] args)
        {
            List<string> cases = new List<string>(MINIMUM);
            int TestCases = Convert.ToInt32(Console.ReadLine());
            for (int i=0; i < TestCases; i++)
            {
                cases.Add(Console.ReadLine());
            }
            if (IsDebug)
            {
                Console.WriteLine("Number of Test cases: {0:d}", TestCases);
                foreach(string s in cases)
                {
                    Console.WriteLine(s);
                }
            }
            foreach (string S in cases)
            {
                FunnyOrNot(S);
            }
        }
    }
}
