public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public static class BinaryTreeHelper
{
    public static void TraverseDFS(this TreeNode node, bool print = false)
    {
        if (node == null)
        {
            return;
        }
        if (print) Console.WriteLine(node.val); // --> This case: preorder

        // pre-order position
        node.left.TraverseDFS();
        // in-order position
        node.right.TraverseDFS();
        // post-order position
    }

    public static void TraverseBFS1(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(node);
        while (queue.Count > 0)
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
    }

    public static void TraverseBFS2(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(node);
        var depth = 1;

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
    }

    public static void TraverseBFS3(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        var queue = new Queue<(TreeNode Node, int Depth)>();
        queue.Enqueue((node, 1));

        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();

            if (cur.Node.left != null)
            {
                queue.Enqueue((cur.Node.left, cur.Depth + 1));
            }
            if (cur.Node.right != null)
            {
                queue.Enqueue((cur.Node.right, cur.Depth + 1));
            }
        }
    }

    public static void InsertBST(TreeNode node, int val)
    {
        
    }

    public static TreeNode BuildTree(int?[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null)
            return null;

        TreeNode root = new TreeNode(values[0].Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;
        while (i < values.Length)
        {
            TreeNode current = queue.Dequeue();

            // Handle Left Child
            if (i < values.Length && values[i] != null)
            {
                current.left = new TreeNode(values[i].Value);
                queue.Enqueue(current.left);
            }
            i++;

            // Handle Right Child
            if (i < values.Length && values[i] != null)
            {
                current.right = new TreeNode(values[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }
}