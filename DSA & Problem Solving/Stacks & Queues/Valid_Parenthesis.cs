using System;

public class Valid_Parenthesis
{
    public static void Main()
    {
        Console.WriteLine("=== SPRINT 4 BEGINS: STACKS & QUEUES ===");
        Console.WriteLine("Problem: Valid Parentheses (Primitive Stack)\n");

        RunTest("()", true);
        RunTest("()[]{}", true);
        RunTest("(]", false);
        RunTest("([)]", false);
        RunTest("{[]}", true);
        RunTest("[", false); // Edge case: unclosed bracket

        Console.WriteLine("\nTests complete.");
    }

    /// <summary>
    /// Checks if a string of parentheses is valid.
    /// CONSTRAINT: Do NOT use System.Collections.Generic.Stack<T>. 
    /// Build your own stack using a char[] array and an integer pointer!
    /// </summary>
    public static bool IsValid(string s)
    {
        char[] stack = new char[s.Length];
        int top = -1;

        bool openA, openB, openC;
        bool closeA, closeB, closeC;

        for (int i = 0; i < s.Length; i++)
        {
            char current = s[i];

            openA = current == '{';
            openB = current == '['; 
            openC = current == '(';

            if(openA || openB || openC)
            {
                top ++;
                stack[top] = current;
            }
            else
            {
                closeA = current == '}';
                closeB = current == ']';
                closeC = current == ')';

                //Strictly check closing braces(popping)

                if( top == -1 )
                    return false;

                if (closeA)
                {
                    if (stack[top] == '{')
                    {
                        stack[top] = (char)0;
                        top--;
                    }
                    else return false;
                }else if (closeB)
                {
                    if (stack[top] == '[')
                    {
                        stack[top] = (char)0;
                        top--;
                    }
                    else return false;
                }
                else if (closeC)
                {
                    if (stack[top] == '(')
                    {
                        stack[top] = (char)0;
                        top--;
                    }
                    else return false;
                }
                else
                {
                    //Some other symbol entered
                    return false;
                }
            }
        }

        //So here we're keeping track of the top of the stack, when the stack is empty top will have a value of -1;

        return top == -1;
    }

    private static void RunTest(string input, bool expected)
    {
        try
        {
            bool result = IsValid(input);
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
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ERROR] input=\"{input}\" | Exception: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
        }
    }
}