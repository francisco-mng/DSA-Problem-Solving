
public class SolutionInvertBinaryTree
{



    public TreeNode? InvertTree(TreeNode? node)
    {
        Invert(node);
        return node;
    }

    public void Invert(TreeNode ? node)
    {
        //Base case -> Exit for recursive function.s
        if (node == null) return;


        TreeNode? tmpL = null;
        tmpL = node.left;
        node.left = node.right;
        node.right = tmpL;

        //Recursive calls
        Invert(node.left);
        Invert(node.right);
    }
}

public class TesterInvertBinaryTree
{
    public static void Main()
    {
        SolutionInvertBinaryTree sol = new SolutionInvertBinaryTree();
        int passed = 0;
        int total = 3;

        Console.WriteLine("🚀 RUNNING INVERT TREE TEST SUITE...\n");

        // Helper function to serialize tree to level-order string for easy comparison
        string TreeToString(TreeNode? root)
        {
            if (root == null) return "[]";
            List<string> res = new List<string>();
            Queue<TreeNode?> q = new Queue<TreeNode?>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode? curr = q.Dequeue();
                if (curr != null)
                {
                    res.Add(curr.val.ToString());
                    q.Enqueue(curr.left);
                    q.Enqueue(curr.right);
                }
            }
            return "[" + string.Join(",", res) + "]";
        }

        // Test 1: Full Tree
        //      4                 4
        //    /   \             /   \
        //   2     7    =>     7     2
        //  / \   / \         / \   / \
        // 1   3 6   9       9   6 3   1
        TreeNode t1 = new TreeNode(4,
            new TreeNode(2, new TreeNode(1), new TreeNode(3)),
            new TreeNode(7, new TreeNode(6), new TreeNode(9))
        );
        string res1 = TreeToString(sol.InvertTree(t1));
        string exp1 = "[4,7,2,9,6,3,1]";
        Console.WriteLine($"Test 1 (Full Tree):     {(res1 == exp1 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp1}, Got: {res1})");
        if (res1 == exp1) passed++;

        // Test 2: Small Tree
        TreeNode t2 = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        string res2 = TreeToString(sol.InvertTree(t2));
        string exp2 = "[2,3,1]";
        Console.WriteLine($"Test 2 (Small Tree):    {(res2 == exp2 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp2}, Got: {res2})");
        if (res2 == exp2) passed++;

        // Test 3: Empty Tree
        TreeNode? t3 = null;
        string res3 = TreeToString(sol.InvertTree(t3));
        string exp3 = "[]";
        Console.WriteLine($"Test 3 (Empty Tree):    {(res3 == exp3 ? "✅ PASS" : "❌ FAIL")} (Expected: {exp3}, Got: {res3})");
        if (res3 == exp3) passed++;

        Console.WriteLine($"\n🏁 FINAL SCORE: {passed}/{total} TESTS PASSED.");
    }
}