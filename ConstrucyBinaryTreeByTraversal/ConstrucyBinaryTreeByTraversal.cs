public class ConstrucyBinaryTreeByTraversal
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return Recurse(preorder, inorder);
    }

    private TreeNode Recurse(Span<int> preorder, Span<int> inorder)
    {
        if (preorder.Length == 0) return null;

        var node = new TreeNode(preorder[0]);
        var mid = FindRootIndex(preorder, inorder);

        Span<int> preorderLeft = mid == 0 ? [] : mid + 1 >= preorder.Length ? preorder[1..] : preorder[1..(mid + 1)];
        Span<int> inorderLeft = mid == 0 ? [] : inorder[0..mid];
        node.left = Recurse(preorderLeft, inorderLeft);

        Span<int> preorderRight = mid + 1 >= preorder.Length ? [] : preorder[(mid + 1)..];
        Span<int> inorderRight = mid + 1 >= inorder.Length ? [] : inorder[(mid + 1)..];
        node.right = Recurse(preorderRight, inorderRight);

        return node;
    }

    private int FindRootIndex(Span<int> preorder, Span<int> inorder)
    {
        for (var i = 0; i < inorder.Length; i++)
        {
            if (inorder[i] == preorder[0])
            {
                return i;
            }
        }
        return -1;
    }
}