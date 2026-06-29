using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class UniqueCharsInString
    {
        bool IsUnique(string s)
        {

            bool[] DAT = new bool[256];

            //Load all characters assuming ASCI-range of extended Asci values ;)
            //Turns out we can do it while we're loading the characters in ;)

            //Also no need for that 'a' adjustmet since our context is not limited to letters of the alphabet
            foreach (var a in s)
            {
                //Character already exists in DAT -> NOT UNIQUE
                if (DAT[a]) return false;
                DAT[a] = true;
            }

            return true;
        }

        public void Run()
        {
            Console.WriteLine("=== DAY 2: THE DIRECT ADDRESS DRILL ===");
            Console.WriteLine("Problem: Determine if all characters in a string are unique (No Collections).\n");

            RunTest("abc", true);
            RunTest("aba", false);
            RunTest("racecar", false);
            RunTest("coding", true);

            Console.WriteLine("\nTests complete.");
        }

        public void run()
        {
            //Creating an alias for the Run() function ;)
            Run();
        }
        public void RunTest(string input, bool expected)
        {
            bool result = IsUnique(input);
            if (result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] input=\"{input}\" | Result: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] input=\"{input}\" | Expected: {expected}, Got: {result}");
            }
            Console.ResetColor();
        }
    }
}
