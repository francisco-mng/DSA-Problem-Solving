using System;
using System.Collections.Generic;

public class Queue_Stacks_Tester
{
    public static void Main()
    {
        Console.WriteLine("=== DAY 4: SPRINT 4 CONTINUES ===");
        Console.WriteLine("Problem: Implement Queue using Stacks\n");

        MyQueue myQueue = new MyQueue();

        myQueue.Push(1); // queue is: [1]
        myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)

        RunTest("Peek after pushing 1, 2", myQueue.Peek(), 1);
        RunTest("Pop first element", myQueue.Pop(), 1);
        RunTest("Empty check after 1 pop", myQueue.Empty(), false);

        myQueue.Push(3); // queue is: [2, 3]

        RunTest("Peek element after pushing 3", myQueue.Peek(), 2);
        RunTest("Pop second element", myQueue.Pop(), 2);
        RunTest("Pop third element", myQueue.Pop(), 3);
        RunTest("Empty check after all pops", myQueue.Empty(), true);

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
/// Design a FIFO queue using ONLY two LIFO stacks.
/// </summary>
public class MyQueue
{
    private Stack<int> s1;  //Input stack
    private Stack<int> s2;  //Output stack

    public MyQueue()
    {
        s1 = new Stack<int>();
        s2 = new Stack<int>();
    }

    public void Push(int x)
    {
        //Check if s2 bucket has items? move all to s1 : do nothing


        //NO NEED
            // -> Since all the elements in the s2 bucket will be in the correct order anyways ;)


        //if(s2.Count != 0)
        //{
        //    //Move all elements to s1, then proceed to push
        //    //Regardless of the elements in s1
        //    while(s2.Count > 0) {
        //        s1.Push(s2.Pop());
        //        //Not iterating and mutating per se, just looping here with a conditional...
        //        //My intuition tells me that this is not the same problem...
        //    }
        //}

        s1.Push(x);
    }


    public int Pop()
    {
        if(s1.Count == 0)
        {
            if (s2.Count == 0)
                return 0;
        }
        else
        {
            while (s1.Count > 0)
            {
                //Move all s2 to s1, then proceed to pop
                s2.Push(s1.Pop());
            }
        }

        return s2.Pop();
    }
    

    public int Peek()
    {
        //Also depends on the state of the stacks!!
        if (s1.Count == 0)
        {
            if (s2.Count == 0)
                return 0;
        }
        else
        {
            while (s1.Count > 0)
            {
                //Move all s2 to s1, then proceed to pop
                s2.Push(s1.Pop());
            }
        }

        return s2.Peek();
    }

    public bool Empty()
    {
        return s1.Count == 0 && s2.Count == 0;
    }
}