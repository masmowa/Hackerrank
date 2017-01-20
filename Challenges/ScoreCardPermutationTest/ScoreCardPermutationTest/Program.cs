using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
/// <see cref="http://stackoverflow.com/questions/11208446/generating-permutations-of-a-set-most-efficiently"/>
namespace ScoreCardPermutationTest
{
    public class PermutationsZiezi
    {
#if DEBUG
        public static bool IsDebug = true;
#else
        public static bool IsDebug = false;
#endif
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
        //-----------------------------------------------------------------------------
        /* Method: FindPermutations(n) */
        private static void FindPermutations(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }
            int iEnd = arr.Length - 1;
            Permute(arr, iEnd);
        }
        //-----------------------------------------------------------------------------  
        /* Method: Permute(arr) */
        private static void Permute(int[] arr, int iEnd)
        {
            if (iEnd == 0)
            {
                PrintArray(arr);
                return;
            }

            Permute(arr, iEnd - 1);
            for (int i = 0; i < iEnd; i++)
            {
                swap(ref arr[i], ref arr[iEnd]);
                Permute(arr, iEnd - 1);
                swap(ref arr[i], ref arr[iEnd]);
            }
        }
    }
    static public class PermutationErez
    {
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
    }
    class Program
    {
#if DEBUG
        public static bool IsDebug = true;
#else
        public static bool IsDebug = false;
#endif
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
        public static bool NextPermutation<T>(T[] elements) where T : IComparable<T>
        {
            // More efficient to have a variable instead of accessing a property
            var count = elements.Length;

            // Indicates whether this is the last lexicographic permutation
            var done = true;

            // Go through the array from last to first
            for (var i = count - 1; i > 0; i--)
            {
                var curr = elements[i];

                // Check if the current element is less than the one before it
                if (curr.CompareTo(elements[i - 1]) < 0)
                {
                    continue;
                }

                // An element bigger than the one before it has been found,
                // so this isn't the last lexicographic permutation.
                done = false;

                // Save the previous (bigger) element in a variable for more efficiency.
                var prev = elements[i - 1];

                // Have a variable to hold the index of the element to swap
                // with the previous element (the to-swap element would be
                // the smallest element that comes after the previous element
                // and is bigger than the previous element), initializing it
                // as the current index of the current item (curr).
                var currIndex = i;

                // Go through the array from the element after the current one to last
                for (var j = i + 1; j < count; j++)
                {
                    // Save into variable for more efficiency
                    var tmp = elements[j];

                    // Check if tmp suits the "next swap" conditions:
                    // Smallest, but bigger than the "prev" element
                    if (tmp.CompareTo(curr) < 0 && tmp.CompareTo(prev) > 0)
                    {
                        curr = tmp;
                        currIndex = j;
                    }
                }

                // Swap the "prev" with the new "curr" (the swap-with element)
                elements[currIndex] = prev;
                elements[i - 1] = curr;

                // Reverse the order of the tail, in order to reset it's lexicographic order
                for (var j = count - 1; j > i; j--, i++)
                {
                    var tmp = elements[j];
                    elements[j] = elements[i];
                    elements[i] = tmp;
                }

                // Break since we have got the next permutation
                // The reason to have all the logic inside the loop is
                // to prevent the need of an extra variable indicating "i" when
                // the next needed swap is found (moving "i" outside the loop is a
                // bad practice, and isn't very readable, so I preferred not doing
                // that as well).
                break;
            }

            // Return whether this has been the last lexicographic permutation.
            return done;
        }

        /// <summary>
        /// GamesPlayed are the number of collections, with 
        /// N = number of players
        /// k = number of players per game (ex singles tennis has 2 players, chess has 2 players, doubles tennis has 4 players)
        /// </summary>
        /// <param name="N">total number of players who play game and have matches with each other player</param>
        /// <param name="k">number of players involved in each match</param>
        /// <returns>count of choices with no repeats when choosing k at a time from N objects</returns>
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

        static void Main(string[] args)
        {
            int numPlayers = 3;
            int playersPerGame = 2;
            // the number of wins on a score-card must sum to games played
            int gamesPlayed = GamesPlayed(numPlayers, playersPerGame);
            // no player can win more games than N-1, because they cannot win against themselves
            int maxWinsPerPlayer = numPlayers - 1;
            int numberOfWinsInSession = numPlayers - 1;
            //int numMatches = CollectionsPossible(numPlayers, playersPerGame);
        }
    }
}
