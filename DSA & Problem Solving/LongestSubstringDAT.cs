using System;

public class LongestSubstringDAT
{
    public void Run()
    {
        Console.WriteLine("=== DAY 2: SLIDING WINDOW + DAT ===");
        Console.WriteLine("Problem: Longest Substring Without Repeating Characters\n");

        RunTest("abcabcbb", 3); // "abc"
        RunTest("bbbbb", 1);    // "b"
        RunTest("pwwkew", 3);   // "wke"
        RunTest(" ", 1);        // Space is a valid character!
        RunTest("au", 2);

        Console.WriteLine("\nTests complete.");
    }

    /// <summary>
    /// Returns the length of the longest substring without repeating characters.
    /// CONSTRAINT: Use a bool[256] array instead of a HashSet. Time must be O(N).
    /// </summary>
    public int LengthOfLongestSubstring(string s)
    {
        // YOUR CODE HERE
        // 1. Setup your left pointer, right pointer, and max length.
        // 2. Setup your Ledger: bool[] seen = new bool[256];
        // 3. Slide the window:
        //    - If s[right] is ALREADY in the ledger (seen == true):
        //         The Bouncer kicks out s[left], marks it false in the ledger, and left++.
        //    - Add s[right] to the ledger.
        //    - Update max length (right - left + 1).

        return 0;
    }

    private void RunTest(string input, int expected)
    {
        int result = LengthOfLongestSubstring(input);
        if (result == expected)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[PASS] input=\"{input}\" | Result: {result}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FAIL] input=\"{input}\" | Expected: {expected}, Got: {result}");
        }
        Console.ResetColor();
    }
}