using System;
using System.Collections.Generic;

public class FrequencyDrill
{
    public  void run()
    {
        Console.WriteLine("=== DAY 2: THE FREQUENCY DRILL ===");
        Console.WriteLine("Problem: Return a string of all characters that appear more than once (No Collections).\n");

        // "programming" -> 'r', 'g', 'm' appear more than once. 
        // Read from a 0-255 array, they come out in alphabetical order: "gmr"
        RunTest("programming", "gmr");

        RunTest("abcdefg", ""); // No duplicates

        // "assessment" -> 's' (4), 'e' (2). Alphabetical: "es"
        RunTest("assessment", "es");

        RunTest("aAabB", "a"); // Case sensitive! 'a' appears twice, 'A', 'b', 'B' appear once.

        Console.WriteLine("\nTests complete.");
    }

    /// <summary>
    /// Returns a string of characters that appear more than once in the input.
    /// CONSTRAINT: No Dictionary. Use an int[256] array.
    /// </summary>
    public  string GetDuplicates(string s)
    {
        // YOUR CODE HERE
        // 1. Create an int array of size 256.
        // 2. Loop through the string and increment the count for each character.
        // 3. Loop through your array (0 to 255). If a count is > 1, add that character to a result string.


        string res = "";
        //O(n) -> simple ;)

        int[] DAT = new int[256];

        //Populate DAT with string chars
        foreach(var letter in s)
        {
            DAT[letter] += 1;
        }


        int char_qty = 0;
        //Check DAT for chars occuring more than once ;)
        for(int i = 0; i<DAT.Length; i++)
        {
            char_qty = DAT[i];
            if (char_qty > 1)
            {
                //i is the character ASCII representation
                //Simply convert it to a char and append it to the string

                //Typecasting !!!
                res += (char)(i);
            }
        }

        return res;
    }

    private void RunTest(string input, string expected)
    {
        string result = GetDuplicates(input);
        if (result == expected)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[PASS] input=\"{input}\" | Result: \"{result}\"");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FAIL] input=\"{input}\" | Expected: \"{expected}\", Got: \"{result}\"");
        }
        Console.ResetColor();
    }
}