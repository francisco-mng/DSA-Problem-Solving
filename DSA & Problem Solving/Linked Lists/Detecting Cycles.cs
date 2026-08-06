using System;



public class DetectingCycleTester
{
    public static void Main()
    {
        SolutionCycles sol = new SolutionCycles();
        int passed = 0;
        int total = 5;

        Console.WriteLine("🚀 RUNNING CYCLE DETECTION TEST SUITE...\n");

        // Test 1: Standard Cycle (Tail connects back to Node 1)
        // 3 -> 2 -> 0 -> -4 -+
        //      ^             |
        //      +-------------+
        ListNode t1_0 = new ListNode(3);
        ListNode t1_1 = new ListNode(2);
        ListNode t1_2 = new ListNode(0);
        ListNode t1_3 = new ListNode(-4);
        t1_0.next = t1_1; t1_1.next = t1_2; t1_2.next = t1_3;
        t1_3.next = t1_1; // Creates the cycle

        bool res1 = sol.HasCycle(t1_0);
        Console.WriteLine($"Test 1 (Standard Cycle):       {(res1 == true ? "✅ PASS" : "❌ FAIL")} (Expected: True, Got: {res1})");
        if (res1) passed++;

        // Test 2: No Cycle (Standard straight list)
        // 1 -> 2 -> null
        ListNode t2_0 = new ListNode(1);
        ListNode t2_1 = new ListNode(2);
        t2_0.next = t2_1;

        bool res2 = sol.HasCycle(t2_0);
        Console.WriteLine($"Test 2 (No Cycle):             {(res2 == false ? "✅ PASS" : "❌ FAIL")} (Expected: False, Got: {res2})");
        if (!res2) passed++;

        // Test 3: Single Node, No Cycle
        // 1 -> null
        ListNode t3_0 = new ListNode(1);

        bool res3 = sol.HasCycle(t3_0);
        Console.WriteLine($"Test 3 (Single Node No Cycle): {(res3 == false ? "✅ PASS" : "❌ FAIL")} (Expected: False, Got: {res3})");
        if (!res3) passed++;

        // Test 4: Single Node, WITH Cycle (Points to itself)
        // 1 -+
        // ^  |
        // +--+
        ListNode t4_0 = new ListNode(1);
        t4_0.next = t4_0;

        bool res4 = sol.HasCycle(t4_0);
        Console.WriteLine($"Test 4 (Single Node Cycle):    {(res4 == true ? "✅ PASS" : "❌ FAIL")} (Expected: True, Got: {res4})");
        if (res4) passed++;

        // Test 5: Empty List
        // null
        bool res5 = sol.HasCycle(null);
        Console.WriteLine($"Test 5 (Empty List):           {(res5 == false ? "✅ PASS" : "❌ FAIL")} (Expected: False, Got: {res5})");
        if (!res5) passed++;

        Console.WriteLine($"\n🏁 FINAL SCORE: {passed}/{total} TESTS PASSED.");
    }
}
public class SolutionCycles
{
    public bool HasCycle(ListNode? head)
    {
        //Constraint -> O(1) additional space complexity.
        //Constraint -> O(n) time complexity.

        // Write your implementation here...

        //Edge case : List is empty -> No cycles by definition
        if(head == null) return false;


        ListNode? fast = head;
        ListNode? slow = head;

        //What about moving the fast pointer twice and slow pointer 1 time. 
        //If fast pointer == slow pointer then we found cycle. 
        //If fast pointer == null then there's no cycle.

        while(fast != null)
        {
            //Mathematical observation : 1x move for slow pointer && 2x for the fast pointer ->Eventually they'll overlap
            fast = fast.next;
            fast = fast?.next;
            slow = slow?.next;

            if (fast == slow && slow != null) return true;
        }

        //If we exit the loop then there's no cycle -> Design


        return false; // Default return to make it compile
    }
}