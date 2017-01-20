using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://www.hackerrank.com/challenges/count-scorecards?h_r=next-challenge&h_v=zen
/// </summary>
/// <see cref="https://www.hackerrank.com/challenges/count-scorecards"/>
/// <seealso cref="http://stackoverflow.com/questions/25824376/combinations-with-repetitions-c-sharp"/>
/// <seealso cref="https://en.wikipedia.org/wiki/Gray_code"/>
/// <seealso cref="http://stackoverflow.com/questions/4166106/the-nth-gray-code"/>
/// <seealso cref="http://mathworld.wolfram.com/GrayCode.html"/>
/// <seealso cref="https://blogs.msdn.microsoft.com/oldnewthing/20080812-00/?p=21273"/>
/// <seealso cref="http://stackoverflow.com/questions/11208446/generating-permutations-of-a-set-most-efficiently"/>
/// <seealso cref="http://stackoverflow.com/questions/4635041/permutation-of-array-items"/>
/// <seealso cref="http://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer?rq=1"/>
/// <seealso cref="http://stackoverflow.com/questions/3844721/algorithm-to-generate-all-permutation-by-selecting-some-or-all-charaters?rq=1"/>
/// <seealso cref="http://stackoverflow.com/questions/4740760/permutations-with-some-fixed-numbers?noredirect=1&lq=1"/>
/// 
namespace ScoreCardCombination
{
    public class Player
    {
        public int ID { get; protected set; }
        public int Score { get; protected set; }
        public int Games { get; protected set; }
        public int[] Scores { get; protected set; }
        public int[] ScorePattern { get; protected set; }
        public Dictionary<int, int> FixedScores { get; protected set; }

        public Player(int id, int score, int games)
        {
            ID = id;
            Score = score;
            Games = games;
            Scores = new int[Games];
        }
        protected void FillMyScoreCard()
        {
            for (int i = 0; i < Games; ++i)
            {
                if (Score == -1)
                {
                    // win count unknown, guess
                    Scores[i] = i;
                }
                else
                {
                    // count of wins is known
                    Scores[i] = Score;
                }
            }
        }
        protected int MyScores(int game)
        {
            return Scores[game];
        }
        public int ScoreNext(int matchId, int[] scoreCard)
        {
            int myScore = 0;
            myScore = MyScores(matchId);

            return myScore;
        }
    }
    public class Permutations
    {
        public int NItems { get; protected set; }
        public int RAtATime { get; protected set; }
        public Permutations(int n, int r)
        {
            NItems = n;
            RAtATime = r;
        }
        public int Permute()
        {
            int nItemFact = 1;
            int nmr = (NItems - RAtATime);
            for (int n = NItems; n > nmr; n--)
            {
                nItemFact *= n;
            }
            return nItemFact;
        }
    }
    public class ScoreCard
    {
        public int PlayerCount { get; protected set; }
        public int[] RecordedScores { get; protected set; }
        public int MaxWins { get; protected set; }
        public int PlayerMaxWins { get; protected set; }

        public ScoreCard(int playerCount, int[] scores)
        {
            PlayerCount = playerCount;
            RecordedScores = scores;
        }

        // note: each player plays N - 1 games
        // if (score = -1) {value can be one of all possible values}
        // for N > 2 there are N wins, (p[0], p[1]), ... (p[N-2], p[N-1]); (p[0], p[N-1])
        // where one player can win N - 1 matches and 1 player can win a maximu of N - 1 matches
        // {-1, -1, -1} N = 3, N-1 = 2
    }
    class Solution
    {
#if DEBUG 
        static bool IsDebug = true;
#else
        static bool IsDebug = false;
#endif
        static int Permute(int n, int k)
        {
            int lowest = n - k;
            int p = 1;
            for (int i = n; i > k; --i)
            {
                p *= i;
            }
            return p;
        }
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
        static int WinsReported(int[] scorePattern)
        {
            int reported = 0;
            foreach (int s in scorePattern)
            {
                reported += (s < 0) ? 0 : s;
            }
            return reported;
        }
        static void ScoreCount(int[] scores)
        {
            int ncount = 0;
            int k = 1;
            foreach (int i in scores)
            {
                ncount += (i < 0) ? 1 : 0;
            }
            int p = Permute(ncount, k);
            if (IsDebug)
            {
                Console.WriteLine("{0:d} items, taken {1:d} at a time, permutations: {2:d}", ncount, k, p);
            }
            Console.WriteLine(p.ToString());
        }
        static void Main(string[] args)
        {
            // Number of test-cases
            int T = Int32.Parse(Console.ReadLine());
            for (int l = T; l > 0; l--)
            {
                // number of score-counts on score-card
                // size of the first message (with missing items)
                int N = Convert.ToInt32(Console.ReadLine());

                // line of score-counts
                string scores = Console.ReadLine().Trim();
                int[] scorecardPattern = scores.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                int gp = GamesPlayed(N, 2);
                int gwr = WinsReported(scorecardPattern);
                if (IsDebug)
                {
                    Console.WriteLine("N: {0:d}", N);
                    Console.WriteLine("Games Played {0:d}", gp);
                    Console.WriteLine("wins reported: {0:d}", gwr);
                }
                if (gwr < gp)
                {
                    ScoreCount(scorecard);
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
