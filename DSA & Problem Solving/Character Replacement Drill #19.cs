using System;
using System.Security.AccessControl;

public class Character_Replacement_Drill_19
{
    public  void Run()
    {
        Console.WriteLine("=== DAY 3: SPRINT 3 CONTINUES ===");
        Console.WriteLine("Problem: Longest Repeating Character Replacement\n");

        // We can change 2 letters. Change 'A's to 'B's or vice versa to get "BBBB" or "AAAA" (Length 4)
        RunTest("ABAB", 2, 4);

        // We can change 1 letter. Change the middle 'B' to 'A' to get "AAAA" (Length 4)
        RunTest("AABABBA", 1, 4);

        // 0 changes allowed. Longest repeating is "CCC" (Length 3)
        RunTest("ABCCC", 0, 3);

        Console.WriteLine("\nTests complete.");
    }

    /// <summary>
    /// Returns the length of the longest substring containing the same letter 
    /// you can get after at most k replacements.
    /// CONSTRAINT: Use an int[26] array. No Dictionaries allowed!
    /// </summary>
    public static int CharacterReplacement(string s, int k)
    {
        int[] DAT = new int[26];
        int left = 0;
        int maxLen = 0;
        int maxFreqInWindow = 0; // Tracks the count of the most frequent letter currently in the window

        for (int right = 0; right < s.Length; right++)
        {
            // 1. Add current character to the DAT
            int charIndex = s[right] - 'A';
            DAT[charIndex]++;

            // 2. Update the MVP (max frequency in the current window)
            if (DAT[charIndex] > maxFreqInWindow)
            {
                maxFreqInWindow = DAT[charIndex];
            }

            // 3. The Math Check: Are there too many impostors to replace?
            // Impostors = (Total Window Size) - (MVP Count)
            while ((right - left + 1) - maxFreqInWindow > k)
            {
                // The window is illegal. Kick the leftmost character out of the DAT and shrink the window.
                DAT[s[left] - 'A']--;
                left++;
            }

            // 4. We survived the while loop, so the window is legal. Check if it's our new maximum.
            int currentWindowSize = right - left + 1;
            if (currentWindowSize > maxLen)
            {
                maxLen = currentWindowSize;
            }
        }

        return maxLen;
    }

    private  void RunTest(string s, int k, int expected)
    {
        try
        {
            int result = CharacterReplacement(s, k);
            if (result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] s=\"{s}\", k={k} | Result: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] s=\"{s}\", k={k} | Expected: {expected}, Got: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ERROR] s=\"{s}\", k={k} | Exception: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
        }
    }
}