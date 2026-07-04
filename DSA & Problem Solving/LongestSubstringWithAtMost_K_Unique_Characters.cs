using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class LongestSubstringWithAtMost_K_Unique_characters
    {
       


        public static void Run()
        {
            Console.WriteLine("=== DAY 3: THE REDEMPTION DRILL ===");
            Console.WriteLine("Problem: Longest Substring with At Most K Distinct Characters\n");

            // "ECE" contains 2 distinct characters ('E' and 'C'). Length = 3.
            RunTest("ECEBA", 2, 3);

            // "AAAB" contains 2 distinct characters ('A' and 'B'). Length = 4.
            RunTest("AAAB", 2, 4);

            // "BCB" contains 2 distinct characters. Length = 3.
            RunTest("AABCBD", 2, 3);

            // k = 1. The longest substring with 1 distinct character is any single letter. Length = 1.
            RunTest("ABCDE", 1, 1);

            Console.WriteLine("\nTests complete.");
        }

        /// <summary>
        /// Returns the length of the longest substring containing at most k distinct characters.
        /// CONSTRAINT: Use an int[26] array. No Dictionaries allowed!
        /// </summary>
        public static int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            // Edge case
            if (s.Length == 0 || k == 0) return 0;

            int[] DAT = new int[26];
            int left = 0;

            int maxLen = 0;
            int distinctCount = 0; // Tracks the number of unique letters currently in the window

            for (int right = 0; right < s.Length; right++)
            {
                // YOUR CODE HERE

                // Step 1: The Explorer adds s[right] to the DAT. 
                //         If this is the FIRST time seeing this letter, increment distinctCount.

                DAT[s[right] - 'A'] += 1;
                if (DAT[s[right] - 'A'] == 1)
                    distinctCount++;

                // Step 2: The Bouncer checks the rules.
                //         While distinctCount > k, kick out s[left].
                //         If kicking them out drops their DAT count to 0, decrement distinctCount.
                //         Don't forget to move the left pointer!

                while(distinctCount > k)
                {
                    DAT[s[left] - 'A']--;

                    if(DAT[s[left] - 'A'] == 0)
                    {
                        distinctCount--;
                    }
                    left++;
                }


                // Step 3: Math Check. Update maxLen if the current window is legally the biggest so far.
                maxLen = right - left + 1 > maxLen? right - left + 1 : maxLen;
            }

            return maxLen;
        }

        private static void RunTest(string s, int k, int expected)
        {
            try
            {
                int result = LengthOfLongestSubstringKDistinct(s, k);
                if (result == expected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[PASS] s=\"{s}\", k={k} | Result: {result}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[FAIL] s=\"{s}\", k={k} | Expected: {expected}, Got: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[ERROR] s=\"{s}\", k={k} | Exception: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}

