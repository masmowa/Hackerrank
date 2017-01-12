using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pangrams
{
    class Solution
    {
        static char[] alphabetChars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        
        static bool IncludesAlphabet(string input, string alphabet)
        {
            bool result = true;
            string testin = input.ToLower();
            foreach (char ch in alphabet)
            {
                if (testin.IndexOf(ch) == -1)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        static bool IsPangram(string input)
        {
            string alphabet = new string(alphabetChars);
            return IncludesAlphabet(input, alphabet);
        }
        static void Main(string[] args)
        {
            string prefix = "not ";
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            string s = Console.ReadLine();

            if (IsPangram(s))
            {
                prefix = "";
            }
            Console.WriteLine("{0}pangram", prefix);
        }
    }
}
