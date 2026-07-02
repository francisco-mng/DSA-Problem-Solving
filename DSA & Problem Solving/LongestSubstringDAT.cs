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
        //Assuming we're working with ASCI-Extended(256)
        int[] DAT = new int[256];

        int left = 0;
        int right;

        int max = 0;
        int curr_len = 0;

        //Sliding window
        for(right = 0; right < s.Length; right++)
        {

            DAT[s[right]] += 1;

            if (DAT[s[right]] <= 1)
            {
                curr_len = right - left + 1;
                max = curr_len > max ? curr_len : max;
            }
            else
            {
                //Current right index char greater than 1 -> slide
                //As well as while left < right
                while (left < right && DAT[s[right]] > 1)
                {
                    DAT[s[left]] -= 1;
                    left++;
                }
            }

        }

        return max;
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