public static class LowestCommonAncestorBST
{
    public static TreeNode Find(TreeNode root, TreeNode p, TreeNode q)
    {
        return DFS(root, p, q);
    }

    private static TreeNode DFS(TreeNode root, TreeNode p, TreeNode q)
    {
        // return if it's p < cur < q or q < cur < p
        if ((root.val >= p.val && root.val <= q.val) || (root.val <= p.val && root.val >= q.val))
        {
            return root;
        }

        // return if cur equal to one of p or q
        if (root.val == p.val || root.val == q.val)
        {
            return root;
        }

        // go left if it's all on the left of cur
        if (root.val > p.val && root.val > q.val)
        {
            return DFS(root.left, p, q);
        }
        // or else, go right
        else
        {
            return DFS(root.right, p, q);
        }
    }

    private static TreeNode DFSClean(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || p == null || q == null)
        {
            return null;
        }

        if (Math.Max(p.val, q.val) < root.val)
        {
            return DFSClean(root.left, p, q);
        }
        else if (Math.Min(p.val, q.val) > root.val)
        {
            return DFSClean(root.right, p, q);
        }

        return root;
    }

    private static TreeNode Iteration(TreeNode root, TreeNode p, TreeNode q)
    {
        var cur = root;

        while (cur != null)
        {
            if (Math.Max(p.val, q.val) < cur.val)
            {
                cur = cur.left;
            }
            else if (Math.Min(p.val, q.val) > cur.val)
            {
                cur = cur.right;
            }
            else
            {
                return cur;
            }
        }

        return null;
    }
}