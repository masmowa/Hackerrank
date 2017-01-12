using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***
 * Two Characters
Day4-TwoCharacters
String t always consists of two distinct alternating characters. For 
example, if string t's two distinct characters are x and y, then t could 
be xyxyx or yxyxy but not xxyy or xyyx. 



You can convert some string s to string t by deleting characters from s. 
When you delete a character from s, you must delete all occurrences of 
it in s. For example, if s = abaacdabd and you delete the character a, 
then the string becomes bcdbd. 



Given s, convert it to the longest possible string t. Then print the 
length of string t on a new line; if no string t can be formed from s, 
print 0 instead. 



Input Format

The first line contains a single integer denoting the length of s. 
The second line contains string s.

Constraints
1 <= s <= 1000

s only contains lowercase English alphabetic letters (i.e., a to z).
Output Format

Print a single integer denoting the maximum length of t for the given s; 
if it is not possible to form string t, print 0 instead. 



Sample Input

10
beabeefeab

Sample Output

5

Explanation

The characters present in s are a, b, e, and f. This means that t must 
consist of two of those characters. 



If we delete e and f, the resulting string is babab. This is a valid t 
as there are only two distinct characters (a and b), and they are 
alternating within the string. 



If we delete a and f, the resulting string is bebeeeb. This is not a 
valid string because there are three consecutive e's present. 



If we delete only e, the resulting string is babfab. This is not a valid 
string because it contains three distinct characters. 



Thus, we print the length of babab, which is 5, as our answer.
 * 
 ***/
namespace Day4_TwoCharacters
{
    public class TwoCharWord
    {
        public string Input { get; protected set; }
        static Dictionary<char, int> inputCharSet = new Dictionary<char, int>();
        private static int _outInt = 0;
        // element or member are acceptable names
        private List<string> elementList;
        protected char[] WordElements;
        const int CAPACITY = 32;
        public List<string> WordList { get; protected set; }
        public List<string> BadWordList { get; protected set; }
        public bool IsDebug { get; protected set; }

        public TwoCharWord(string input)
        {
            Input = input;
            elementList = new List<string>(CAPACITY);
            WordList = new List<string>(CAPACITY);
            BadWordList = new List<string>(CAPACITY);
#if DEBUG //&& false
            IsDebug = true;
#else
            IsDebug = false;
#endif
            MakeInputCharSet();
            MakeWordElementList();

        }
        private void DumpInputCharSet()
        {
            if (IsDebug)
            {
                Console.Write("Input Character set:\n");
                foreach (var kvp in inputCharSet)
                {
                    Console.Write(kvp.Key);
                }
                Console.WriteLine("\n");

                foreach (var kvp in inputCharSet)
                {
                    Console.WriteLine("char : {0} count : {1}", kvp.Key, kvp.Value);
                }
            }
        }
        protected void MakeInputCharSet()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in Input)
            {
                if (!inputCharSet.TryGetValue(ch, out _outInt))
                {
                    inputCharSet.Add(ch, 1);
                    sb.Append(ch);
                }
                else
                {
                    inputCharSet[ch] += 1;
                }
            }

            WordElements = sb.ToString().ToCharArray();
            DumpInputCharSet();
        }
        private void DumpWordElementList()
        {
            if (IsDebug)
            {
                Console.WriteLine("Length of ElementList: {0}", elementList.Count.ToString());
                string line = string.Join(",", elementList.ToArray());
                Console.WriteLine(line);
            }
        }

        delegate int IndexDelegate(int x, int max);

        protected void MakeWordElementList()
        {
            char firstElement = WordElements[0];
            StringBuilder sb = new StringBuilder();
            IndexDelegate xd = (n, m) => ((n < m) ? n :  0);

            for (int i=0; i < WordElements.Length; ++i, firstElement = WordElements[xd(i, WordElements.Length)])
            {
                sb.Append(firstElement);
                for (int j=i+1; j < WordElements.Length; ++j)
                {
                    sb.Append(WordElements[j]);
                    string elem = new string(sb.ToString().ToCharArray());

                    if ((elementList != null))
                    {
                        elementList.Add(elem);
                    }
                    sb.Clear();
                    sb.Append(firstElement);
                }
                sb.Clear();
            }
            DumpWordElementList();
        }

        public void BuildTwoCharAltCharWords()
        {
            bool valid = false;
            foreach (string els in elementList)
            {
                valid = BuildSingleTwoCharWord(els);
                if (!valid)
                {
                    if (IsDebug)
                    {
                        Console.WriteLine("no valid string with character elements {0}", els);
                    }
                }
            }
        }
        protected bool BuildSingleTwoCharWord(string allowedElements)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();

            foreach (char ch in Input)
            {
                if (allowedElements.Contains(ch))
                {

                    // verify that the next character does not match the previous character
                    // this would mean we have non-alternating characters, 
                    // even if the character is in the allowedElements list.
                    if (sb.Length > 1)
                    {
                        if (sb.ToString()[sb.Length - 1] != ch)
                        {
                            sb.Append(ch);
                        }
                        else
                        {
                            // not alternating
                            result = false;
                            // add truncated string for documentation
                            BadWordList.Add(sb.ToString());
                            break;
                        }
                    }
                    else
                    {
                        sb.Append(ch);
                        if (sb.Length == 2 && sb.ToString()[0] == sb.ToString()[1])
                        {
                            result = false;
                            BadWordList.Add(sb.ToString());
                            break;
                        }
                        result = true;
                    }
                }
            }
            if (IsDebug)
            {
                Console.WriteLine("allowed: [{0}] : string [{1}] : length: {2};", allowedElements, sb.ToString(), sb.Length.ToString());
            }
            if (result)
            {
                WordList.Add(sb.ToString());
            }
            return result;
        }
        public void DumpTwoCharWrodList()
        {
            Console.WriteLine("Word List: ");
            Console.WriteLine("count: {0:d}", WordList.Count);
            foreach (string word in WordList)
            {
                Console.WriteLine("w : {0}; count : {1:d} ", word, word.Length);
            }
        }
        public int LongestTwoCharWord()
        {
            int result = 0;
            string longest = ((WordList != null && WordList.Any<string>()) ? WordList[0] : "");
            foreach (string word in WordList)
            {
                if (longest.Length < word.Length)
                {
                    longest = word;
                }
            }
            
            result = longest.Length;
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int len = Convert.ToInt32(Console.ReadLine());
            if (len >= 2)
            {
                string s = Console.ReadLine();
                //Console.WriteLine("count: {0:d}; string: {1}", len, s);
                StringBuilder sb = new StringBuilder();
                StringBuilder sbUniques = new StringBuilder();

                TwoCharWord wds = new TwoCharWord(s);
                wds.BuildTwoCharAltCharWords();
                //wds.DumpTwoCharWrodList();
                int lw = wds.LongestTwoCharWord();
                Console.WriteLine(lw.ToString());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
