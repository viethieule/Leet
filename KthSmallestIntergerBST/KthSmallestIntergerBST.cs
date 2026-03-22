public static class KthSmallestIntergerBST
{
    public static int KthSmallest(TreeNode root, int k)
    {
        var tmp = new int[2];
        tmp[0] = k;
        DFS(root, tmp);
        return tmp[1];
    }

    private static void DFS(TreeNode node, int[] tmp)
    {
        if (node == null) return;

        DFS(node.left, tmp);

        tmp[0]--;
        if (tmp[0] == 0)
        {
            tmp[1] = node.val;
            return;
        }

        DFS(node.right, tmp);
    }
}