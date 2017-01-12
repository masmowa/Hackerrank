using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***
 * Objective 
In this challenge, you'll work with arithmetic operators. Check out the 
Tutorial tab for learning materials and an instructional video! 



 * Task 
Given the meal price (base cost of a meal), tip percent (the percentage 
of the meal price being added as tip), and tax percent (the percentage 
of the meal price being added as tax) for a meal, find and print the 
meal's total cost. 



Note: Be sure to use precise values for your calculations, or you may 
end up with an incorrectly rounded result! 


 * Input Format

There are 3 lines of numeric input: 
The first line has a double, mealCost (the cost of the meal before tax and tip). 
The second line has an integer, tipPercent (the percentage of mealCost being added as tip). 
The third line has an integer, taxPercent (the percentage of mealCost being added as tax).

 * Output Format

Print The total meal cost is totalCost dollars., where totalCost is the 
rounded integer result of the entire bill (mealCost with added tax and 
tip). 


 * Sample Input

12.00
20
8
Sample Output

The total meal cost is 15 dollars.
Explanation

 * Given: 
mealCost = 12, tipPercent = 20, taxPercent = 8

Calculations: 
 tip = 12 * (20/100) = 2.4
 tax = 12 * (8/100) = 0.96
 totalCost = mealCost + tip + tax = 12.00 + 2.40 + 0.96 = 15.36
 
 

We round  to the nearest dollar (integer) and then print our result:

The total meal cost is 15 dollars.
 ***/

namespace OeratTotalMealCost
{
    class Program
    {
        static void Main(string[] args)
        {
            double mealCost = Convert.ToDouble(Console.ReadLine());
            int tipPercent = Convert.ToInt32(Console.ReadLine());
            int taxPercent = Convert.ToInt32(Console.ReadLine());
            double tax = ComputeTax(mealCost, taxPercent);
            double tip = ComputeTip(mealCost, tipPercent);
            double totalMealCost = mealCost + tip + tax;
            double totalCost = mealCost + tip + tax;
            Console.WriteLine("${0:f} = {1:f} + {2:f} + {3:f}", totalCost, mealCost, tip, tax);
            Console.WriteLine("The total meal cost is {0} dollars.", Math.Round(totalCost));
        }
        static double ComputeTip(double mealCost, int tipPercent)
        {
            return (mealCost * (tipPercent / 100.00));
        }
        static double ComputeTax(double mealCost, int taxPercent)
        {
            return (mealCost * (taxPercent / 100.00));
        }
    
    }
}
