using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day27_GenTestInput
{
    public class TestCase
    {
        public int StudentCount { get; set; }
        public int CancelThreshold { get; set; }
#if BASED_ON_INSTRUCTIONS
            public static int ARRIVAL_TIME_LIMIT = 1001;
        public static int MAX_STUDENTS = 200;
#else
        public static int ARRIVAL_TIME_LIMIT = 21;
        public static int MAX_STUDENTS = 21;
#endif
#if DEBUG
        public static bool IsDebug = true;
#else
        public static bool IsDebug = false;
#endif
        public enum ArrivalDirection
        {
            EARLY = 0,
            ONTIME,
            LATE
        };

        public static List<int> RequiredDirectionLimits = new List<int>() { -1, 0, 1 };
        public static List<bool> ClassCanceledOutput = new List<bool>() { true, false, true, false, true };
        public static int LastTestCase = 0;
        TestCase(int arivalTimeLimit = 20)
        { }
        public static int GetStudentCount()
        {
            Random r = new Random();
            return (int)r.Next(3, MAX_STUDENTS);
        }
        public List<int> MakeTestCase(int studentCount, int cancelThreshold, bool classCanceled)
        {
            Random r = new Random();
            
            List<int> testcase = new List<int>();
            int arrivalTime = 0;
            int direction = 0;

            if (IsDebug)
            {
                Console.WriteLine("students = [{0:d}] threshold = {1:d}", studentCount, cancelThreshold);
            }
            for (int i = 0; i < cancelThreshold; i++)
            {
                arrivalTime = r.Next(1, ARRIVAL_TIME_LIMIT);
                switch ((ArrivalDirection)i)
                {
                    case ArrivalDirection.EARLY:
                        direction = (int)ArrivalDirection.EARLY;
                        break;
                    case ArrivalDirection.ONTIME:
                        direction = (int)ArrivalDirection.ONTIME;
                        break;
                    case ArrivalDirection.LATE:
                        direction = (int)ArrivalDirection.LATE;
                        break;
                    default:
                        // assume student arrives early
                        direction = 0;
                        break;
                }
                
                arrivalTime *= RequiredDirectionLimits[direction];
                if (IsDebug)
                {
                    Console.WriteLine("\tA[{0:d}] = {1:d}", i, arrivalTime);
                }
                testcase.Add(arrivalTime);
            }
            if (classCanceled)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            int remaining = studentCount - cancelThreshold;
            for (int i=0; i <= remaining; i++)
            {
                arrivalTime = r.Next(1, ARRIVAL_TIME_LIMIT);
                arrivalTime *= direction;
                if (IsDebug)
                {
                    Console.WriteLine("\tA[{0:d}] = {1:d}", (cancelThreshold +i), arrivalTime);
                }
                testcase.Add(arrivalTime);

            }

            return testcase;
        }
    }
    class Solution
    { 
        /// <summary>
        /// fill in student array with arrival time to satisfy the criteria
        /// </summary>
        /// <param name="caseID">optional</param>
        /// <param name="classCanceled">boolean to specify if the data should satisfy class canceled criteria
        /// criteria are students arrive after class starts >= cancel threshold</param>
        /// <param name="studentCount">number of items in the list</param>
        /// <param name="cancelThreshold">number of students that must have arrival time <= 0</param>
        /// <returns>array/List of arrival times</returns>
        static public List<int> MakeTestCase(int caseID, bool classCanceled, int studentCount, int cancelThreshold)
        {
            // prime array with 3 values that match the criteria
#if BASED_ON_INSTRUCTIONS
            const int ARRIVAL_TIME_LIMIT = 1001;
#else
            const int ARRIVAL_TIME_LIMIT = 21;
#endif
            List<int> requiredDirectionLimits = new List<int>() { -1, 0, 1 };
            List<bool> classCanceledOutput = new List<bool>() { true, false, true, false, true };

            List<int> studentArrivalTime = new List<int>();
            Random rnd = new Random();
            int earlyCount = 0;
            int onTimeCount = 0;
            int lateCount = 0;
            int studentsReady = 0;

            if (classCanceled)
            {
                while (true)
                {
                    // generate K (cancelThreshole) or more value
                    for (int i = 0; i < studentCount; ++i)
                    {
                        int arrivalTime = rnd.Next(ARRIVAL_TIME_LIMIT);
                        int directionIndex = rnd.Next(0, 3);
                        // note lateCount must be >= cancelThreshold
                        // or onTimeCount < cancelThreshold
                        int actualArrivalTime = (arrivalTime * requiredDirectionLimits[directionIndex]);

                        // categorize arrival time
                        earlyCount += (actualArrivalTime < 0) ? 1 : 0;
                        onTimeCount += (actualArrivalTime == 0) ? 1 : 0;
                        lateCount += (actualArrivalTime > 0) ? 1 : 0;
                        // again
                        int studentNotLate = (actualArrivalTime <= 0) ? 1 : 0;
                        // fixup?
                        if ((earlyCount + onTimeCount + studentNotLate) < cancelThreshold && earlyCount > 0 && onTimeCount > 0)
                        {
                            // adjust actual arrival time to ensure that enough students arrive late.
                            // flip direction if necessary
                            actualArrivalTime *= (actualArrivalTime > 0) ? 1 : -1;
                            // force student to arrive late
                            actualArrivalTime += (actualArrivalTime == 0) ? 1 : 0;
                        }
                        studentArrivalTime.Add(actualArrivalTime);

                    }
                    studentsReady = earlyCount + onTimeCount;
                    if (studentsReady < cancelThreshold)
                    {
                        // class will now be canceled
                        break;
                    }
                    else
                    {
                        // need to fix
                    }
                }
            }
            else
            {
                // require early count + on-time count must be >= cancelThreshold
            }
            return studentArrivalTime;
        
        }
        /// <summary>
        /// goal: print 11 lines that can be read by the professor chalange as valid input
        ///  Your test case must result in the following output when fed as input to the Professor challenge's solution:
        /// YES
        /// NO
        /// YES
        /// NO
        /// YES
        /// </summary>
        /// <note> 
        /// since the solution output must be read into the professor challange as valid input
        /// AND the solution output must print 11 lines 
        /// (1) = 5 
        /// (2) = n k
        /// (3) =,(a[0], a[1], ..., a[n-1])
        /// ... 
        /// (10) = n k 
        /// (11) = a[0] a[1] ... a[n-1]) 
        /// SO
        /// this means that T, must be 5 (there must be 5 test-cases)
        /// and all the test cases containat least 3 entries.
        /// AND 
        /// tc[0] = class canceled (YES) arrival time count < k
        /// tc[1] = class not canceled (NO) k students have arrival time >= 0
        /// tc[2] = class canceled
        /// tc[3] = class not canceled
        /// tc[4] = class canceled
        /// </note>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random rnd = new Random();

            /*
             * Print  lines of output that can be read by the Professor challenge as valid input. 
             * Your test case must result in the following output when fed as input to the Professor challenge's solution:
             * YES
             * NO
             * YES
             * NO
             * YES
             * */
            List<bool> classCanceledOutput = new List<bool>() { true, false, true, false, true };
#if BASED_ON_INSTRUCTIONS
            const int MAX_STUDENTS = 200;
#else
            const int MAX_STUDENTS = 20;
#endif
            // t <= 5 
            // but since there is a requirement that 
            // Array A must contain at least one 1, one positive integer and one negative integer
            // the minumum size of a class is 3, 
            int testCases = 5; // see notes above    // rnd.Next(3, 6);
            // 1 <= n <= 200 number of students
            // note: this requirement is not strictly correct because 
            // because there is a requiremnet for 1 arrival < 0, 1 arrival == 0, 1 arrival > 0
            int ID = 0;
            Console.WriteLine(testCases);
            foreach (bool cancelExpected in classCanceledOutput)
            {
                int students = rnd.Next(3, MAX_STUDENTS);
                int cancelationThreshold = rnd.Next(1, students + 1);
                TestCase tc = new TestCase(students, cancelationThreshold, cancelExpected);
                List<int> arrivals = tc.MakeTestCase();
                // print the N, k values (number-of-students) (cancel-threshold)
                Console.WriteLine("{0:d} {1:d}", students, cancelationThreshold);
                // print arrival times for this test-case
                Console.WriteLine(string.Join(" ", arrivals));
            }
        }
    }
}
