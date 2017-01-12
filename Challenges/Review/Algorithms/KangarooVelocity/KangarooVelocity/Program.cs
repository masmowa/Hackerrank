using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// for 2 objects that have starting position x and velocity v; will they intersect at some point 
/// by intersect it means land on the same space at the same time
/// </summary>
/// <remarks>
/// A single line of four space-separated integers denoting the respective values of x1, v1, x2, v2
/// Constraints:
/// 0 <= x1 < x2 <= 10000
/// 1 <= v1 <= 10000
/// 1 <= v2 <= 10000
/// </remarks>
/// <sample-input>
/// 0 3 4 2
/// </sample-input>
/// <output>
/// print YES if they can land at the same location at the same time; otherwise, print NO
/// </output>
/// <explanation>
/// x1 = 0
/// v1 = 3
/// x2 = 4
/// v2 = 2
/// 0 -> 3 -> 6 -> 09 -> 12
/// 4 -> 6 -> 8 -> 10 -> 12
/// <result>YES</result>
/// </explanation>
namespace KangarooVelocity
{
    public class Kangaroo
    {
        public int X { get; set; }
        public int V { get; set; }
        public int PosNow { get; set; }
        public Kangaroo(int posx, int velocity)
        {
            X = posx;
            V = velocity;
            PosNow = X;
        }
        public int Move()
        {
            PosNow = (PosNow + V);
            return PosNow;
        }
    }
    class Solution
    {
        static void Main(string[] args)
        {
            string[] tokens_x1 = Console.ReadLine().Split(' ');
            int x1 = Convert.ToInt32(tokens_x1[0]);
            int v1 = Convert.ToInt32(tokens_x1[1]);
            Kangaroo k1 = new Kangaroo(x1, v1);
            int x2 = Convert.ToInt32(tokens_x1[2]);
            int v2 = Convert.ToInt32(tokens_x1[3]);
            Kangaroo k2 = new Kangaroo(x2, v2);
            if (v1 <= v2)
            {
                Console.WriteLine("NO");
            }
            else
            {
                while (k1.PosNow < k2.PosNow)
                {
                    k1.Move();
                    k2.Move();
                    if (k1.PosNow == k2.PosNow)
                    {
                        break;
                    }
                }
            }
            string colided = ((k1.PosNow == k2.PosNow) ? "YES" : "NO");
            Console.WriteLine(colided);
        }
    }
}
