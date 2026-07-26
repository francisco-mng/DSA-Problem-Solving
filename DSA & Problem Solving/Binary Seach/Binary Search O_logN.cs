using System;

public class BinarySearch_Tester
{
    public static void Main()
    {
        Console.WriteLine("=== SPRINT 5: BINARY SEARCH ===");
        Console.WriteLine("Problem: Classic Binary Search\n");

        RunTest(new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4);
        RunTest(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1);
        RunTest(new int[] { 5 }, 5, 0);
        RunTest(new int[] { 5 }, -5, -1);
        RunTest(new int[] { 2, 5 }, 5, 1);
        RunTest(new int[] { 2, 5 }, 2, 0);

        // THE RESTORED FAILING TESTS (Length 15 Array):
        int[] largeArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        RunTest(largeArray, 15, 14);
        RunTest(largeArray, 1, 0);

        Console.WriteLine("\nTests complete.");
    }

    /// <summary>
    /// Searches for a target value within a sorted array in O(log N) time.
    /// </summary>
    public static int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        // Keep searching as long as our boundaries haven't crossed
        while (left <= right)
        {
            // Calculate the middle index. 
            // We use this formula instead of (left + right) / 2 to prevent integer overflow
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return mid; // Found it!
            }
            else if (nums[mid] < target)
            {
                // The current number is too small. 
                // The target MUST be to the right, so we pull the left boundary in.
                left = mid + 1;
            }
            else
            {
                // The current number is too big. 
                // The target MUST be to the left, so we pull the right boundary in.
                right = mid - 1;
            }
        }

        // If the loop finishes and left crosses right, the target doesn't exist
        return -1;
    }

    private static void RunTest(int[] nums, int target, int expected)
    {
        try
        {
            int result = Search(nums, target);
            if (result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] target={target} in [{string.Join(", ", nums)}] | Result: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] target={target} in [{string.Join(", ", nums)}] | Expected: {expected}, Got: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ERROR] target={target} in [{string.Join(", ", nums)}] | Exception: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
        }
    }
}