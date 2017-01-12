using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given the expected and actual return dates for a library book, create a program that calculates the fine (if any). The fee structure is as follows:
/// 1. if Book returned on or before the expected return date, no fine will be charged (eg. fine = 0)
/// 2. If the book is returned after the expected return day but still within the same calendar month and year as the expected return date
/// fine = 15 Hackos * (number of days late)
/// 3. If the book is returned after the expected return month but still within the same calendar year as the expected return date, 
/// the fine = 500 hackos * (number of months late)
/// 4. If the book is returned after the calendar year in which it was expected, there is a fixed fine of 10000 Hackos
/// </summary>
/// <input-format>
/// The first line contains 3 space-separated integers denoting the respective date, month, and year 
/// on which the book was actually returned. 
/// The second line contains 3 space-separated integers denoting the respective date, month, and year 
/// on which the book was expected to be returned(due date).
/// </input-format>
/// <constraints>
/// 1 <= D <= 31
/// 1 <= M <= 12
/// 1 <= Y <= 3000
/// </constraints>
/// <output-format>
/// </output-format>
namespace Day26_NestedLogic
{
    class Solution
    {
        static bool DateValid(int val)
        {
            return ((1 <= val) && (val <= 31));
        }
        static bool MonthValid(int val)
        {
            return ((1 <= val) && (val <= 12));
        }
        static bool YearValid(int val)
        {
            return ((1 <= val) && (val <= 3000));
        }
        static bool InputValid(int[] returned, int[] duedate)
        {
            bool valid = ((DateValid(returned[0]) && MonthValid(returned[1]) && YearValid(returned[2]))
                && (DateValid(duedate[0]) && MonthValid(duedate[1]) && YearValid(duedate[2])));
            return valid;
        }
        static int ComputeFine(int[] returned, int[] duedate)
        {
            int deltaDays = returned[0] - duedate[0];
            int deltaMonth = returned[1] - duedate[1];
            int deltaYears = returned[2] - duedate[2];

            int yearFine = (deltaYears > 0) ? 10000 : 0;
            int monthFine = (deltaMonth > 0 && deltaYears == 0) ? 500 * deltaMonth : 0;
            int dayFine = (deltaDays > 0 && deltaYears == 0 && deltaMonth == 0) ?  15 * deltaDays : 0;
            int fine = ((yearFine > 0) ? yearFine : ((monthFine > 0) ? monthFine : (dayFine)));
            return fine;
        }
        static void Main(string[] args)
        {
            int[] returned = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int[] duedate = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            if (InputValid(returned, duedate))
            {

                int fine = ComputeFine(returned, duedate);
                Console.WriteLine("{0:d}", fine);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
