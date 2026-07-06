using System;
using System.Collections.Generic;

public class Stack_Using_Queue
{
    public static void Main()
    {
        Console.WriteLine("=== DAY 4: SPRINT 4 CONTINUES ===");
        Console.WriteLine("Problem: Implement Stack using Queues\n");

        MyStack myStack = new MyStack();

        myStack.Push(1);
        myStack.Push(2);

        RunTest("Top after pushing 1, 2", myStack.Top(), 2);
        RunTest("Pop top element", myStack.Pop(), 2);
        RunTest("Empty check after 1 pop", myStack.Empty(), false);

        myStack.Push(3);

        RunTest("Top element after pushing 3", myStack.Top(), 3);
        RunTest("Pop second element", myStack.Pop(), 3);
        RunTest("Pop third element", myStack.Pop(), 1);
        RunTest("Empty check after all pops", myStack.Empty(), true);

        Console.WriteLine("\nTests complete.");
    }

    private static void RunTest(string testName, object result, object expected)
    {
        if (result.Equals(expected))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[PASS] {testName} | Result: {result}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FAIL] {testName} | Expected: {expected}, Got: {result}");
        }
        Console.ResetColor();
    }
}

/// <summary>
/// Design a LIFO stack using ONLY standard FIFO queue operations.
/// </summary>
public class MyStack
{
    private Queue<int> q;

    public MyStack()
    {
        q = new Queue<int>();
    }


    //Push ensures that the last added element is at the back of the queue, ready to be popped -> LIFO -> Stack
    public void Push(int x)
    {
        // YOUR CODE HERE
        // Hint: Enqueue the new item, then "rotate" the older items behind it!
        
        int size = q.Count;
        q.Enqueue(x);
        while(size > 0) { 
            //Deque and enqueue existing items to rotate them behind the curently enqueued
            //Such that the item just added is at the 'exit'/'dequeue' end
            q.Enqueue(q.Dequeue());
            size--;
        }
      
    }


    public int Pop()
    {
        return q.Dequeue();
    }

    public int Top()
    {
        
        return q.Peek();
    }

    public bool Empty()
    {
        return q.Count == 0;
    }
}