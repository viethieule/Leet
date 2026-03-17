public static class InvertBinaryTree
{
    public static TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
        {
            return root;
        }

        InvertTree(root.left);
        InvertTree(root.right);

        (root.right, root.left) = (root.left, root.right);
        return root;
    }
}