public static class BinaryTreeRightSideView
{
    public static List<int> RightSideView(TreeNode root)
    {
        if (root == null) return null;
        var list = new List<int>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            var size = q.Count;
            while (size-- > 0)
            {
                var cur = q.Dequeue();
                if (size == 0)
                {
                    list.Add(cur.val);
                }
                if (cur.left != null)
                {
                    q.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    q.Enqueue(cur.right);
                }
            }
        }

        return list;
    }
}