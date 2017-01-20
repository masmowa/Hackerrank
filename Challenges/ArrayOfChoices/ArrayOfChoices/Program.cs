using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfChoices
{
    class Program
    {
#if DEBUG
        public static bool IsDebug = true;
#else
        public static bool IsDebug = false;
#endif
        public static int PLAYERS_PER_GAME = 2;
        //-----------------------------------------------------------------------------
        /*
            Method: PrintArray()
        */
        // NOTE: In .NET 4.0 use:
        // Console.WriteLine(string.Join(" ", arr));
        //
        private static void PrintArray(int[] arr, string label = "")
        {
            Console.WriteLine(label);
            Console.Write("{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i < arr.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("}");
        }
        //-----------------------------------------------------------------------------

        /*
            Method: swap(ref int a, ref int b)

        */
        private static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static IEnumerable<IEnumerable<T>> QuickPermErez<T>(this IEnumerable<T> set)
        {
            int N = set.Count();
            int[] a = new int[N];
            int[] p = new int[N];

            var yieldRet = new T[N];

            List<T> list = new List<T>(set);

            int i, j, tmp; // Upper Index i; Lower Index j

            for (i = 0; i < N; i++)
            {
                // initialize arrays; a[N] can be any type
                a[i] = i + 1; // a[i] value is not revealed and can be arbitrary
                p[i] = 0; // p[i] == i controls iteration and index boundaries for i
            }
            yield return list;
            //display(a, 0, 0);   // remove comment to display array a[]
            i = 1; // setup first swap points to be 1 and 0 respectively (i & j)
            while (i < N)
            {
                if (p[i] < i)
                {
                    j = i % 2 * p[i]; // IF i is odd then j = p[i] otherwise j = 0
                    tmp = a[j]; // swap(a[j], a[i])
                    a[j] = a[i];
                    a[i] = tmp;

                    //MAIN!

                    for (int x = 0; x < N; x++)
                    {
                        yieldRet[x] = list[a[x] - 1];
                    }
                    yield return yieldRet;
                    //display(a, j, i); // remove comment to display target array a[]

                    // MAIN!

                    p[i]++; // increase index "weight" for i by one
                    i = 1; // reset index i to 1 (assumed)
                }
                else
                {
                    // otherwise p[i] == i
                    p[i] = 0; // reset p[i] to zero
                    i++; // set new index value for i (increase by one)
                } // if (p[i] < i)
            } // while(i < N)
        }
        /// <summary>
        /// nCk
        /// </summary>
        /// <param name="N">number of items</param>
        /// <param name="k">k at a time</param>
        /// <returns>nCk</returns>
        static int GamesPlayed(int N, int k)
        {
            int gamesPlayed = 1;
            int lowest = (N - k);
            for (int f = N; f > lowest; --f)
            {
                gamesPlayed *= f;
            }
            return (gamesPlayed / k);
        }
        public static int[] MakePermutationInputArray(int[] scoreMask, int targetSum)
        {
            int len = scoreMask.Length;
            int[] output = new int[len];
            Dictionary<int, int> availableValues = new Dictionary<int, int>();
            for (int i = 0; i < len; ++i)
            {
                availableValues.Add(i, 0);
                output[i] = 0;
            }
            int outsum = output.Sum();
            while (outsum != targetSum)
            {
                for (int i = 0; i < len; ++i)
                {
                    if (IsDebug)
                    {
                        Console.Write("arr { ");
                        Console.Write(string.Join(" ", output));
                        Console.WriteLine(" }");
                        Console.WriteLine("sum {0:d} : nextval {1:d} : target {2:d}", outsum, i, targetSum);
                    }
                    if (scoreMask[i] < 0)
                    {
                        if (outsum + i < targetSum)
                        {
                            output[i] = i;
                            availableValues[i]++;
                        }
                        else
                        {
                            // TODO: PLACE HOLDER
                            output[i] = 1;
                        }
                    }
                    else
                    {
                        output[i] = scoreMask[i];
                    }
                }
                outsum = output.Sum();
            }
            return output;
        }
        static void Main(string[] args)
        {
            int T = Int32.Parse(Console.ReadLine());
            for (int l = T; l > 0; l--)
            {
                // number of score-counts on score-card
                // size of the first message (with missing items)
                int N = Convert.ToInt32(Console.ReadLine());

                // line of score-counts
                string scores = Console.ReadLine().Trim();
                int[] scorecardMask = scores.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                int freedom = 0;
                foreach (int val in scorecardMask)
                {
                    freedom += (val < 0) ? 1 : 0;
                }
                int gamesInQuestion = GamesPlayed(freedom, PLAYERS_PER_GAME);
                if (IsDebug)
                {
                    Console.WriteLine("Games in Question: {0:d}", gamesInQuestion);
                }
                int gp = GamesPlayed(N, 2);
                int[] gwr = new int[N];
                //int[] gwr = MakePermutationInputArray(scorecardMask, gp);
                for (int i = 0; i < N; ++i)
                { 
                    gwr[i] = i;
                }
                var perm = QuickPermErez<int>(gwr);
                if (IsDebug)
                {
                    Console.WriteLine("N: {0:d}", N);
                    Console.WriteLine("Games Played {0:d}", gp);
                    Console.WriteLine("wins card: [{0}]", string.Join(" ", gwr));
                }
            }
        }
    }
}
