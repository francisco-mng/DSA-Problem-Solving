using System;
using System.Collections.Generic;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class SolutionMaxDepth
{
    public int MaxDepth(TreeNode root)
    {
        // The Forge is yours.
        // Write your implementation here...
        int currVal = 1;
        int max = 0;

        GetMaxDepth(root, currVal, ref max);

        return max; // Default return to make it compile
    }

    //Helper function
    private void GetMaxDepth(TreeNode? node, int val, ref int max)
    {
        if(node== null) return;

        max = val>=max? val : max;

        //Left -> Right DFS
        GetMaxDepth(node.left, val+1 , ref max);
        GetMaxDepth(node.right, val+1 , ref max);
        
    }
}

public class TesterMaxDepth
{
    public static void Main()
    {
        SolutionMaxDepth sol = new SolutionMaxDepth();
        int passed = 0;
        int total = 4;

        Console.WriteLine("🚀 RUNNING MAXIMUM DEPTH TEST SUITE...\n");

        // Test 1: Standard Tree (Depth 3)
        //       3
        //      / \
        //     9  20
        //       /  \
        //      15   7
        TreeNode t1 = new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7))
        );
        int res1 = sol.MaxDepth(t1);
        Console.WriteLine($"Test 1 (Standard Tree):  {(res1 == 3 ? "✅ PASS" : "❌ FAIL")} (Expected: 3, Got: {res1})");
        if (res1 == 3) passed++;

        // Test 2: Unbalanced Tree (Depth 2)
        //       1
        //        \
        //         2
        TreeNode t2 = new TreeNode(1, null, new TreeNode(2));
        int res2 = sol.MaxDepth(t2);
        Console.WriteLine($"Test 2 (Unbalanced):     {(res2 == 2 ? "✅ PASS" : "❌ FAIL")} (Expected: 2, Got: {res2})");
        if (res2 == 2) passed++;

        // Test 3: Single Node (Depth 1)
        TreeNode t3 = new TreeNode(1);
        int res3 = sol.MaxDepth(t3);
        Console.WriteLine($"Test 3 (Single Node):    {(res3 == 1 ? "✅ PASS" : "❌ FAIL")} (Expected: 1, Got: {res3})");
        if (res3 == 1) passed++;

        // Test 4: Empty Tree (Depth 0)
        TreeNode t4 = null;
        int res4 = sol.MaxDepth(t4);
        Console.WriteLine($"Test 4 (Empty Tree):     {(res4 == 0 ? "✅ PASS" : "❌ FAIL")} (Expected: 0, Got: {res4})");
        if (res4 == 0) passed++;

        Console.WriteLine($"\n🏁 FINAL SCORE: {passed}/{total} TESTS PASSED.");
    }
}