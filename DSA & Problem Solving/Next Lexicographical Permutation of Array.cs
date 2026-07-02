using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class Next_Lexicographical_Permutation_of_Array
    {
        //Sort the array to it's next greater lexicographical permutation.

        // Helper function to swap two elements in an array (In-place operation)
        private void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // Helper function to reverse a subarray in place
        private void reverse(int[] arr, int start, int end)
        {
            while (start < end)
            {
                swap(arr, start, end);
                start++;
                end--;
            }
        }

        public int[] nextPermutation(int[] nums)
        {
            int n = nums.Length;
            if (n <= 1)
            {
                return nums;
            }

            // Step 1: Find the Pivot 'l' (the point to change)
            int l = -1;
            for (int i = n - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    l = i;
                    break;
                }
            }

            // If no such element exists, the permutation is the largest possible (e.g., [3, 2, 1]).
            if (l == -1)
            {
                // To get the next smallest lexicographical order, we must reverse the entire array.
                reverse(nums, 0, n - 1);
                return nums;
            }

            // Step 2: Find the Swap Element 'r' (the element to swap with the pivot)
            int r = -1;
            for (int i = n - 1; i > l; i--)
            {
                if (nums[i] > nums[l])
                {
                    r = i;
                    break;
                }
            }

            // Step 3: Perform the Swap
            swap(nums, l, r);

            // Step 4: Reverse the Suffix
            reverse(nums, l + 1, n - 1);

            return nums;
        }


        public void Run()
        {
            Console.WriteLine("=== Next Lexicographical Array Permutation ===");

            RunTest(new int[] { 10, 5, 2, 6 }, new int[] { 10, 5, 6, 2 });             // k is 0, product can never be less than 0.

            RunTest(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 });                   //  

            RunTest(new int[] { 3, 2, 1 }, new int[] { 3, 2, 1});                   // [2], [6] are valid. [5] is valid. [2,5] is 10 (not strictly less).

            RunTest(new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 });

            RunTest(new int[] { 2 }, new int[] {2});
            Console.WriteLine("\nTests complete.");
        }


        private void RunTest(int[] arr, int[] expected)
        {
            try
            {
                int[] result = nextPermutation(arr);
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
