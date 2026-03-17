public static class MaxDepthOfBinaryTree
{
    public static int MaxDepthBFS(TreeNode root)
    {
        if (root == null) return 0;

        var depth = 1;
        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var size = queue.Count;
            while (size-- > 0)
            {
                var cur = queue.Dequeue();
                if (cur.left != null)
                {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    queue.Enqueue(cur.right);
                }
            }
            depth++;
        }

        return depth;
    }

    public static int MaxDepthDFS(TreeNode root)
    {
        if (root == null) return 0;

        return 1 + Math.Max(MaxDepthDFS(root.left), MaxDepthDFS(root.right));
    }

    public static int MaxDepthBFS3(TreeNode root)
    {
        if (root == null) return 0;

        var res = 1;
        var queue = new Queue<(TreeNode Node, int Depth)>();
        queue.Enqueue((root, 1));

        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            res = Math.Max(res, cur.Depth);
            
            if (cur.Node.left != null)
            {
                queue.Enqueue((cur.Node.left, cur.Depth + 1));
            }
            if (cur.Node.right != null)
            {
                queue.Enqueue((cur.Node.right, cur.Depth + 1));
            }
        }

        return res;
    }
}