using System;


public class SolutionSameTree
{
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        // The Forge is yours.
        // Write your implementation here...
        //Strategy : Run 2 DFS algorithms, and if at any point p and q != then return false.


        //Null case
        if(p == null || q == null)
        {
            if (p == q) return true;
            else return false;
        }


        //Non-null case
        if(p.val != q.val) return false;
    

        //Recursive calls
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}

public class TesterSameTree
{
    public static void Main()
    {
        SolutionSameTree sol = new SolutionSameTree();
        int passed = 0;
        int total = 4;

        Console.WriteLine("🚀 RUNNING SAME TREE TEST SUITE...\n");

        // Test 1: Identical Trees
        TreeNode p1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        TreeNode q1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        bool res1 = sol.IsSameTree(p1, q1);
        Console.WriteLine($"Test 1 (Identical):         {(res1 == true ? "✅ PASS" : "❌ FAIL")} (Expected: True, Got: {res1})");
        if (res1 == true) passed++;

        // Test 2: Structural Mismatch (Left vs Right)
        TreeNode p2 = new TreeNode(1, new TreeNode(2), null);
        TreeNode q2 = new TreeNode(1, null, new TreeNode(2));
        bool res2 = sol.IsSameTree(p2, q2);
        Console.WriteLine($"Test 2 (Struct Mismatch):   {(res2 == false ? "✅ PASS" : "❌ FAIL")} (Expected: False, Got: {res2})");
        if (res2 == false) passed++;

        // Test 3: Value Mismatch
        TreeNode p3 = new TreeNode(1, new TreeNode(2), new TreeNode(1));
        TreeNode q3 = new TreeNode(1, new TreeNode(1), new TreeNode(2));
        bool res3 = sol.IsSameTree(p3, q3);
        Console.WriteLine($"Test 3 (Value Mismatch):    {(res3 == false ? "✅ PASS" : "❌ FAIL")} (Expected: False, Got: {res3})");
        if (res3 == false) passed++;

        // Test 4: Empty Trees
        TreeNode? p4 = null;
        TreeNode? q4 = null;
        bool res4 = sol.IsSameTree(p4, q4);
        Console.WriteLine($"Test 4 (Empty Trees):       {(res4 == true ? "✅ PASS" : "❌ FAIL")} (Expected: True, Got: {res4})");
        if (res4 == true) passed++;

        Console.WriteLine($"\n🏁 FINAL SCORE: {passed}/{total} TESTS PASSED.");
    }
}