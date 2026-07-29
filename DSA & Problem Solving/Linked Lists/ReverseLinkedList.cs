using System;
using System.ComponentModel;

// 1. The Memory Structure
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

// 2. The Algorithm
public class SolutionLinkedList
{
    public ListNode? ReverseList(ListNode head)
    {
        if(head == null) return null;

        ListNode? current, prev, nextTemp;
        current = nextTemp = head;

        prev = null;

        while (current != null) {

            
            nextTemp = nextTemp != null? nextTemp.next : nextTemp;
            current.next = prev;
            prev = current;
            current = nextTemp;

        }


        return prev;
    }
}

// 3. The Test Environment
public class ReversedLinkedLists
{
    public static void Main(string[] args)
    {
        SolutionLinkedList solver = new SolutionLinkedList();

        // --- TEST CASE 1: Standard List ---
        // Expected output: 5 -> 4 -> 3 -> 2 -> 1 -> null
        ListNode test1 = CreateList(new int[] { 1, 2, 3, 4, 5 });

        Console.WriteLine("=== Test Case 1 ===");
        Console.WriteLine("Original List:");
        PrintList(test1);

        ListNode result1 = solver.ReverseList(test1);

        Console.WriteLine("Reversed List:");
        PrintList(result1);


        // --- TEST CASE 2: Two Elements ---
        // Expected output: 2 -> 1 -> null
        ListNode test2 = CreateList(new int[] { 1, 2 });

        Console.WriteLine("=== Test Case 2 ===");
        Console.WriteLine("Original List:");
        PrintList(test2);

        ListNode result2 = solver.ReverseList(test2);

        Console.WriteLine("Reversed List:");
        PrintList(result2);


        // --- TEST CASE 3: Empty List ---
        // Expected output: null
        ListNode test3 = CreateList(new int[] { });

        Console.WriteLine("=== Test Case 3 ===");
        Console.WriteLine("Original List:");
        PrintList(test3);

        ListNode result3 = solver.ReverseList(test3);

        Console.WriteLine("Reversed List:");
        PrintList(result3);
    }

    // --- Helper Methods ---

    // Quickly builds a linked list from an array
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

    // Walks the pointers and prints the chain to the console
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