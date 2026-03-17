public static class SubtreeOfAnotherTree
{
    public static bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (subRoot == null)
        {
            return true;
        }
        if (root == null)
        {
            return false;
        }
        if (IsSameTree(root, subRoot))
        {
            return true;   
        }

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p?.val == q?.val)
        {
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        else
        {
            return false;
        }
    }
}