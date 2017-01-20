using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPermutationFinder
{
    class Program
    {
        public Program()
        {
            ValidScoreCards = new List<int[]>();
        }
        void StartS()
        {
            string[] items = new string[5];
            items[0] = "A";
            items[1] = "B";
            items[2] = "C";
            items[3] = "D";
            items[4] = "E";
            new PermutationFinder<string>().Evaluate(items, EvaluateS);
            Console.WriteLine("Valid Score Card count {0:d}", ValidScoreCards.Count().ToString());
            Console.ReadLine();
        }

        public int GamesToPlay { get; protected set; }
        public List<int[]> ValidScoreCards { get; protected set; }
        public static int MAXSCORE = 1;
        public static int PLAYERS = 5;
        public static int PLAYERS_PER_GAME = 2;

        /// <summary>
        /// Choose nCk = N!/k!(N-k)! = N * N-1 * ... * N-(k+1) / k
        /// </summary>
        /// <param name="N">number of items</param>
        /// <param name="k">k at a time</param>
        /// <returns>nCk</returns>
        /// <remarks>
        /// </remarks>
        public int CountGames(int N, int k)
        {
            int gamesPlayed = 1;
            int lowest = (N - k);
            for (int f = N; f > lowest; --f)
            {
                gamesPlayed *= f;
            }
            GamesToPlay = (gamesPlayed / k);
            return GamesToPlay;
        }
        void Start()
        {
            Program.PLAYERS = 3;
            Program.PLAYERS_PER_GAME = 2;
            // winning player cannot win against themselves
            Program.MAXSCORE = Program.PLAYERS - 1;
            int[] items = new int[PLAYERS];
            for (int i=0; i<PLAYERS; ++i)
            {
                items[i] = i;
            }
            int gamesPlayed = CountGames(PLAYERS, PLAYERS_PER_GAME);
            Console.WriteLine("Total Games: {0:d}", gamesPlayed);
            
            new PermutationFinder<int>().Evaluate(items, Evaluate);
            Console.ReadLine();
        }

        public bool Evaluate(int[] items)
        {
            Console.WriteLine(string.Join(" ", items));
            int itemsum = items.Sum();
            if (itemsum == GamesToPlay)
            {
                Dictionary<int, int> wins = new Dictionary<int, int>();
                bool addItems = true;
                int maxWins = 0;
                foreach (int v in items)
                {
                    if (v == Program.MAXSCORE)
                    {
                        maxWins++;
                    }
                }
                if (maxWins > 1)
                {
                    addItems = false;
                }
                if (addItems)
                {
                    ValidScoreCards.Add(items);
                    Console.WriteLine(string.Join(" ", items));
                }
                // add to final list;
                // if not repeat, and not invalid (only 1 player can win N-1 games)
            }
            bool someCondition = false;

            if (someCondition)
                return true;  // Tell the permutation finder to stop.

            return false;
        }
        public bool EvaluateS(string[] items)
        {
            Console.WriteLine(string.Format("{0},{1},{2},{3},{4}", items[0], items[1], items[2], items[3], items[4]));
            bool someCondition = false;

            if (someCondition)
                return true;  // Tell the permutation finder to stop.

            return false;
        }
        static void Main(string[] args)
        {
            new Program().Start();
        }
    }
}
