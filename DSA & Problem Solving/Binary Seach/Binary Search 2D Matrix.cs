using System;

public class Binary2D_Matrix
{
    public static void Main()
    {
        Console.WriteLine("=== SPRINT 5: BINARY SEARCH ===");
        Console.WriteLine("Problem: Search a 2D Matrix\n");

        int[][] matrix1 = new int[][] {
            new int[] { 1, 3, 5, 7 },
            new int[] { 10, 11, 16, 20 },
            new int[] { 23, 30, 34, 60 }
        };

        RunTest("Target 3 (Exists)", matrix1, 3, true);
        RunTest("Target 13 (Does not exist)", matrix1, 13, false);

        int[][] matrix2 = new int[][] {
            new int[] { 1 }
        };

        RunTest("Target 1 (Single element matrix)", matrix2, 1, true);
        RunTest("Target 2 (Single element matrix)", matrix2, 2, false);

        Console.WriteLine("\nTests complete.");
    }

    /// <summary>
    /// Searches for a target value within a 2D sorted matrix in O(log(M*N)) time.
    /// </summary>
    public static bool SearchMatrix(int[][] arr, int target)
    {

        int top = 0;
        int bottom = arr.Length - 1;
        int mid_v = 0;

        //Defaults -> not found ;)
        int row = -1;
        int col = -1;


        int left  = 0;
        int right = arr[0].Length -1;           //Depends on the actual array;)
        int mid_h = left + (right - left)/2;
        //Search for likely row
        //matrix[mid_v][0] <= current -> Move up! cut half of the bottom of matrix

        while(top <= bottom)
        {
            //In case bottom < top -> Use the last calculated mid_v as the row selected...
            //Decide on movement
            if (target < arr[mid_v][0])
            {
                //Move up -> Cut bottom half of 2D array
                bottom = mid_v - 1 >= 0 ? mid_v - 1: mid_v ;
            }else
            {
                //Move down ->Cut top half of 2D array
                //OR possibly found appropriate row
                if (mid_v + 1 < arr.Length && target >= arr[mid_v + 1][0])
                {
                    top = mid_v + 1;
                }
                else
                {
                    //Take current mid_v as the value
                    break;
                }
            }

            mid_v = top + (bottom - top) / 2;
            if (top == bottom) break;
        }

        //At this point the mid_v points to the current test row
        row = mid_v;


        //Row found, now look for columns
        while (left <= right)
        {

            //Check for equality at any point;
            if (target == arr[row][mid_h])
            {
                //Found exact value ;)
                col = mid_h;
                break;
            }

            //Decide on movement
            if (target < arr[row][mid_h])
            {
                //Move left -> Cut bottom right of 2D array
                right  = mid_h - 1;
            }
            else
            {
               //Move right -> Cut left of 2D array
                left = mid_h + 1;               
            }

            //Recalculate the mid pointer
            mid_h = left + (right - left) / 2;
        }

        //If either column or row not found return false -> Value doesn't exist in 2D Array;
        return row != -1 && col != -1;
    }

    public static bool SearchTheMatrix_Optimal(int[][] arr, int target)
    {
        // ==========================================
        // PART A: Vertical Binary Search (Find Row)
        // ==========================================
        int top = 0;
        int bottom = arr.Length - 1;

        // Defaults -> not found ;)
        int row = -1;
        int col = -1;

        while (top <= bottom)
        {
            // FIX: Calculate mid at the TOP of the loop so it's always fresh
            int mid_v = top + (bottom - top) / 2;

            if (target < arr[mid_v][0])
            {
                // Move up -> Cut bottom half of 2D array
                // FIX: Let it go negative! This is how the loop naturally breaks.
                bottom = mid_v - 1;
            }
            else
            {
                // Move down -> Cut top half of 2D array OR possibly found appropriate row
                if (mid_v + 1 < arr.Length && target >= arr[mid_v + 1][0])
                {
                    top = mid_v + 1;
                }
                else
                {
                    // Take current mid_v as the value
                    row = mid_v;
                    break;
                }
            }
        }

        // If we didn't find a valid row, stop searching
        if (row == -1) return false;

        // ==========================================
        // PART B: Horizontal Binary Search (Find Col)
        // ==========================================
        int left = 0;
        int right = arr[row].Length - 1;

        while (left <= right)
        {
            // FIX: Calculate mid at the TOP of the loop
            int mid_h = left + (right - left) / 2;

            if (target == arr[row][mid_h])
            {
                // Found exact value ;)
                col = mid_h;
                break;
            }

            if (target < arr[row][mid_h])
            {
                // Move left -> Cut right half
                right = mid_h - 1;
            }
            else
            {
                // Move right -> Cut left half
                left = mid_h + 1;
            }
        }

        // If both column and row found, return true
        return row != -1 && col != -1;
    }

    private static void RunTest(string testName, int[][] matrix, int target, bool expected)
    {
        try
        {
            bool result = SearchTheMatrix_Optimal(matrix, target);
            if (result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] {testName} | Result: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] {testName} | Expected: {expected}, Got: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ERROR] {testName} | Exception: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
        }
    }
}