using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarCypher
{
    class Solution
    {
        static char [] alphaLower = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
#if DEBUG
        static bool IsDebug = true;
#else
        static bool IsDebug = false;
#endif

        static char EncodeLower(char ch, int key)
        {
            int chIndex = -1;
            for (int i = 0; i < alphaLower.Length; ++i)
            {
                if (ch == alphaLower[i])
                {
                    chIndex = i;
                    break;
                }
            }
            
            int encodedIndex = (chIndex + key) % alphaLower.Length;
            return alphaLower[encodedIndex];

        }
        static char EncodeUpper(char ch, int key)
        {
            char lowerEnc = EncodeLower(char.ToLower(ch), key);
            return char.ToUpper(lowerEnc);
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            int k = Convert.ToInt32(Console.ReadLine());
            StringBuilder sbe = new StringBuilder();
            if (IsDebug)
            {
                Console.WriteLine(s);
            }
            if (k >= 0)
            {
                foreach (char ch in s)
                {
#if true
                    if (char.IsLetter(ch))
                    {
                        if (char.IsLower(ch))
                        {
                            sbe.Append(EncodeLower(ch, k));
                        }
                        else if (char.IsUpper(ch))
                        {
                            sbe.Append(EncodeUpper(ch, k));
                        }
                    }
                    else
                    {
                        sbe.Append(ch);
                    }
#else
                    if (char.IsPunctuation(ch))
                    {
                        sbe.Append(ch);
                    }
                    else if (char.IsSymbol(ch))
                    {
                        sbe.Append(ch);
                    }
                    else if (char.IsWhiteSpace(ch))
                    {
                        sbe.Append(ch);
                    }
                    else if (char.IsNumber(ch))
                    {
                        sbe.Append(ch);
                    }
                    else if (char.IsLower(ch))
                    {
                        sbe.Append(EncodeLower(ch, k));
                    }
                    else if (char.IsUpper(ch))
                    {
                        sbe.Append(EncodeUpper(ch, k));
                    }
#endif
                }
                Console.WriteLine(sbe.ToString());
            }
            else
            {
                if (IsDebug)
                {
                    Console.WriteLine("invalid Key {0}", k.ToString());
                }
            }
        }
    }
}
