using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving.Building_up_to_staircase
{
    internal class Two_Sum
    {
        public static (int, int) TwoSum(int[] nums, int target)
        {
            int i = -1;
            int j = -1;

            //No point in continuing
            if (nums.Length ==  0) return (i, j);


            //Initial indices
            int left = 0;
            int right = nums.Length-1;
            int guess;


            //Sliding window 2-sum
            while (right >= left){
                guess = nums[right] + nums[left];


                if (guess == target) return (left, right);

                else if(guess > target)
                {
                    //Shift right pointer
                    right --;
                }
                else
                {
                    //Shift left pointer
                    left++;
                }
            }
          
            
            return (i, j);
        }




        public static void Main()
        {
            Console.WriteLine("=== DAY 2: STEPPING STONE 1 ===");
            Console.WriteLine("Problem: Two Sum II - Input Array Is Sorted\n");

            RunTest("Test Case 1 (Standard)", new int[] { 2, 7, 11, 15 }, 9, (0, 1));
            RunTest("Test Case 2 (Small Array)", new int[] { 2, 3, 4 }, 6, (0, 2));
            RunTest("Test Case 3 (Negatives)", new int[] { -1, 0 }, -1, (0,1));

            Console.WriteLine("\nTesting complete. Back to the lab.");
        }

        public static void RunTest(string testName, int[] nums, int target, (int, int) expected)
        {
            
            var result = TwoSum(nums, target);

            if (result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] {testName} | Expected: {expected}, Got: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] {testName} | Expected: {expected}, Got: {result}");
            }
            Console.ResetColor();
        }
    }
}
