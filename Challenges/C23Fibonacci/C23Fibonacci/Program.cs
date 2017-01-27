using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Fibonacci
/// </summary>
/// <see cref="http://rosettacode.org/wiki/Fibonacci_n-step_number_sequences#C.23"/> 
namespace C23Fibonacci
{
    public static class ItFib
    {
        public static IEnumerable<int> Fibonacci()
        {
            var current = 1;
            var b = 0;
            while (true)
            {
                var next = current + b;
                yield return next;
                b = current;
                current = next;
            }
        }

        public static T Nth<T>(this IEnumerable<T> seq, int n)
        {
            return seq.Skip(n - 1).First();
        }
    }
    /// <summary>
    /// use property of squar root of 5
    /// </summary>
    /// <see cref="http://stackoverflow.com/questions/13018278/returning-nth-fibonacci-number-the-sequence"/> 
    /// <seealso cref="https://en.wikipedia.org/wiki/Square_root_of_5#Relation_to_the_golden_ratio_and_Fibonacci_numbers"/>
    /// <seealso cref="http://stackoverflow.com/questions/1580985/finding-fibonacci-sequence-in-c-project-euler-exercise?rq=1"/>
    /// <seealso cref="https://en.wikipedia.org/wiki/Square_root_of_5#Relation_to_the_golden_ratio_and_Fibonacci_numbers"/>
    public class SqrtFib
    {
        static ulong Fib(int n)
        {
            double sqrt5 = Math.Sqrt(5);
            double p1 = (1 + sqrt5) / 2;
            double p2 = -1 * (p1 - 1);


            double n1 = Math.Pow(p1, n + 1);
            double n2 = Math.Pow(p2, n + 1);
            return (ulong)((n1 - n2) / sqrt5);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
#if true
#else
            PrintNumberSequence("Fibonacci", GetNnacciNumbers(2, 10));
            PrintNumberSequence("Lucas", GetLucasNumbers(10));
            PrintNumberSequence("Tribonacci", GetNnacciNumbers(3, 10));
            PrintNumberSequence("Tetranacci", GetNnacciNumbers(4, 10));
            Console.ReadKey();
#endif
        }
        private static IList<ulong> GetLucasNumbers(int length)
        {
            IList<ulong> seedSequence = new List<ulong>() { 2, 1 };
            return GetFibLikeSequence(seedSequence, length);
        }

        private static IList<ulong> GetNnacciNumbers(int seedLength, int length)
        {
            return GetFibLikeSequence(GetNacciSeed(seedLength), length);
        }

        private static IList<ulong> GetNacciSeed(int seedLength)
        {
            IList<ulong> seedSquence = new List<ulong>() { 1 };

            for (uint i = 0; i < seedLength - 1; i++)
            {
                seedSquence.Add((ulong)Math.Pow(2, i));
            }

            return seedSquence;
        }

        private static IList<ulong> GetFibLikeSequence(IList<ulong> seedSequence, int length)
        {
            IList<ulong> sequence = new List<ulong>();

            int count = seedSequence.Count();

            if (length <= count)
            {
                sequence = seedSequence.Take((int)length).ToList();
            }
            else
            {
                sequence = seedSequence;

                for (int i = count; i < length; i++)
                {
                    ulong num = 0;

                    for (int j = 0; j < count; j++)
                    {
                        num += sequence[sequence.Count - 1 - j];
                    }

                    sequence.Add(num);
                }
            }

            return sequence;
        }

        private static void PrintNumberSequence(string Title, IList<ulong> numbersequence)
        {
            StringBuilder output = new StringBuilder(Title).Append("   ");

            foreach (long item in numbersequence)
            {
                output.AppendFormat("{0}, ", item);
            }

            Console.WriteLine(output.ToString());
        }
    }
}
