using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LonelyInteger
{
    class Solution
    {
        static int lonelyinteger(int[] a)
        {
            int outval = 0;
            Dictionary<int, int> li = new Dictionary<int, int>();
            foreach (int i in a)
            {
                if (li.TryGetValue(i, out outval))
                {
                    li[i] += 1;
                }
                else
                {
                    li.Add(i, 1);
                }
            }
            foreach (var kvp in li)
            {
                if (kvp.Value == 1)
                {
                    return kvp.Key;
                }
            }

            return 0;
        }
        static void Main(string[] args)
        {
            int res;

            int _a_size = Convert.ToInt32(Console.ReadLine());
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }
            res = lonelyinteger(_a);
            Console.WriteLine(res);
        }
    }
}
