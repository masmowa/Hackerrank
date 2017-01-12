using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _30docNo2_count_div_by_digit
{
    class Program
    {
        static void Main(string[] args)
        {
            string sv = Console.ReadLine();
            //Console.WriteLine("lines: {0}", sv);
            int t = Convert.ToInt32(sv);
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                //int decimalDigets = countDecDigits(n);
                //Console.WriteLine("number of digits in {0}: {1}", n.ToString(), decimalDigets.ToString());
                int digcount = countDivByDigit(n);
                //Console.WriteLine("input: {0:d} count: {1:d}", n, digcount);
                Console.WriteLine("{0:d}", digcount);

            }
            //ConsoleKey key = Console.ReadKey().Key;
        }
        static int countDivByDigit(int input)
        {
            int digitDivideCount = 0;
            int workval = input;
            int theDigit = workval % 10;
            while (workval > 0)
            {
                if ((theDigit > 0) && (input % theDigit) == 0)
                {
                    digitDivideCount++;
                }
                int twork = (workval - theDigit);
                if (twork >= 10)
                {
                    workval = twork / 10;
                }
                else { workval = twork; }
                theDigit = workval % 10;
            }
            return digitDivideCount;
        }
        static int countDecDigits(int val)
        {
            int result = 1;
            Console.WriteLine("Input {0}", val.ToString());
            if (val < 10)
            {
                result = 1;
            }
            else
            {
                int tval = val;
                int[] digits = new int[10];
                for (result = 1; tval >= 10; ++result)
                {
                    int remainder = tval % 10;
                    Console.WriteLine("{0} = {1} % 10", remainder.ToString(), tval.ToString());
                    int noLowDigit = (tval - remainder);
                    int tdiv10 = noLowDigit / 10;
                    digits[result - 1] = remainder;
                    Console.WriteLine("{0} = ({1} - {2}) / 10", tdiv10.ToString(), tval.ToString(), remainder.ToString());
                    Console.Write("{0}/10 = ", noLowDigit.ToString());
                    //tval /= 10;
                    Console.WriteLine("{0}", tdiv10.ToString());
                    tval = tdiv10;
                }
            }
            return result;
        }
    }
}
