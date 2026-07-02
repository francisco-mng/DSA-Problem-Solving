using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class Arrays_Products
    {
        int[] product_elements_except_self (int [] nums)
        {
            int[] answers = new int[nums.Length];

            if (nums.Length <= 1 ) return [];

            int prod = 1;
            //Calculating the final product
            foreach(var val in nums) {
                prod*=val;
            }


            //Getting the product excluding each value of nums
            for(int i = 0; i < answers.Length; i++)
            {
                answers[i] = prod/nums[i];
            }

            return answers;
        }

        public void Run()
        {
            Console.WriteLine("=== Array Products O(n) ===");
            Console.WriteLine("Problem: answers where ans[i] is sum of all numbbers in nums[] except nums[i]");
            // Expected 8 subarrays: [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6]

            RunTest(new int[] { 10, 5, 2, 6 }, new int[] { 60, 120, 300, 100 });             // k is 0, product can never be less than 0.

            RunTest(new int[] { 1, 2, 3 }, new int[] {6, 3, 2});                   // strictly less than 1, so 1s don't count. 

            RunTest(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1});                   // [2], [6] are valid. [5] is valid. [2,5] is 10 (not strictly less).

            RunTest(new int[] { 2 }, new int[] { });
            Console.WriteLine("\nTests complete.");
        }


        private void RunTest(int[] arr, int[] expected)
        {
            try
            {
                int[] result = product_elements_except_self(arr);
                if (string.Join(" ", result) == string.Join(" ", expected))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[PASS], arr=[{string.Join(", ", arr)}] | Result: [{string.Join(", ", result)}]");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[FAIL], arr=[{string.Join(", ", arr)}] | Expected: {string.Join(", ", expected)}, Got: [{string.Join(", ", result)}]");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[ERROR], arr=[{string.Join(", ", arr)}] | Exception: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }

    }
}
