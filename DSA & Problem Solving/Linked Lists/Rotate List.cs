
using System;
using System.Collections.Generic;


public class SolutionRotation
{
    public ListNode? RotateLeft(ListNode? head, int k)
    {
        // The Forge is yours.
        // Write your implementation here...

        //Edge case: List is empty; -> Return null



        if (head == null) return null;
        //Find the new start using % like wrapping mechanism

        int moves = k;
        ListNode? newStart = head, seekerA = head, seekerB;

        while (moves > 0)
        {
            //Move newstart to the following node + wrapping around pivot as head
            newStart = newStart.next;
            if (newStart == null) newStart = head;
            moves--;
        }

        //Edge case: NewStart == head
        if (newStart == head) return head;

        seekerB = newStart;
        //Now we have to link the sublist starting from newStart -> null with pivot -> newStart


        //Get SublistA join point
        while (seekerA != null && seekerA.next!= seekerB)
        {
            seekerA = seekerA?.next;
        }


        //Get SublistB joing point
        while (seekerB.next != null)
        {
            seekerB = seekerB.next;
        }


        //Join the two lists with new pivot points ;)
        if(seekerA != null)
            seekerA.next = null;


        seekerB.next = head;

        head = newStart;

        return head; // Default return to make it compile
    }

    public ListNode? RotateListLeftOptimalUsingModuloAndCirclularList(ListNode? head, int k)
    {
        // 1. Edge cases
        if (head == null || head.next == null || k == 0) return head;

        // 2. Find the length and the original tail
        ListNode tail = head;
        int length = 1;
        while (tail.next != null)
        {
            tail = tail.next;
            length++;
        }

        // 3. Calculate effective rotations
        k = k % length;
        if (k == 0) return head; // No rotation needed!

        // 4. Close the loop (make it circular)
        tail.next = head;

        // 5. Find the new tail (for Left Rotation, it is 'k' steps from the start)
        // Since our length loop already started at 1, we march a pointer k-1 times.
        ListNode newTail = head;
        for (int i = 0; i < k - 1; i++)
        {
            newTail = newTail.next;
        }

        // 6. The new head is right after the new tail. Sever the connection.
        ListNode newHead = newTail.next;
        newTail.next = null;

        return newHead;
    }
}

public class TesterRotation
{
    public static void Main()
    {
        SolutionRotation sol = new SolutionRotation();
        int passed = 0;
        int total = 5;

        Console.WriteLine("🚀 RUNNING LEFT ROTATION TEST SUITE...\n");

        // Helper function to build lists
        ListNode? BuildList(int[] values)
        {
            if (values.Length == 0) return null;
            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }
            return head;
        }

        // Helper function to convert list to string for clean output
        string ListToString(ListNode? head)
        {
            if (head == null) return "[]";
            List<int> vals = new List<int>();
            while (head != null)
            {
                vals.Add(head.val);
                head = head.next;
            }
            return "[" + string.Join(",", vals) + "]";
        }

        // Test 1: Standard Rotation (k < length)
        ListNode? t1 = BuildList(new int[] { 1, 2, 3, 4, 5 });
        string res1 = ListToString(sol.RotateLeft(t1, 2));
        string exp1 = "[3,4,5,1,2]";
        Console.WriteLine($"Test 1 (Standard):      {(res1 == exp1 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp1}, Got: {res1})");
        if (res1 == exp1) passed++;

        // Test 2: Heavy Rotation (k > length)
        ListNode? t2 = BuildList(new int[] { 0, 1, 2 });
        string res2 = ListToString(sol.RotateLeft(t2, 4));
        string exp2 = "[1,2,0]";
        Console.WriteLine($"Test 2 (k > length):    {(res2 == exp2 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp2}, Got: {res2})");
        if (res2 == exp2) passed++;

        // Test 3: Exact Length Rotation (k == length)
        ListNode? t3 = BuildList(new int[] { 1, 2, 3 });
        string res3 = ListToString(sol.RotateLeft(t3, 3));
        string exp3 = "[1,2,3]";
        Console.WriteLine($"Test 3 (k == length):   {(res3 == exp3 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp3}, Got: {res3})");
        if (res3 == exp3) passed++;

        // Test 4: Empty List
        ListNode? t4 = BuildList(new int[] { });
        string res4 = ListToString(sol.RotateLeft(t4, 1));
        string exp4 = "[]";
        Console.WriteLine($"Test 4 (Empty List):    {(res4 == exp4 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp4}, Got: {res4})");
        if (res4 == exp4) passed++;

        // Test 5: Single Node
        ListNode? t5 = BuildList(new int[] { 1 });
        string res5 = ListToString(sol.RotateLeft(t5, 99));
        string exp5 = "[1]";
        Console.WriteLine($"Test 5 (Single Node):   {(res5 == exp5 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp5}, Got: {res5})");
        if (res5 == exp5) passed++;

        Console.WriteLine($"\n🏁 FINAL SCORE: {passed}/{total} TESTS PASSED.");
    }
}










