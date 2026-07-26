
public class BinarySearchTester
{
    public static void Main()
    {
        Console.WriteLine("=== DAY 2: STEPPING STONE 2 ===");
        Console.WriteLine("Problem: Standard Binary Search\n");

        // Example 1: Standard Hit
        //RunTest("Test Case 1 (Standard Hit)", new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4);

        //// Example 2: The Miss
        //RunTest("Test Case 2 (The Miss)", new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1);

        // Example 3: The Convergence Test
        RunTest("Test Case 3 (Single Element - Hit)", new int[] { 5 }, 5, 0);

        //// Example 4: Single Element Convergence Miss (Strict bounds check)
        //RunTest("Test Case 4 (Single Element - Miss)", new int[] { 5 }, 2, -1);

        Console.WriteLine("\nTesting complete. The compiler does not lie.");
    }

    public static void RunTest(string testName, int[] nums, int target, int expected)
    {
        Solution sol = new Solution();
        int result = sol.Search(nums, target);

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

public class Solution
{
    public int Search(int[] array, int target)
    {
        if (array.Length == 0) return -1;


        int left = 0;
        int right = array.Length - 1;
        int mid;

        while (left <= right)
        {
            mid = left + (right - left) / 2;

            if (array[mid] == target) return mid;
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }

        }
        //If no value was found.
        return -1;
    }
}