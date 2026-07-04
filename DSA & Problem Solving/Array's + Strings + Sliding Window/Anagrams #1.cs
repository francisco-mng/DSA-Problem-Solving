using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class Anagrams__1
    {
        //Great O(n) solution
       
        public void runAnagramTest()
        {
            Console.WriteLine("=== DAY 1: ARRAYS & HASHING (NO COLLECTIONS) ===");
            Console.WriteLine("Problem: Valid Anagram\n");

            RunTestAnagramPartOne("anagram", "nagaram", true);
            RunTestAnagramPartOne("rat", "car", false);
            RunTestAnagramPartOne("a", "ab", false);
            RunTestAnagramPartOne("listen", "silent", true);

            Console.WriteLine("\nTests complete.");
        }

        private static void RunTestAnagramPartOne(string s, string t, bool expected)
        {
            bool result = IsAnagram(s, t);
            if (result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] s=\"{s}\", t=\"{t}\" | Result: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] s=\"{s}\", t=\"{t}\" | Expected: {expected}, Got: {result}");
            }
            Console.ResetColor();
        }


        static bool IsAnagram(string s, string t)
        {

            //Direct Address Table Repsenting alphabets as positions 0-a 1-b and so on ;)
            s = s.ToLower();
            t = t.ToLower();

            int start_alphabet_val = 'a';
            int end_alphabet_val = 'z';

            int range = end_alphabet_val - start_alphabet_val + 1;
            if (s.Length != t.Length) return false;

            //So each character to get the index is char - 97 which is the ascii of 'a's
            int[] DAT_s = new int[range];
            int[] DAT_t = new int[range];

            for (int k = 0; k < s.Length; k++)
            {
                DAT_s[s[k] - start_alphabet_val] += 1;
                DAT_t[t[k] - start_alphabet_val] += 1;
            }

            //Then after populating both DAT's we need to check that each letter qty == 
            for (int p = 0; p < DAT_s.Length; p++)
            {
                if (DAT_s[p] != DAT_t[p])
                    return false;
            }
            return true;
        }




        public void run_findAnagrams() {
            Console.WriteLine("=== DAY 1: SLIDING WINDOW + DAT ===");
            Console.WriteLine("Problem: Find All Anagrams in a String\n");

            // "abc" is the target. Anagrams are "cba" (index 0) and "bac" (index 6).
            RunTest("cbaebabacd", "abc", new List<int> { 0, 6 });

            // "ab" is the target. Anagrams are "ab" (0), "ba" (1), "ab" (2).
            RunTest("abab", "ab", new List<int> { 0, 1, 2 });

            Console.WriteLine("\nTests complete.");
        }


        public static List<int> FindAnagrams(string s, string p) {

            //S -> Long string
            //p -> Short string
            int wind_lengt = p.Length;
            int l = 0;
            int r = 0;

            string curr_str;

            List<int> res = [];

            //O(n) loop still!!!
            //with n = lenght of long string
            for (r = wind_lengt - 1; r < s.Length; r++)
            {
                l = r - wind_lengt + 1;
                curr_str = string.Empty;

                while (l <= r)
                {   //Building current string using window ;)
                    curr_str += s[l];
                    l++;
                }
                if(IsAnagram(curr_str, p))
                {
                    res.Add(r - wind_lengt +1);
                }
            }
            return res;
        }

        private static void RunTest(string s, string p, List<int> expected)
        {
            List<int> result = FindAnagrams(s, p);

            bool passed = result.Count == expected.Count;
            if (passed)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    if (result[i] != expected[i]) passed = false;
                }
            }

            if (passed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] s=\"{s}\", p=\"{p}\" | Found at: [{string.Join(", ", result)}]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] s=\"{s}\", p=\"{p}\" | Expected: [{string.Join(", ", expected)}], Got: [{string.Join(", ", result)}]");
            }
            Console.ResetColor();
        }
    }
}
