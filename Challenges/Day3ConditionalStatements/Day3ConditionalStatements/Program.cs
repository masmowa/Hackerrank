﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***
 * Objective 
In this challenge, we're getting started with conditional statements. 
Check out the Tutorial tab for learning materials and an instructional 
video! 


Task 
Given an integer, n, perform the following conditional actions:

If n is odd, print Weird
If n is even and in the inclusive range of 2 to 5, print Not Weird
If n is even and in the inclusive range of 6 to 20, print Weird
If n is even and greater than 20, print Not Weird
Complete the stub code provided in your editor to print whether or not n is weird.

Input Format

A single line containing a positive integer, n.

Constraints
 1 <= n <= 100
 
Output Format

Print Weird if the number is weird; otherwise, print Not Weird.

Sample Input 0

3
Sample Output 0

Weird
Sample Input 1

24
Sample Output 1

Not Weird
Explanation

Sample Case 0: n = 3 
n is odd and odd numbers are weird, so we print Weird.

Sample Case 1:  
n > 20 and n is even, so it isn't weird. Thus, we print Not Weird.
 * 
 ***/


namespace Day3ConditionalStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            string weird = "Weird";
            string notweird = "Not " + weird;
            if ((N % 2) != 0)
            {
                Console.WriteLine("Weird");
            }
            else if (1 < N && N < 6 && ((N % 2) == 0))
            {
                Console.WriteLine( notweird );
            }
            else if (5 < N && N < 21 && ((N % 2) == 0))
            {
                Console.WriteLine(weird);
            }
            else if (((N % 2) == 0))
            {
                Console.WriteLine(notweird);
            }
        }
    }
}
