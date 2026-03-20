public class ValidBST
{
    public bool IsValidBST(TreeNode root)
    {
        return DFS(root);
    }

    private bool DFS(TreeNode root, int? left = null, int? right = null)
    {
        if (root == null)
        {
            return true;
        }

        var isValid = (left == null || left < root.val) && (right == null || root.val < right);
        if (!isValid) return false;

        var leftValid = DFS(root.left, left: left, right: root.val);
        var rightValid = DFS(root.right, left: root.val, right: right);

        return leftValid && rightValid;
    }

    private bool BFS(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        var q = new Queue<(TreeNode Node, int? Left, int? Right)>();
        q.Enqueue((root, null, null));

        while (q.Count > 0)
        {
            var (cur, left, right) = q.Dequeue();

            var isValid = (left == null || left < cur.val) && (right == null || cur.val < right);
            if (!isValid) return false;

            if (cur.left != null)
            {
                q.Enqueue((cur.left, left, cur.val));
            }
            if (cur.right != null)
            {
                q.Enqueue((cur.right, cur.val, right));
            }
        }

        return true;
    }
}