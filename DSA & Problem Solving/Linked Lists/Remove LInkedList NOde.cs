using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DSA___Problem_Solving.Building_up_to_staircase
{
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class RemoveElementsTester
    {
        public static void Main()
        {
            Console.WriteLine("=== SPRINT 6: POINTER MANIPULATION ===");
            Console.WriteLine("Problem: Remove Linked List Elements (The Warm-up)\n");

            // Test Case 1: Standard removal
            // List: 1 -> 2 -> 6 -> 3 -> 4 -> 5 -> 6, val = 6
            // Expected: 1 -> 2 -> 3 -> 4 -> 5
            ListNode head1 = CreateList(new int[] { 1, 2, 6, 3, 4, 5, 6 });
            RunTest("Test Case 1 (Standard middle and end removal)", head1, 6, new int[] { 1, 2, 3, 4, 5 });

            // Test Case 2: Empty list
            // List: [], val = 1
            // Expected: []
            ListNode head2 = CreateList(new int[] { });
            RunTest("Test Case 2 (Empty List)", head2, 1, new int[] { });

            // Test Case 3: All elements are the target value
            // List: 7 -> 7 -> 7 -> 7, val = 7
            // Expected: []
            ListNode head3 = CreateList(new int[] { 7, 7, 7, 7 });
            RunTest("Test Case 3 (All elements match target)", head3, 7, new int[] { });

            Console.WriteLine("\nTesting complete. The compiler does not lie.");
        }

        public static void RunTest(string testName, ListNode head, int val, int[] expected)
        {
            RemoveElementsSolution sol = new RemoveElementsSolution();
            ListNode? result = sol.RemoveElements(head, val);

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
            foreach (int v in values)
            {
                curr.next = new ListNode(v);
                curr = curr.next;
            }
            return dummy.next;
        }

        private static int[] ListToArray(ListNode head)
        {
            List<int> list = new List<int>();
            ListNode? curr = head;
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

    public class RemoveElementsSolution
    {
        public ListNode? RemoveElements(ListNode? head, int val)
        {
            // The Forge is yours. 
            // Write your implementation here...

            //Assumes we remove the first occurance of that element ;)
            //Assumption was wrong, we need to remove every occurance of the values ;)

            ListNode? temp = head;
            ListNode? current = head;

            //Edge case the list is empty
            if (head == null) return null;


            while (current != null)
            {

                if (current.val == val) {

                    //Edge case: Removing the head:
                    if(current == head) {
                        head = head.next;                       //Head will be garbage collected ;)
                        current = head;
                        continue;
                    }

                    //Remove the element ;)
                    temp?.next = current.next;
                    current.next = null;
                    current = temp?.next;
                    continue;
                } 


                //Nothing was deleted ;)
                //Since we continue the while loop to skip this in case deletion occured ;)
                temp = current;
                current = current?.next;
            }


            return head;
        }
    }
}