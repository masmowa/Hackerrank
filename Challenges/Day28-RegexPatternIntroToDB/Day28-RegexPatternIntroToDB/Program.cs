using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day28_RegexPatternIntroToDB
{
    public class Contact
    {
#if DEBUG
        public static bool IsDebug = true;
#else
        public static bool IsDebug = false;
#endif
        // regex from: http://stackoverflow.com/questions/5342375/regex-email-validation
        // and http://www.rhyous.com/2010/06/15/regular-expressions-in-cincluding-a-new-comprehensive-email-pattern/
        // for extensive pattern see: 
        static string emailregex = 
            @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
            + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public int Key { get; protected set; }
        public string SKey { get { return SKeyGen(); }  }

        public Contact(string name, string email)
        {
            Email = email;
            Name = name;
            Key = KeyGen();
            SKeyGen();
        }

        public int KeyGen ()
        {
            int hash = 17; // something prime
            hash = (hash * 23) + ((Name == null) ? 0 : Name.GetHashCode());
            hash = (hash * 23) + ((Email == null) ? 0 : Email.GetHashCode());

            return hash;
        }
        public string SKeyGen()
        {
            string[] parts = Email.Split('@');
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(Email);
            return sb.ToString();
        }
        public bool InDomain(string pattern)
        {
            bool result = false;
            string[] parts = Email.Split('@');
            if (IsDebug)
            {
                Console.WriteLine("email: {0} pattern: {1}", Email, pattern);
                Console.WriteLine(string.Join(" ", parts));
            }
            if (parts.Length == 2)
            {
                if (parts[1] == pattern)
                {
                    result = true;
                }
            }
            return result;
        }
        public static bool InDomain(string email, string pattern)
        {
            bool result = false;
            string[] parts = email.Split('@');
            if (IsDebug)
            {
                Console.WriteLine("email: {0} pattern: {1}", email, pattern);
            }
            if (parts.Length == 2)
            {
                if (parts[1] == pattern)
                {
                    result = true;
                }
            }
            return result;
        }
    }
    class Solution
    {
#if DEBUG
        public static bool IsDebug = true;
#else
        public static bool IsDebug = false;
#endif
        static void Main(string[] args)
        {
            //List<KeyValuePair<string, string>> contacts = new List<KeyValuePair<string, string>>(); // Dictionary<string, Contact>();
            List<Contact> contacts = new List<Contact>();
            int N = Convert.ToInt32(Console.ReadLine());
            //string google = "google.com";
            string gmail = "gmail.com";
            for (int a0 = 0; a0 < N; a0++)
            {
                string[] tokens_firstName = Console.ReadLine().Split(' ');
                string firstName = tokens_firstName[0];
                string emailID = tokens_firstName[1];
                contacts.Add(new Contact(firstName, emailID));
            }
            contacts = (from s in contacts
                        orderby s.Name ascending
                        select s).ToList();
            foreach (var item in contacts)
            {
                if (IsDebug)
                {
                    Console.WriteLine("{0}: [{1}]", item.Name, item.Email);
                }
                if (item.InDomain(gmail))
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
