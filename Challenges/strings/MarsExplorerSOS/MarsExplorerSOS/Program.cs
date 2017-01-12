using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsExplorerSOS
{
    class Solution
    {
#if DEBUG
        static bool IsDebug = true;
#else
        static bool IsDebug = false;
#endif

        public static string SOS = "SOS";

        static void Main(string[] args)
        {
            string S = Console.ReadLine();
            int repeated = (S.Length / SOS.Length);
            StringBuilder expected = new StringBuilder();
            int modified = 0;
            for (int i= 0; i < repeated; ++i)
            {
                expected.Append(SOS);
            }
            if (IsDebug)
            {
                Console.WriteLine("expected: {0}", expected);
                Console.WriteLine("received: {0}", S);
                Console.WriteLine("repeated: {0}", repeated.ToString());
            }
            char[] rgS = S.ToCharArray();
            char[] rgEx = expected.ToString().ToCharArray();
            for (int i = 0; i < S.Length; ++i)
            {
                modified += (rgS[i] != rgEx[i]) ? 1 : 0;
            }
            Console.WriteLine(modified.ToString());
        }
    }
}
