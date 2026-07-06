using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving.Stacks___Queues
{
    using System;

    public class CircularQueue
    {
        public static void Main()
        {
            Console.WriteLine("=== DAY 4: SPRINT 4 CONTINUES ===");
            Console.WriteLine("Problem: Design Circular Queue\n");

            MyCircularQueue_Efficient q = new MyCircularQueue_Efficient(3);

            RunTest("EnQueue 1", q.EnQueue(1), true);
            RunTest("EnQueue 2", q.EnQueue(2), true);
            RunTest("EnQueue 3", q.EnQueue(3), true);
            RunTest("EnQueue 4 (Full)", q.EnQueue(4), false);

            RunTest("Rear element", q.Rear(), 3);
            RunTest("IsFull check", q.IsFull(), true);

            RunTest("DeQueue", q.DeQueue(), true);

            RunTest("EnQueue 4", q.EnQueue(4), true);
            RunTest("Rear element after EnQueue", q.Rear(), 4);

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
    /// Design a Circular Queue using a primitive array.
    /// </summary>
    public class MyCircularQueue_INEFFICIENT
    {
        // YOUR CLASS VARIABLES HERE
        int[] arr_q;

        //Insertion pointer as well as wrapper
        int size = 0; 
        public MyCircularQueue_INEFFICIENT(int k)
        {

                arr_q = new int[k];
        }
       

        public bool EnQueue(int value)
        {
            // YOUR CODE HERE

            size++;

            //Catch full capacity queue
            if(size > arr_q.Length)
            {
                size--;
                return false;
            }

            arr_q[size - 1] = value;
            return true;
        }

        public bool DeQueue()
        {
            // Empty queue, cannot dequeue;
            if (size == 0) return false;

           
            if (size > 0)
            {
                //Shift all elements to the correct place
                for (int i = 1; i < size; i++)
                {
                    arr_q[i - 1] = arr_q[i];
                }
            }

            //Done replacing first element
            //Decrease the size
            size--;
            return true;
        }

        public int Front()
        {
            return size!=0 ? arr_q[0] : -1; 
        }

        public int Rear()
        {
            return size != 0 ? arr_q[size - 1] : -1;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == arr_q.Length;
        }
    }
}


public class MyCircularQueue_Efficient
{
    // YOUR CLASS VARIABLES HERE
    int[] arr_q;

    //Insertion pointer as well as wrapper
    int size = 0;

    int front = 0;
    int back = -1;

    public MyCircularQueue_Efficient(int k)
    {
        // YOUR CODE HERE
        arr_q = new int[k];
    }

    public bool EnQueue(int value)
    {
        if (size == arr_q.Length) return false;

        back = (back +1) % arr_q.Length;
        arr_q[back] = value;
        size++;
        return true;
    }

    public bool DeQueue()
    {
        if(size == 0) return false;

        arr_q[front] = 0;
        front = (front + 1)% (arr_q.Length);
        size--;
        return true;
    }

    public int Front()
    {
        return size!=0? arr_q[front] : -1;
    }

    public int Rear()
    {
        return size != 0 ? arr_q[back] : -1;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public bool IsFull()
    {
        return size == arr_q.Length;
    }
}
