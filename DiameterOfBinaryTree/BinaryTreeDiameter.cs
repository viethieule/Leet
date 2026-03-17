public static class BinaryTreeDiameter
{
    public static int DiameterOfBinaryTree(TreeNode root)
    {
        return DFS(root);
    }

    private static int DFS(TreeNode root)
    {
        if (root == null) return 0;

        var left = DFS(root.left);
        var right = DFS(root.right);

        return 1 + Math.Max(left, right);
    }
}