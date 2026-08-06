using System;
using System.Collections.Generic;

public class SolutionReorderList
{
    public void ReorderList(ListNode head)
    {
        // The Forge is yours.
        ListNode? righP, leftP, tempL, seekerR;
        //Edge case : List is empty -> Head == null 
        if (head == null) return;

        leftP = head;
        righP = head;
        //Find the tail of the list

        while (righP.next != null) {
            righP = righP.next;
        }
                                                                                //Looping Starts
        while (true) { 
            //POsition temp properly
            tempL = leftP?.next;

            if(leftP != null) {

                //BASE CASE: EXIT: Overlap Left && Righ Pivot
                if(leftP == righP)
                {

                    leftP.next = null;
                    break;
                }
                //Perform move

                leftP.next = righP;
                leftP = tempL;

                if(righP != null)
                righP.next = leftP;

                //Seeker looks for node right before rightP
                seekerR = leftP;
                //Search for second last node
                while (seekerR != null && seekerR.next != righP) {

                    seekerR = seekerR.next;
                }

                //Shift Right Pivot to seekerR
                righP = seekerR;
            }



        }                                                                       //Looping ends here
    }

    //More optimal solution : Split_middle -> Reverse -> Join O(n) time complexity
    public void ReorderListSplitReverseJoin(ListNode head)
    {
        if (head == null || head.next == null) return;

        // Phase 1: Find the middle using Fast & Slow (Tortoise & Hare)
        ListNode slow = head;
        ListNode fast = head.next;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Sever the list into two halves
        ListNode secondHalf = slow.next;
        slow.next = null; // Break the connection

        // Phase 2: Reverse the second half (Day 1 muscle memory)
        ListNode prev = null;
        ListNode curr = secondHalf;
        while (curr != null)
        {
            ListNode tmp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = tmp;
        }

        // Phase 3: Interleave Merge (Zipper)
        ListNode first = head;
        ListNode second = prev; // 'prev' is the new head of the reversed half
        while (second != null)
        {
            // Cache the next nodes
            ListNode tmp1 = first.next;
            ListNode tmp2 = second.next;

            // Zip them together
            first.next = second;
            second.next = tmp1;

            // Move the pointers forward
            first = tmp1;
            second = tmp2;
        }
    }
}

public class TesterReOrderList
{
    public static void Main()
    {
        SolutionReorderList sol = new SolutionReorderList();
        int passed = 0;
        int total = 4;

        Console.WriteLine("🚀 RUNNING REORDER LIST TEST SUITE...\n");

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

        // Test 1: Even Length
        ListNode? t1 = BuildList(new int[] { 1, 2, 3, 4 });
        sol.ReorderList(t1);
        string res1 = ListToString(t1);
        string exp1 = "[1,4,2,3]";
        Console.WriteLine($"Test 1 (Even Length):   {(res1 == exp1 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp1}, Got: {res1})");
        if (res1 == exp1) passed++;

        // Test 2: Odd Length
        ListNode? t2 = BuildList(new int[] { 1, 2, 3, 4, 5 });
        sol.ReorderList(t2);
        string res2 = ListToString(t2);
        string exp2 = "[1,5,2,4,3]";
        Console.WriteLine($"Test 2 (Odd Length):    {(res2 == exp2 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp2}, Got: {res2})");
        if (res2 == exp2) passed++;

        // Test 3: Two Nodes
        ListNode? t3 = BuildList(new int[] { 1, 2 });
        sol.ReorderList(t3);
        string res3 = ListToString(t3);
        string exp3 = "[1,2]";
        Console.WriteLine($"Test 3 (Two Nodes):     {(res3 == exp3 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp3}, Got: {res3})");
        if (res3 == exp3) passed++;

        // Test 4: Single Node
        ListNode? t4 = BuildList(new int[] { 1 });
        sol.ReorderList(t4);
        string res4 = ListToString(t4);
        string exp4 = "[1]";
        Console.WriteLine($"Test 4 (Single Node):   {(res4 == exp4 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp4}, Got: {res4})");
        if (res4 == exp4) passed++;

        Console.WriteLine($"\n🏁 FINAL SCORE: {passed}/{total} TESTS PASSED.");
    }
}