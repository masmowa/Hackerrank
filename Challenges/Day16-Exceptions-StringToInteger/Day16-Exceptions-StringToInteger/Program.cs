using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16_Exceptions_StringToInteger
{
    class Solution
    {
        static void Main(string[] args)
        {
            string S = Console.ReadLine();
            try
            {
                int val = Convert.ToInt32(S);
                Console.WriteLine(val.ToString());
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Bad String.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Bad String.");
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Bad String.");
            }
        }
    }
}
