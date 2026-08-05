using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving.Building_up_to_staircase
{
    // Definition for singly-linked list.
   
    public class LinkedListTester
    {
        public static void Main()
        {
            Console.WriteLine("=== SPRINT 6: POINTER MANIPULATION ===");
            Console.WriteLine("Problem: Remove Nth Node From End of List\n");

            // Test Case 1: Standard removal (Remove 2nd from end)
            // List: 1 -> 2 -> 3 -> 4 -> 5, n = 2
            // Expected: 1 -> 2 -> 3 -> 5
            ListNode head1 = CreateList(new int[] { 1, 2, 3, 4, 5 });
            RunTest("Test Case 1 (Standard Middle Removal)", head1, 2, new int[] { 1, 2, 3, 5 });

            // Test Case 2: Remove the only node (Remove 1st from end)
            // List: 1, n = 1
            // Expected: []
            ListNode head2 = CreateList(new int[] { 1 });
            RunTest("Test Case 2 (Single Node Removal)", head2, 1, new int[] { });

            // Test Case 3: Remove the head node (Remove 2nd from end)
            // List: 1 -> 2, n = 2
            // Expected: 2
            ListNode head3 = CreateList(new int[] { 1, 2 });
            RunTest("Test Case 3 (Remove Head Node)", head3, 2, new int[] { 2 });

            Console.WriteLine("\nTesting complete. The compiler does not lie.");
        }

        public static void RunTest(string testName, ListNode head, int n, int[] expected)
        {
            SolutionRemoveKthNodesFromEnd sol = new SolutionRemoveKthNodesFromEnd();
            ListNode result = sol.RemoveNthNodeFromEndSinglePass(head, n);

            int[] resultArray = ListToArray(result);
            bool passed = ArraysEqual(resultArray, expected);

            if (passed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] {testName}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] {testName} | Expected: [{string.Join(", ", expected)}], Got: [{string.Join(", ", resultArray)}]");
            }
            Console.ResetColor();
        }

        // Helper methods for the tester
        private static ListNode CreateList(int[] values)
        {
            if (values == null || values.Length == 0) return null;
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;
            foreach (int val in values)
            {
                curr.next = new ListNode(val);
                curr = curr.next;
            }
            return dummy.next;
        }

        private static int[] ListToArray(ListNode head)
        {
            List<int> list = new List<int>();
            ListNode curr = head;
            while (curr != null)
            {
                list.Add(curr.val);
                curr = curr.next;
            }
            return list.ToArray();
        }

        private static bool ArraysEqual(int[] a1, int[] a2)
        {
            if (a1.Length != a2.Length) return false;
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i]) return false;
            }
            return true;
        }
    }

    public class SolutionRemoveKthNodesFromEnd
    {
        public ListNode? RemoveNthFromEndTwoPasses(ListNode? head, int n)
        {
            if(head == null) return null;

            //Count how many element there are ;)
            int size = 0;

            ListNode? curr = head;
            ListNode? temp;

            while(curr != null)
            {
                size++; 
                curr = curr.next;
            }


            if(n > size)
            {
                return head; //-> Return the list as is. 
            }


            //Perform deletion operation at appropriate value
            int target = size - n;
            int v_index = 0;

            if(target == 0)
            {
                return head.next;
            }

            curr = head;

            while(curr != null && v_index < target -1)
            {
                v_index++;
                curr = curr.next;
            }


            if (curr != null)
            {
                temp = curr.next;
                curr.next = curr?.next?.next;
                temp?.next = null;
            }

            return head;
        }

        public ListNode? RemoveNthNodeFromEndSinglePass(ListNode? head, int n)
        {
            //List is empty -> NO nodes
            if(head == null) return null;

            int gap = n + 1;

            ListNode? fast, slow, temp;
            fast = slow = head;

            int f_index = 0;
            int s_index = 0;

            while(fast != null)
            {
                fast = fast.next;
                f_index++;

                if(f_index- s_index > gap)
                {
                    slow = slow?.next;
                    s_index++;
                }
            }

            //Edge case for removing the head! ;)
            if(s_index == 0) { head = head.next; return head; }

            //Slow pointer is at our strategic position
            //Commmence deletion

            temp = slow?.next;
            slow?.next = slow?.next?.next;
            temp?.next = null;

            return head;
        }
    }
}