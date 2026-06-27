using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class Longest_Ones
    {
        //Solved ;)
        int LongestOnes(int[] arr, int k ) {
            int rem = k;                            //Track remaining 0->1 flips
            int curr_len;

            int left = 0;                           //Work with left and right pointers!!!
            int temp_left = 0;                
            int right;
            int max = 0;

            for (right = 0; right < arr.Length; right++) {

                curr_len = right != left && right > left? right - left + 1: arr[right] == 1 || rem > 0 ? 1 : 0;

                //Expand and flip
                if (arr[right] == 0 && rem > 0)
                {
                    rem--;
                    max = curr_len > max ? curr_len : max;
                }
                else if (arr[right] == 0)
                {
                    //Search new window  --> limit reached
                    //Restore iff next num == 1
                    if (right + 1 < arr.Length)
                        rem = arr[right + 1] == 1 ? k: rem ;

                    left      = rem > 0     ?   temp_left : right + 1 <= arr.Length ? right + 1 : right;
                    temp_left = rem > 0     ?   temp_left : left;

                    right = rem > 0 ? right--: right ;
                }
                else if (arr[right] == 1 && rem == 0)
                {
                    //Snap left to the current left-most 1
                    temp_left = right > 0 && arr[right-1]==1 ? temp_left : right;
                    max = curr_len > max ? curr_len : max;
                }
                else {
                    //Current value == 1 --> simply expand --> Search new window --> Re-position of left
                    max = curr_len > max ? curr_len : max;
                }
            }
            return max;
        }


        public void run() {
            Console.WriteLine("=== EXERCISE 3: THE VIP PASS ===");
            Console.WriteLine("Goal: Max consecutive 1s with at most 'k' flips.\n");

            // --- The Gauntlet Tests from your Dry-Run ---
            RunTest(1, new int[] { 1, 0, 1, 0, 1 }, 3);                             // Case 1: The Standard Bridge
            RunTest(0, new int[] { 1, 1, 0, 1, 1 }, 2);                             // Case 2: The Strict Regime
            RunTest(2, new int[] { 0, 0, 0, 0 }, 2);                                // Case 3: Pure Void
            RunTest(2, new int[] { 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1 }, 8);           // Case 4: The Trap
            RunTest(10, new int[] { 0, 1, 1, 0, 1, 0 }, 6);                         // Case 5: Infinite Passes
            RunTest(0, new int[] { 0, 0, 1, 0, 0 }, 1);                             // Case 6: Choked Regime
            RunTest(2, new int[] { 1, 0, 1, 0, 1, 0, 1 }, 5);                       // Case 7: Alternating Currents
        }



        // --- Helper Method for Running Tests ---
        void RunTest(int k, int[] arr, int expected)
        {
            try
            {
                int result = LongestOnes(arr, k);
                if (result == expected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[PASS] k={k}, arr=[{string.Join(", ", arr)}] | Result: {result}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[FAIL] k={k}, arr=[{string.Join(", ", arr)}] | Expected: {expected}, Got: {result}");
                }
            }
            catch (NotImplementedException)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[SKIP] k={k}, arr=[{string.Join(", ", arr)}] | Method not implemented.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[ERROR] k={k}, arr=[{string.Join(", ", arr)}] | Exception: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }


    }
}
