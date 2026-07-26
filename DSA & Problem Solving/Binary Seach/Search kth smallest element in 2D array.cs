using System;

public class Kth2D
{
    public static void Main()
    {
        Console.WriteLine("=== DAY 1: SPRINT 5 (BINARY SEARCH) ===");
        Console.WriteLine("Problem: Kth Smallest Element in a Sorted Matrix\n");

        int[][] matrix1 = new int[][] {
            new int[] { 1,  5,  9 },
            new int[] { 10, 11, 13 },
            new int[] { 12, 13, 15 }
        };
        RunTest("Test Case 1 (Standard Path, k=8)", matrix1, 8, 13);

        int[][] matrix2 = new int[][] {
            new int[] { -5 }
        };
        RunTest("Test Case 2 (Minimalist, k=1)", matrix2, 1, -5);

        int[][] matrix3 = new int[][] {
            new int[] { 1, 2 },
            new int[] { 1, 3 }
        };
        RunTest("Test Case 3 (Duplicate Trap, k=2)", matrix3, 2, 1);

        int[][] matrix4 = new int[][] {
            new int[] { 1,  4,  7, 11 },
            new int[] { 2,  5,  8, 12 },
            new int[] { 3,  6,  9, 16 },
            new int[] { 10, 13, 14, 17 }
        };
        RunTest("Test Case 4 (Hostile Gauntlet, k=9)", matrix4, 9, 9);

        Console.WriteLine("\nTests complete.");
    }

    public static int KthSmallest(int[][] matrix, int k)
    {
        int n = matrix.Length;
        int left = matrix[0][0];          // Absolute minimum
        int right = matrix[n - 1][n - 1]; // Absolute maximum

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            // Count how many numbers are <= our mid guess
            int count = CountLessOrEqual(matrix, mid);

            if (count < k)
            {
                // Guess was too small, search the upper half
                left = mid + 1;
            }
            else
            {
                // Guess might be right, or we can go tighter
                right = mid;
            }
        }

        return left;
    }

    private static int CountLessOrEqual(int[][] matrix, int target)
    {
        int count = 0;
        int n = matrix.Length;

        // STAIRCASE START: Bottom-Left Corner
        int row = n - 1;
        int col = 0;

        while (row >= 0 && col < n)
        {
            if (matrix[row][col] <= target)
            {
                // Current value is valid.
                // This means everything above it in this column is also valid.
                count += (row + 1);

                // Move RIGHT to check the next column
                col++;
            }
            else
            {
                // Current value is strictly greater than target.
                // Move UP to find smaller values.
                row--;
            }
        }

        return count;
    }

    private static void RunTest(string testName, int[][] matrix, int k, int expected)
    {
        try
        {
            int result = KthSmallest(matrix, k);
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