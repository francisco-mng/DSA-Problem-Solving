using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving
{
    class MaxSumFixedWindowSize
    {

         int MaxSumFixedWindow(int[] arr, int window_size)
         {    
            int maxSum = 0;
            int currentSum = 0;

            int val = 0;
            int removed = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                val = arr[i];

                if (i < window_size)
                {
                    //Add to the current window
                    currentSum += val;
                }
                else
                {
                    //Perform sliding window logic
                    removed = arr[i - window_size];

                    currentSum -= removed;
                    currentSum += val;
                }
                maxSum = currentSum > maxSum ? currentSum : maxSum;
            }

            return maxSum;
        }

        public void run() {
            Console.WriteLine("=== EXERCISE 1: THE FIXED SCANNER ===");
            Console.WriteLine("Goal: Find the maximum sum of any contiguous subarray of size k.\n");

            // Test Case 1: The standard example
            RunTest(new int[] { 2, 1, 5, 1, 3, 2 }, 3, 9);

            // Test Case 2: Window size is exactly the array length
            RunTest(new int[] { 2, 3, 4, 1, 5 }, 5, 15);

            // Test Case 3: Window size is 1 (Should just find the max element)
            RunTest(new int[] { 1, 9, 2, 8, 3, 7 }, 1, 9);

            // Test Case 4: Highest sum is at the very end of the array
            RunTest(new int[] { 1, 1, 1, 1, 10, 20 }, 2, 30);

            // Test Case 5: All identical numbers
            RunTest(new int[] { 4, 4, 4, 4, 4 }, 3, 12);

            Console.WriteLine("\nWaiting for implementation...");
        }
        



        // --- Helper Method for Running Tests ---
        void RunTest(int[] arr, int k, int expected)
        {
            try
            {
                int result = MaxSumFixedWindow(arr, k);
                if (result == expected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[PASS] arr: [{string.Join(", ", arr)}], k: {k} | Result: {result}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[FAIL] arr: [{string.Join(", ", arr)}], k: {k} | Expected: {expected}, Got: {result}");
                }
            }
            catch (NotImplementedException)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[SKIP] arr: [{string.Join(", ", arr)}], k: {k} | Method not implemented.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[ERROR] arr: [{string.Join(", ", arr)}], k: {k} | Exception: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
