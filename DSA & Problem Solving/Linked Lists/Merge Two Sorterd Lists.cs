using System;

// 1. The Memory Structure
public class ListNodeMerge
{
    public int val;
    public ListNodeMerge?  next;

    public ListNodeMerge(int val = 0, ListNodeMerge? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

// 2. The Algorithm
public class SolutionMerge
{
    public ListNode? MergeTwoLists(ListNode list1, ListNode list2)
    {
        //Edge case : One of the lists or both are null
        if(list1 == null || list2 == null)
        {
            if (list1 == null && list2 == null) return null;

            if(list1 == null)
            {
                return list2;
            }
            else if (list2 == null) return list1;
        }


        ListNode? current , loose, tempLoose, newHead;
        current = list1.val < list2.val? list1: list2;
        newHead = current;

        loose = current == list1 ? list2 : list1;
        tempLoose = loose;
        
        while(current != null)
        {
            //Edge case: 
            //List with current pointer ended while other list with loose pointer is not null;

            if (current.next == null)
            {
                if (loose != null)
                {
                    current.next = loose;
                }
                break;
            }
            //Check for next possible join ;)
            if(current.next != null && loose != null && current.next.val > loose.val)
            {
                //Perform merge operation
                loose = current.next;
                current.next = tempLoose;
                tempLoose = loose;
            }

            current = current.next;
        }

        return newHead;
    }
}

// 3. The Test Environment
public class Merge2SortedLists
{
    public static void Main(string[] args)
    {
        SolutionMerge solver = new SolutionMerge();

        // --- TEST CASE 1: Standard Merge ---
        // Expected: 1 -> 1 -> 2 -> 3 -> 4 -> 4 -> null
        ListNode l1_test1 = CreateList(new int[] { 1, 2, 4 });
        ListNode l2_test1 = CreateList(new int[] { 1, 3, 4 });
        Console.WriteLine("=== Test Case 1 ===");
        PrintList(solver.MergeTwoLists(l1_test1, l2_test1));

        // --- TEST CASE 2: Different Lengths ---
        // Expected: 1 -> 2 -> 3 -> 5 -> 9 -> 10 -> null
        ListNode l1_test2 = CreateList(new int[] { 1, 5, 9, 10 });
        ListNode l2_test2 = CreateList(new int[] { 2, 3 });
        Console.WriteLine("=== Test Case 2 ===");
        PrintList(solver.MergeTwoLists(l1_test2, l2_test2));

        // --- TEST CASE 3: One Empty List ---
        // Expected: 0 -> null
        ListNode l1_test3 = CreateList(new int[] { });
        ListNode l2_test3 = CreateList(new int[] { 0 });
        Console.WriteLine("=== Test Case 3 ===");
        PrintList(solver.MergeTwoLists(l1_test3, l2_test3));
    }

    // --- Helper Methods ---
    static ListNode CreateList(int[] values)
    {
        if (values == null || values.Length == 0) return null;
        ListNode head = new ListNode(values[0]);
        ListNode current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }
        return head;
    }

    static void PrintList(ListNode head)
    {
        if (head == null)
        {
            Console.WriteLine("null\n");
            return;
        }
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.val + " -> ");
            current = current.next;
        }
        Console.WriteLine("null\n");
    }
}