using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Security;
using System.Security.Principal;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class Elastic_VIP_Section
    {


        int Calc_shortest_sub_array_length_with_sum_greater_than_target(int[] nums, int target)
        {

            int left = 0;
            int right = 0;

            int minLength = nums.Length;
            bool shrunk_at_least_once = false;

            int current_sum = 0;
            int current_length = 0;



            int min_length = nums.Length;

            //Are we at the end of the list?
            bool isEnd;
            bool isShrinking = false;

            while (left < nums.Length || right < nums.Length) {

                isEnd = left == nums.Length -1 && right == nums.Length -1;

                Console.WriteLine($"\nleft : {left}   right : {right}");


                if (isEnd)
                {
                    current_sum = nums[right];
                    if (current_sum == target)
                    {
                        return 1;
                    }


                    //Trigger the exit of the loop ;)
                    left++;
                    right++;
                    Console.Write($"\ncurrentSum: {current_sum} \ncurrentLength: {current_length}\nmin_length: {minLength}\n\n\n\n");
                }
                else
                {
                    //At any point if target found
                    if(left  == right && nums[left] == target ) {
                        return 1;
                    }




                    //Expansion logic
                    current_sum += nums[right];
                    current_length++;

                    isShrinking = current_sum - nums[left] > target;


                    right = right != nums.Length - 1 && !isShrinking ? right + 1 : right;
                    left = isShrinking ? left + 1 : left;


                    Console.WriteLine($"isShrinking: {isShrinking}");


                    if (isShrinking) {
                        //Shrinking logic
                        shrunk_at_least_once = true;
                        current_sum -= nums[left];

                        //Adjusting for shrinkage
                        current_sum -= nums[right];

                        //Update latest min-length
                        minLength = current_length < min_length && current_sum >= target ? current_length : min_length;
                        current_length--;
                    }
                
                    Console.Write($"\ncurrentSum: {current_sum} \ncurrentLength: {current_length}\nmin_length: {minLength}\n\n\n\n");

                }
            }

            return shrunk_at_least_once ? minLength : 0;
        }



        /* BACKUP Function (revert and work from this if broken)
        //int Calc_shortest_sub_array_length_with_sum_greater_than_target(int[] nums, int target)
        //{

        //    int left = 0;
        //    int right = 0;

        //    int minLength = nums.Length;
        //    bool shrunk_at_least_once = false;

        //    int current_sum = 0;
        //    int current_length = 0;



        //    int min_length = nums.Length;

        //    //Are we at the end of the list?
        //    bool isEnd;
        //    bool isShrinking = false;

        //    while (left < nums.Length || right < nums.Length)
        //    {

        //        isEnd = left == nums.Length - 1 && right == nums.Length - 1;

        //        Console.WriteLine($"\nleft : {left}   right : {right}");


        //        if (isEnd)
        //        {
        //            current_sum = nums[right];
        //            if (current_sum == target)
        //            {
        //                return 1;
        //            }


        //            //Trigger the exit of the loop ;)
        //            left++;
        //            right++;
        //            Console.Write($"\ncurrentSum: {current_sum} \ncurrentLength: {current_length}\nmin_length: {minLength}\n\n\n\n");
        //        }
        //        else
        //        {
        //            //At any point if target found
        //            if (left == right && nums[left] == target)
        //            {
        //                return 1;
        //            }






        //            if (isShrinking)
        //            {
        //                //Shrinking logic
        //                shrunk_at_least_once = true;
        //                current_sum -= nums[left];

        //                //Update latest min-length
        //                minLength = current_length < min_length && current_sum >= target ? current_length : min_length;
        //                current_length--;


        //                left = left != nums.Length - 1 ? left + 1 : left;
        //            }
        //            else
        //            {

        //                //Expansion logic
        //                current_sum += nums[right];
        //                current_length++;

        //                isShrinking = current_sum - nums[left] > target;
        //                right = right != nums.Length - 1 && !isShrinking ? right + 1 : right;
        //                left = isShrinking ? left + 1 : left;
        //                Console.WriteLine($"isShrinking: {isShrinking}");
        //            }

        //            Console.Write($"\ncurrentSum: {current_sum} \ncurrentLength: {current_length}\nmin_length: {minLength}\n\n\n\n");

        //        }
        //    }

        //    return shrunk_at_least_once ? minLength : 0;
        //}
        */



        public void run() {
           // Console.WriteLine(Calc_shortest_sub_array_length_with_sum_greater_than_target([1, 2, 4, 5, 6], 4).ToString());

            Console.WriteLine("=== EXERCISE 2: THE STRETCHY WINDOW ===");
            Console.WriteLine("Goal: Find the minimal length of a contiguous subarray whose sum >= target.\n");

            // Test Case 1: The standard example
            RunTest(7, new int[] { 2, 3, 1, 2, 4, 3 }, 2);


            return;
            // Test Case 2: Single element meets target
            RunTest(4, new int[] { 1, 4, 4 }, 1);

            // Test Case 3: Impossible to reach target (sum of all is 8)
            RunTest(11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 0);

            // Test Case 4: Larger array, optimal sum in the middle
            RunTest(15, new int[] { 5, 1, 3, 5, 10, 7, 4, 9, 2, 8 }, 2);

            Console.WriteLine("\n--- The Gauntlet Tests ---");

            // Test 4: The Exact Match Trap
            // If target is 7, and the array has a 7, it should trigger. Does your logic catch exact matches?
            RunTest(7, new int[] { 7 }, 1);

            // Test 5: The End-Of-Array Trap
            // The answer is clearly 1 (the number 10 at the end). 
            // But does your loop terminate before the Bouncer gets a chance to shrink it?
            RunTest(10, new int[] { 1, 1, 1, 1, 10 }, 1);

            // Test 6: The Phantom Kick
            // The shortest is [3, 4, 5] (length 3). Let's see how your offset math handles a standard sequence.
            RunTest(11, new int[] { 1, 2, 3, 4, 5 }, 3);

            // Test 7: Early Peak, Long Tail
            // The target is 5. It hits it immediately [2, 3] (length 2). 
            // Then a bunch of 1s follow. Does your Bouncer get confused by the long tail?
            RunTest(5, new int[] { 2, 3, 1, 1, 1, 1, 1 }, 2);

            // Test 8: Single Massive Number
            // Target is 20. The array has a 50. It should instantly shrink to length 1.
            RunTest(20, new int[] { 1, 2, 3, 50, 4, 5 }, 1);


        }






        // --- Helper Method for Running Tests ---
        void RunTest(int target, int[] arr, int expected)
    {
        try
        {
            int result = Calc_shortest_sub_array_length_with_sum_greater_than_target(arr, target);
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
