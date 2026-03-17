public static class BalancedBinaryTree
{
    private static bool _balanced = true;
    public static bool IsBalanced(TreeNode root)
    {
        return DFS2(root).Balanced;
    }

    private static int DFS(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        var left = DFS(node.left);
        var right = DFS(node.right);

        if (Math.Abs(left - right) > 1)
        {
            _balanced = false;
        }
        return 1 + Math.Max(left, right);
    }

    // You can return anything to track data from the recursive func
    private static (bool Balanced, int Height) DFS2(TreeNode node)
    {
        if (node == null)
        {
            return (true, 0);
        }

        var left = DFS2(node.left);
        var right = DFS2(node.right);

        var balanced = left.Balanced && right.Balanced && Math.Abs(left.Height - right.Height) <= 1;
        return (balanced, 1 + Math.Max(left.Height, right.Height));
    }
}