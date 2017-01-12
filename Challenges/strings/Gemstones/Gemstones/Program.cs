using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemstones
{
    class Solution
    {
#if DEBUG
        static bool IsDebug = true;
#else
        static bool IsDebug = false;
#endif
        const int MINIMUM = 32;

        /// <summary>
        /// make a list of the elements in the rock
        /// </summary>
        /// <param name="rock"></param>
        /// <returns></returns>
        static private string ElementsInRock(string rock)
        {
            Dictionary<char, int> rockEl = new Dictionary<char, int>();
            StringBuilder sbRock = new StringBuilder();
            int _OutVal = -1;
            foreach (char ch in rock)
            {
                if (!rockEl.TryGetValue(ch, out _OutVal))
                {
                    rockEl.Add(ch, 1);
                    sbRock.Append(ch);
                }
                else
                {
                    rockEl[ch] += 1;
                }
            }
            char[] rgRock = sbRock.ToString().ToCharArray();
            Array.Sort(rgRock);
            return new string(rgRock);
        }
        static void CountGemElements(List<string> rocks)
        {
            Dictionary<char, int> elementCount = new Dictionary<char, int>();
            List<string> rockEls = new List<string>();

            int gemcount = 0;
            string elements;
            bool r1 = false;
            int _outval = -1;
            foreach (string rock in rocks)
            {
                elements = ElementsInRock(rock);
                if (!r1)
                {
                    r1 = true;
                    // prime element count with list of elements
                    foreach (char el in elements)
                    {
                        if (!elementCount.TryGetValue(el, out _outval))
                        {
                            elementCount.Add(el, 0);
                        }
                    }
                }
                rockEls.Add(elements);
            }
            foreach (string rkel in rockEls)
            {
                foreach (char el in rkel)
                {
                    if (elementCount.TryGetValue(el, out _outval))
                    {
                        elementCount[el] += 1;
                    }
                }
            }
            if (IsDebug)
            {
                Console.WriteLine("Elements:");
                foreach (var kvp in elementCount)
                {
                    Console.WriteLine("EL : {0} count : {1}", kvp.Key, kvp.Value.ToString());
                    if (kvp.Value == rockEls.Count)
                    {
                        gemcount += 1;
                    }
                }
            }
            Console.WriteLine(gemcount.ToString());
        }

        static void Main(string[] args)
        {
            List<string> cases = new List<string>(MINIMUM);
            int TestCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < TestCases; i++)
            {
                cases.Add(Console.ReadLine());
            }
            if (IsDebug)
            {
                Console.WriteLine("Number of Test cases: {0:d}", TestCases);
                foreach (string s in cases)
                {
                    Console.WriteLine(s);
                }
            }
            CountGemElements(cases);
        }
    }
}
