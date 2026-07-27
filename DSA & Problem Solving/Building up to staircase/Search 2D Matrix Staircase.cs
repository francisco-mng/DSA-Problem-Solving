using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving.Building_up_to_staircase
{
    internal class Search_2D_Matrix_Staircase
    {
        public static void Main()
        {
            Console.WriteLine("=== DAY 3: STEPPING STONE 4 ===");
            Console.WriteLine("Problem: Search a 2D Matrix II (The Pure Staircase)\n");

            int[][] matrix = new int[][]
            {
            new int[] { 1,   4,  7, 11, 15 },
            new int[] { 2,   5,  8, 12, 19 },
            new int[] { 3,   6,  9, 16, 22 },
            new int[] { 10, 13, 14, 17, 24 },
            new int[] { 18, 21, 23, 26, 30 }
            };

            // Example 1: Standard Hit
            RunTest("Test Case 1 (Target 5)", matrix, 5, true);

            // Example 2: The Miss
            RunTest("Test Case 2 (Target 20)", matrix, 20, false);

            // Example 3: Edge Case (Small Matrix)
            RunTest("Test Case 3 (Single Element - Hit)", new int[][] { new int[] { -1 } }, -1, true);

            // Example 4: Edge Case (Small Matrix - Miss)
            RunTest("Test Case 4 (Single Element - Miss)", new int[][] { new int[] { -1 } }, 2, false);

            Console.WriteLine("\nTesting complete. The compiler does not lie.");
        }


        public static bool Search(int[][] arr, int target)
        {

            if(arr.Length==0 || arr[0].Length ==0) return false;

            //Starting position -> Bottom Left
            int i = arr.Length -1;
            int j = 0;

            int curr_val;

            while (i >= 0 && j < arr[0].Length)
            {
                curr_val = arr[i][j];

                if (curr_val < target)
                {
                    //Move to the right
                    j++;

                }
                else if (curr_val > target)
                {
                    //Value < target => Move up
                    i--;

                }
                else
                {
                    //Value is found ;)
                    return true;
                }
            }


            //If I exit the loop and value wasn't found return falase.
            return false;
        }

        public static void RunTest(string testName, int[][] matrix, int target, bool expected)
        {
            bool result = Search(matrix, target);

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
