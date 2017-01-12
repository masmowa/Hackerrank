using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_MissingNumbers
{
    class AMessage
    {
        public int[] Message { get; protected set; }
        public int Ct { get; protected set; }
        public Dictionary<int, int> Items { get; protected set; }
        public int Max { get; protected set; }
        public int Min { get; protected set; }
        protected int _outInt;
        public int[] freqct;

        public AMessage(int count, int[] list)
        {
            Message = list;
            Ct = count;
            _outInt = 0;
            if (Ct != Message.Length)
            {
                Console.WriteLine("List length = {0:d} != count = {1:d}", Message.Length, Ct);
            }
            Items = new Dictionary<int, int>();
            freqct = new int[10001];
            CountElements();
        }

        /// <summary>
        /// The difference between maximum and minimum number in B is less than or equal to 100.
        /// </summary>
        public void CountElements()
        {
            bool isFirst = true;
            // count each element for the message
            foreach (int val in Message)
            {
                if (isFirst)
                {
                    Max = val;
                    Min = val;
                    isFirst = false;
                }
                else
                {
                    Max = (Max < val) ? val : Max;
                    Min = (Min > val) ? val : Min;
                }
                if (!Items.TryGetValue(val, out _outInt))
                {
                    Items.Add(val, 1);
                }
                else
                {
                    Items[val] += 1;
                }
            }
            if ((Max - Min) >= 101)
            {
                Console.WriteLine("Message elements out of range");
            }
            FrCt();
        }

        public void FrCt()
        {
            foreach (int item in Message)
            {
                freqct[item] -= 1;
            }
        }

        public void ReptMissing(int[] msg)
        {
            foreach (int val in msg)
            {
                freqct[val] += 1;
            }
            for (int i= 1; i < freqct.Length; ++i)
            {
                if (freqct[i] != 0)
                {
                    Console.Write("{0} ", i.ToString());
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// You have to print all the missing numbers in ascending order.
        /// </summary>
        /// <param name="master"></param>
        /// <remarks>
        /// Print each missing number once, even if it is missing multiple times.
        /// </remarks>
        /// <note>
        /// Key : 1 <= key <= 10000 where key is an element of complete message
        /// range: the range of items in message is 100, so  msg.Max - msg.Min <= 100
        /// </note>
        public void ReportMissing(Dictionary<int, int> master)
        {
            // for each item in master, 
            foreach (var kvp in master)
            {
                // is master item in copy message?
                if (!Items.TryGetValue(kvp.Key, out _outInt))
                {
                    // no, report missing item
                    Console.Write("{0:d} ", kvp.Key);
                }
                else
                {
                    // If a number occurs multiple times in the lists, you 
                    // must ensure that the frequency of that number in both 
                    // lists is the same. If that is not the case, 
                    // then it is also a missing number.

                    // yes, is item same frequency?
                    if (kvp.Value != _outInt)
                    {
                        // no, report missing item
                        Console.Write("{0:d} ", kvp.Key);
                    }
                }
            }
            Console.WriteLine();
        }
        public bool Bigger(int val)
        {
            return (Message.Length > val);
        }
    }
    class Solution
    {
        static void Main(string[] args)
        {
            // size of the first message (with missing items)
            int ctFirst = Convert.ToInt32(Console.ReadLine());

            // copy of first message
            // Split to array of strings, seperated by spaces
            // convert each value to Int32
            // store in integer array
            int[] first = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            // message processor
            AMessage msgA = new AMessage(ctFirst, first);

            // size of second message, contains all items in  slghtly different order
            int ctSecond = Convert.ToInt32(Console.ReadLine());

            // copy of second message
            int[] second = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            // message processor
            AMessage msgB = new AMessage(ctSecond, second);

            msgA.ReptMissing(second);
      }
    }
}
