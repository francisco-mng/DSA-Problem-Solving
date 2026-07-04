using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class String_Permutations
    {
        public void run()
        {
            Console.WriteLine("=== DAY 1 (REPEAT): SLIDING WINDOW + DAT ===");
            Console.WriteLine("Problem: Permutation in String\n");

            RunTest("ab", "eidbaooo", true);
            RunTest("ab", "eidboaoo", false);
            RunTest("adc", "dcda", true);
            RunTest("hello", "ooolleoooleh", false);
            RunTest("a", "ab", true);
            Console.WriteLine("\nTests complete.");
        }

        /// <summary>
        /// Returns true if s2 contains a permutation of s1.
        /// CONSTRAINT: Use a DAT (int[26]). Do NOT use a Dictionary. Time must be O(N).
        /// </summary>
        /// 
        /*
        public bool CheckInclusion(string s1, string s2)
        {
            // Edge case: if the target permutation is longer than the string itself
            if (s1.Length > s2.Length) return false;

            int[] DAT = new int[26];

            //Adjust letters to read from 0 to 25 -> a-z
            int adjustment = 'a';


            //Initialize the DAT to include substring
            for(int k = 0; k < s1.Length; k++)
            {
                DAT[s1[k] - adjustment] -= 1;
            }

            int right = 0;
            int left = 0;

            int sub_len = s1.Length;
            
            for (right = 0; right < s2.Length; right ++) {

                // Decrement at[right] and increment at[left]->slide
                DAT[s2[right] - adjustment] += 1;
                DAT[s2[left] - adjustment]   = right >= sub_len ? DAT[s2[left] - adjustment] -1 : DAT[s2[left] - adjustment];


                //Window maintains len(s1) + guarantees all sub_letters included
                left = right >= sub_len ? right - sub_len + 1 : left;
                
               
                bool contains_permutation = true;
                foreach (int a in DAT)
                {
                    if(a != 0)
                    {
                        contains_permutation = false;
                        break;
                    }
                }
                if(contains_permutation) return true;
               
            }

            return false;
        }



        */



        //Retyping from memory
        private bool CheckInclusion(string s1, string s2) {

            int left = 0;
            int right = 0;
            int[] DAT = new int[26];
            int adjustment = 'a';

            int win_len = s1.Length;

            bool valid = true;
            //Edge case, substring cannot have len > test string.
            if (s1.Length > s2.Length) return false;
            
            //Build DAT for initial string
            for(int i = 0; i<s1.Length; i++)
            {
                DAT[s1[i] - adjustment] -= 1;
            }

            for (right = 0; right < s2.Length; right++)
            {
                //Now populate DAT with window length strings ;)
                //Adding one and then shifting window once fully formed.
                valid = true;
                DAT[s2[right] - adjustment] += 1;
                
                if(right >= win_len)
                {
                    DAT[s2[left] - adjustment] -= 1;
                    left ++;
                }
                      
                foreach(int val in DAT)
                {
                    if(val != 0)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid) return true;
            }

            return false;
        }


        private void RunTest(string s1, string s2, bool expected)
        {
            bool result = CheckInclusion(s1, s2);

            if (result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] s1=\"{s1}\", s2=\"{s2}\" | Result: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] s1=\"{s1}\", s2=\"{s2}\" | Expected: {expected}, Got: {result}");
            }
            Console.ResetColor();
        }
    }
}
