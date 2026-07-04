using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving
{
    using System;

    public class SubarrayProductDrill
    {
        public void Run()
        {
            Console.WriteLine("=== DAY 2: THE EXACT FIT ===");
            Console.WriteLine("Problem: Subarray Product Less Than K\n");
            // Expected 8 subarrays: [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6]

            RunTest(100, new int[] { 10, 5, 2, 6 }, 8);             // k is 0, product can never be less than 0.

            RunTest(0, new int[] { 1, 2, 3 }, 0);                   // strictly less than 1, so 1s don't count. 

            RunTest(1, new int[] { 1, 1, 1 }, 0);                   // [2], [6] are valid. [5] is valid. [2,5] is 10 (not strictly less).

            RunTest(10, new int[] { 2, 5, 6 }, 3);
            Console.WriteLine("\nTests complete.");
        }

        /// <summary>
        /// Returns the number of contiguous subarrays where the product is strictly less than k.
        /// </summary>
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            // Edge case: if k <= 1, no product of positive integers can be strictly less than k
            if (k <= 1) return 0;

            int prod = 1;
            int left = 0;
            int right;
            int res = 0;
            for(right = 0; right < nums.Length; right++)
            {
                //Initialize product to be the first element
                if(right == 0 || right == left)
                    prod = nums[right];
                else
                    prod *= nums[right];

                //If a given product is less than k                
                //The range form combination of sub arrays of each elements
                //Else test individual elements of tested product -> fit?

                while(prod >= k)
                {
                    prod /= nums[left];
                    left++;
                }

                if (prod < k)
                    res += right - left + 1;
            }
            return res;
        }

        private void RunTest(int k, int[] arr, int expected)
        {
            try
            {
                int result = NumSubarrayProductLessThanK(arr, k);
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
