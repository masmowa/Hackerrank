using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_PhoneBook
{
    public class PhoneBook
    {
        protected Dictionary<string, string> book;
        PhoneBook()
        {
            book = new Dictionary<string, string>();
        }
        public void Add(string key, string val)
        {
            book.Add(key, val);
        }
        public bool TryFind(string key, out string val)
        {
            return book.TryGetValue(key, out val);
        }
    }
    class Solution
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            // Populate phonebook dictionary
            for (int i = 0; i < n; ++i)
            {
                string line = Console.ReadLine();
                string[] pbEntry = line.Split(' ');
                phoneBook.Add(pbEntry[0], pbEntry[1]);

            }

            // search for name-key
            for (int i = 0; i < n; ++i)
            {
                string searchKey = Console.ReadLine();
                string outval = string.Empty;
                if (phoneBook.TryGetValue(searchKey, out outval))
                {
                    Console.WriteLine("{0}={1}", searchKey, outval);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }
    }
}
