public static class CountGoodNodesBinaryTree
{
    private static int res = 0;
    public static int GoodNodes(TreeNode root)
    {
        DFS(root);
        return res;
    }

    private static void DFS(TreeNode root, int? max = null)
    {
        if (root == null)
        {
            return;
        }
        
        if (max == null || root.val > max)
        {
            res++;
        }
        
        if (max == null) max = root.val;
        else max = Math.Max(root.val, max.Value);

        DFS(root.left, max);
        DFS(root.right, max);
    }
}