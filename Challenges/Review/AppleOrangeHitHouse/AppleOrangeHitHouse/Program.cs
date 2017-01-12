using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleOrangeHitHouse
{
    public class House
    {
        public int S { get; set; }
        public int T { get; set; }
        public House(int s, int t)
        {
            S = s;
            T = t;
        }
        public void CountHits(int treePos, int[] vals)
        {
            int result = 0;
            foreach (int dist in vals)
            {
                if (HitHouse(treePos, dist))
                {
                    result++;
                }
            }
            Console.WriteLine(result.ToString());
        }

        public bool HitHouse(int treePos, int dist)
        {
            int pos = treePos + dist;

            return ((pos >= S) && (pos <= T));
        }

    }
    class Solution
    {
        static void Main(string[] args)
        {
            // House dimensions
            string[] tokens_s = Console.ReadLine().Split(' ');
            int s = Convert.ToInt32(tokens_s[0]);
            int t = Convert.ToInt32(tokens_s[1]);

            House house = new House(s, t);

            // tree location apple, orange
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);   // apple tree pos
            int b = Convert.ToInt32(tokens_a[1]);   // orange tree pos

            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]); // quantity apples
            int n = Convert.ToInt32(tokens_m[1]); // quantity oranges
                                                  // distance apples fall from tree
            string[] apple_temp = Console.ReadLine().Split(' ');
            int[] apple = Array.ConvertAll(apple_temp, Int32.Parse);
            // distance oranges fall from tree
            string[] orange_temp = Console.ReadLine().Split(' ');
            int[] orange = Array.ConvertAll(orange_temp, Int32.Parse);

            house.CountHits(a, apple);
            house.CountHits(b, orange);
        }
    }
}
