using System;

public class Min_Stack_tester
{
    public static void Main()
    {
        Console.WriteLine("=== DAY 4: SPRINT 4 CONTINUES ===");
        Console.WriteLine("Problem: Min Stack (No Collections)\n");

        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);

        RunTest("GetMin() after pushing -2, 0, -3", minStack.GetMin(), -3);

        minStack.Pop();
        RunTest("Top() after popping", minStack.Top(), 0);

        //minStack.Push(-122);

        RunTest("GetMin() after popping", minStack.GetMin(), -2);

        Console.WriteLine("\nTests complete.");
    }

    private static void RunTest(string testName, int result, int expected)
    {
        if (result == expected)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[PASS] {testName} | Result: {result}");
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[FAIL] {testName} | Expected: {expected}, Got: {result}");
        }
        Console.ResetColor();
    }
}

/// <summary>
/// Design a stack that supports push, pop, top, and retrieving the minimum element in O(1) time.
/// CONSTRAINT: Do NOT use System.Collections.Generic.Stack<T> or List<T>. 
/// Use primitive arrays (int[]) and pointer variables!
/// </summary>
public class MinStack
{
    // YOUR CLASS VARIABLES HERE
    int min;
    int[] memory;
    int[] min_mem;
    int top = -1;
    int top_min = -1;

    public MinStack()
    {
        // YOUR CODE HERE
        memory = new int[10000];
        min_mem = new int[memory.Length];
        // Hint for sizing: You can assume a max capacity like 10000 for your primitive arrays
    }

    public void Push(int val)
    {
        // YOUR CODE HERE
        //Update min and track min_memory
        if(val <= min || top == -1)
        {
            top_min++;
            min = val;
            min_mem[top_min] = min;
        }
        top++;
        memory[top] = val;
    }

    public void Pop()
    {
        //Edge case stack is already empty;
        if (top == -1) return;

        // YOUR CODE HERE
        if(memory[top] <= min)
        {
            //The minimum is it's own stack-like memory
            min_mem[top_min] = 0;
            top_min--;
            min = top_min != -1 ? min_mem[top_min]: min;
        }

        memory[top] = 0;
        top--;
    }

    public int Top()
    {
        // YOUR CODE HERE
        return top != -1 ? memory[top]: 0; 
    }

    public int GetMin()
    {
        // YOUR CODE HERE
        return min; // Replace this
    }
}