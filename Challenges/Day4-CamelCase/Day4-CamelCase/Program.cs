using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_CamelCase
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            StringBuilder SB = new StringBuilder();

            foreach (char C in s)
            {
                if (Char.IsUpper(C))
                {
                    SB.Append(' ');
                }
                SB.Append(C);
            }
            string[] words = SB.ToString().Split(' ');
            Console.WriteLine(words.Length.ToString());
        }
    }
}
