using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Class_vs_Instance
{
    class Person
    {
        public int age;
        public Person(int initialAge)
        {
            // Add some more code to run some checks on initialAge
            if (1 > initialAge)
            {
                Console.WriteLine("Age is not valid, setting age to 0.");
                age = 0;
            }
            else
            {
                age = initialAge;
            }
        }
        public void amIOld()
        {
            string sayThis = ""; 
            // Do some computations in here and print out the correct statement to the console 
            if (age < 13)
            {
                sayThis = "You are young.";
            }
            else if (age >= 13 && age < 18)
            {
                sayThis = "You are a teenager.";
            }
            else
            {
                sayThis = "You are old.";
            }
            Console.WriteLine(sayThis);
        }

        public void yearPasses()
        {
            // Increment the age of the person in here
            age++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int age = int.Parse(Console.In.ReadLine());
                Person p = new Person(age);
                p.amIOld();
                for (int j = 0; j < 3; j++)
                {
                    p.yearPasses();
                }
                p.amIOld();
                Console.WriteLine();
            }
        }
    }
}
