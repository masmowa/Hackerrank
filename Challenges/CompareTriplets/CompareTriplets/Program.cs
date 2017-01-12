using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * Alice and Bob each created one problem for HackerRank. A reviewer rates the two challenges,
 * awarding points on a scale from  to  for three categories: problem clarity, 
 * originality, and difficulty.
 * We define the rating for Alice's challenge to be the triplet , and the rating for 
 * Bob's challenge to be the triplet .
 * Your task is to find their comparison scores by comparing  with ,  with , and  with .

 * If a[i] > b[i], then Alice is awarded 1 point.
 * If a[i] < b[i], then Bob   is awarded  1 point.
 * If a[i] = b[i], then neither person receives a point.
 * Given A and B, can you compare the two challenges and print their respective comparison points?
 * Input Format
 * The first line contains 3 space-separated integers, a[0], a[1], and a[2], describing the respective values in triplet A. 
 * The second line contains 3 space-separated integers, b[0], b[1], and b[2], describing the respective values in triplet B.
 * Constraints
 *  1 <= a[i] <= 100
 *  1 <= b[i] <= 100
 * Output Format
 * Print two space-separated integers denoting the respective comparison scores earned by Alice and Bob.
 * Sample Input
 * 5 6 7
 * 3 6 10
 * Sample Output
 * 1 1 
 * 
 */
namespace CompareTriplets
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens_a0 = Console.ReadLine().Split(' ');
            int a0 = Convert.ToInt32(tokens_a0[0]);
            int a1 = Convert.ToInt32(tokens_a0[1]);
            int a2 = Convert.ToInt32(tokens_a0[2]);
            string[] tokens_b0 = Console.ReadLine().Split(' ');
            int b0 = Convert.ToInt32(tokens_b0[0]);
            int b1 = Convert.ToInt32(tokens_b0[1]);
            int b2 = Convert.ToInt32(tokens_b0[2]);
        }
    }
}
