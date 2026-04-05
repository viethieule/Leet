public static class BinaryTreeLevelOrderTraversal
{
    public static List<List<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
        {
            return new List<List<int>>();
        }
        var list = new List<List<int>>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var size = queue.Count;
            var innerList = new List<int>();
            while (size-- > 0)
            {
                var cur = queue.Dequeue();
                innerList.Add(cur.val);

                if (cur.left != null)
                {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    queue.Enqueue(cur.right);
                }
            }
            list.Add(innerList);
        }

        return list;
    }
}