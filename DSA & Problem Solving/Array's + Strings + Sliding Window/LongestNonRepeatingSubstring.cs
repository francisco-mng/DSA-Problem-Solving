using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class LongestNonRepeatingSubstring
    {
        //So the sliding window pattern has to do with for (right) loop and within it a while (left < some limit) loop
        //This is the pattern ;)
        int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            int curr_len = 0;
            int left = 0;

            HashSet<char> list = [];
            char curr;

            for (int right = 0; right < s.Length; right++)
            {
                curr = s[right];


                //Unique element at [right]
                //Right slide
                if (!list.Contains(curr))
                {
                    curr_len++;
                    max = curr_len > max ?curr_len : max;
                    list.Add(curr);
                    continue;
                }

                //While substring contains the duplicate value;
                //This will allow stop at correct position;
                while (list.Contains(s[right]))
                {
                    //Bouncer shrink size
                    list.Remove(s[left]);
                    left++;
                }
                curr_len = right - left ;
                right --;
            }
            return max;
        }

        public void run()
        {
            Console.WriteLine("=== EXERCISE 4: THE STRING LEDGER ===");
            Console.WriteLine("Goal: Longest Substring Without Repeating Characters\n");

            // --- Tests ---
            RunTest("abcabcbb", 3); // Case 1: The Standard Shift ("abc")
            RunTest("bbbbb", 1);    // Case 2: Pure Duplicates ("b")
            RunTest("pwwkew", 3);   // Case 3: The Mid-String Shift ("wke")
            RunTest("", 0);         // Case 4: The Void
            RunTest("abcdefg", 7);  // Case 5: All Unique
            RunTest("aab", 2);      // Case 6: Immediate Collision ("ab")
            RunTest("dvdf", 3);     // Case 7: The Trap ("vdf")

            Console.WriteLine("\nTests complete.");
        }

        public void RunTest(string s, int expected)
        {
            try
            {
                int result = LengthOfLongestSubstring(s);
                if (result == expected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[PASS] s=\"{s}\" | Result: {result}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[FAIL] s=\"{s}\" | Expected: {expected}, Got: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[ERROR] s=\"{s}\" | Exception: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
