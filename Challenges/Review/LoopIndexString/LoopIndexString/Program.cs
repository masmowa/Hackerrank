using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopIndexString
{
    class Solution
    {
#if false
        static void SplitStringOddEven(string val)
        {
            char[] valar = val.ToCharArray();
            char[] evench = new char[val.Length];
            char[] oddch = new char[val.Length];
            int ievench = 0;
            int ioddch = 0;
            for (int i=0; i < val.Length; ++i)
            {
                if ((i % 2) == 0)
                {
                    evench[ievench++] = valar[i];
                }
                else
                {
                    oddch[ioddch++] = valar[i];
                }
            }
            string streven = new string(evench);
            string strodd = new string(oddch);
            Console.WriteLine("{0} {1}", streven, strodd);
        }
#else
        static void SplitStringOddEven(string val)
        {
            char[] valar = val.ToCharArray();
            for (int i = 0; i < val.Length; ++i)
            {
                if ((i % 2) == 0)
                {
                    Console.Write(valar[i]);
                }
            }
            Console.Write(" ");
            for (int i = 0; i < val.Length; ++i)
            {
                if ((i % 2) != 0)
                {
                    Console.Write(valar[i]);
                }
            }
            Console.WriteLine();
        }
#endif
        static void Main(string[] args)
        {
            // get the count of test cases
            int T = Convert.ToInt32(Console.ReadLine());
            for (int i=0; i < T; ++i)
            {
                string val = Console.ReadLine();
                SplitStringOddEven(val);
            }
        }
    }
}
