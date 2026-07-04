using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving
{
    internal class MovingZerosToTheEnd
    {

        //Given int[] move all zeros to end while maintaining relative order
        int[] move_zeros_to_end(int[] nums) {


            int left = 0;
            int right = 0;
            int temp = 0;

            for(right = 0; right < nums.Length; right++)
            {

                if (nums[right] == 0)
                {
                    left = right;

                    while (left < nums.Length && nums[left] == 0)
                    {
                        left++;
                    }

                    //Reached a number if exists, now swap.
                    if (left != nums.Length)
                    {
                        temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }
                    else
                    {
                        //When there's no other number found, simply exit and return. 
                        //Swapping is complete;)
                        return nums;
                    }
                }
            }
            return nums;
        }

        public void Run()
        {
            Console.WriteLine("=== Moving Zeros to the end of the list ===");

            RunTest(new int[] { 10, 0, 0, 6, 1, 0, 4, 0 }, new int[] { 10, 6, 1, 4, 0, 0, 0 ,0});            

            RunTest(new int[] { 0, 0, 3 }, new int[] { 3,0,0 });                  
            RunTest(new int[] { 0, 1, 1 }, new int[] { 1, 1, 0 });         
            RunTest(new int[] { 2 }, new int[] { 2 });
            Console.WriteLine("\nTests complete.");
        }


        private void RunTest(int[] arr, int[] expected)
        {
            try
            {
                int[] result = move_zeros_to_end(arr);
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
