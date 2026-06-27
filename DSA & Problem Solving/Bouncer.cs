using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class Bouncer
    {

        public int bouncer(int[] nums, int target) {

            int size = nums.Length;
            int sum = nums[0];
            int current_len = 1;
            int min_len = size + 1;

            int left=0, right=0;

            //To perform window shrinking logic.
            bool is_shrinking = false;

            //Alternating logic to flag shrinking vs expansion
            bool done_shrinking = true;


          
            //Logic
            while(true)
            {
                if(sum >= target && right == left && right == 0)
                {
                    return 1;
                }

                if (done_shrinking)
                {
                   if(right< size - 1 && !is_shrinking)
                    {
                        right++;
                        sum += nums[right];
                        current_len += 1;
                        min_len = sum >= target && current_len < min_len ? current_len : min_len;
                    }
                }
                else
                {
                    done_shrinking = true;
                }


                //Shrinking window logic + Edge case of right index in the end
                is_shrinking = sum - nums[left] >= target || right == size -1 && size != 1;


                if(is_shrinking) {
                    sum -= nums[left];
                    left++;
                    current_len -= 1;
                    min_len = sum >= target && current_len < min_len ? current_len : min_len;
                    done_shrinking =false;
                }
                

                //Start and end edge case
                if(left == right && ( right == size - 1 || right == 0) )
                {
                   
                    //Edge case for when last digit == target
                    if(nums[left] >= target) {
                        return 1;
                    }
                    break;
                }

            }

            //Return shortest length if any
            return min_len != size +1 ? min_len : 0;
        }

        public void run()
        {
            // Console.WriteLine(Calc_shortest_sub_array_length_with_sum_greater_than_target([1, 2, 4, 5, 6], 4).ToString());

            Console.WriteLine("=== EXERCISE 2: THE STRETCHY WINDOW ===");
            Console.WriteLine("Goal: Find the minimal length of a contiguous subarray whose sum >= target.\n");

            Console.WriteLine("=== EXERCISE 2: THE STRETCHY WINDOW (THE GAUNTLET) ===");
            // --- Original Tests ---
            RunTest(7, new int[] { 2, 3, 1, 2, 4, 3 }, 2);
            RunTest(4, new int[] { 1, 4, 4 }, 1);
            RunTest(11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 0);

            Console.WriteLine("\n--- The Gauntlet Tests ---");

            RunTest(7, new int[] { 7 }, 1); // Test 4
            RunTest(10, new int[] { 1, 1, 1, 1, 10 }, 1); // Test 5
            RunTest(11, new int[] { 1, 2, 3, 4, 5 }, 3); // Test 6
            RunTest(5, new int[] { 2, 3, 1, 1, 1, 1, 1 }, 2); // Test 7
            RunTest(20, new int[] { 1, 2, 3, 50, 4, 5 }, 1); // Test 8

            // Test 9: The Greater-Than Edge Case
            // You check if nums[left] == target at the end. What if it's GREATER than the target?
            RunTest(7, new int[] { 8 }, 1);

            // Test 10: The Immediate Peak
            // What if the very FIRST number is already the target, but there are more numbers?
            RunTest(10, new int[] { 10, 2, 3 }, 1);

            Console.WriteLine("\nWaiting for implementation...");



        }






        // --- Helper Method for Running Tests ---
        void RunTest(int target, int[] arr, int expected)
        {
            try
            {
                int result = bouncer(arr, target);
                if (result == expected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[PASS] target: {target}, arr: [{string.Join(", ", arr)}] | Result: {result}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[FAIL] target: {target}, arr: [{string.Join(", ", arr)}] | Expected: {expected}, Got: {result}");
                }
            }
            catch (NotImplementedException)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[SKIP] target: {target}, arr: [{string.Join(", ", arr)}] | Method not implemented.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[ERROR] target: {target}, arr: [{string.Join(", ", arr)}] | Exception: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }

    }
}
