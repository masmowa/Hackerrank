using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_InheritancePersonStudent
{
    public class Person
    {
        protected string firstName;
        protected string lastName;
        protected int id;

        public Person() { }
        public Person(string firstName, string lastName, int identification)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = identification;
        }
        public void printPerson()
        {
            Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
        }
    }
    public class Student : Person
    {
        private int[] testScores;
        public Student() { }
        public Student(string firstName, string lastName, int identification, int[] scores) : base(firstName, lastName, identification)
        {
            testScores = scores;
        }
        public char calculate()
        {
            int sumScores = 0;
            foreach (int score in testScores)
            {
                sumScores += score;
            }
            int avgScore = sumScores / testScores.Length;
            char result = 'T';
            if (avgScore >= 90 && avgScore <= 100)
            {
                result = 'O';
            }
            else if (avgScore >= 80 && avgScore < 90)
            {
                result = 'E';
            }
            else if (avgScore >= 70 && avgScore < 80)
            {
                result = 'A';
            }
            else if (avgScore >= 55 && avgScore < 70)
            {
                result = 'P';
            }
            else if (avgScore >= 40 && avgScore < 55)
            {
                result = 'D';
            }
            else
            {
                result = 'T';
            }

            return result;
        }
    }
    class Solution
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split();
            string firstName = inputs[0];
            string lastName = inputs[1];
            int id = Convert.ToInt32(inputs[2]);
            int numScores = Convert.ToInt32(Console.ReadLine());
            inputs = Console.ReadLine().Split();
            int[] scores = new int[numScores];
            for (int i = 0; i < numScores; i++)
            {
                scores[i] = Convert.ToInt32(inputs[i]);
            }

            Student s = new Student(firstName, lastName, id, scores);
            s.printPerson();
            Console.WriteLine("Grade: " + s.calculate() + "\n");
        }
    }
}
