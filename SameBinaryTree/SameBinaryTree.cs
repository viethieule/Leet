public static class SameBinaryTree
{
    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        var queue1 = new Queue<TreeNode>();
        var queue2 = new Queue<TreeNode>();

        queue1.Enqueue(p);
        queue2.Enqueue(q);

        while (queue1.Count > 0 && queue2.Count > 0)
        {
            var size = queue1.Count;
            while (size-- > 0)
            {
                var cur1 = queue1.Dequeue();
                var cur2 = queue2.Dequeue();

                if (cur1 == null && cur2 == null) return false;
                if (cur1 == null || cur2 == null || cur1.val != cur2.val) return false;

                queue1.Enqueue(cur1.left);
                queue2.Enqueue(cur2.left);
                queue1.Enqueue(cur1.right);
                queue2.Enqueue(cur2.right);
            }
        }

        return true;
    }

    public static bool IsSameTreeDFS(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p?.val == q?.val)
        {
            return IsSameTreeDFS(p.left, q.left) && IsSameTreeDFS(p.right, q.right);
        }
        else
        {
            return false;
        }
    }
}