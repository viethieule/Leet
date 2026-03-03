public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}
public static class CopyListWithRandomPointer
{
    public static Node CopyRandomList(Node head)
    {
        var cur = head;
        var map = new Dictionary<Node, int>();
        var arr = new List<Node>();
        var dummy = new Node(0);
        var copyCur = dummy;
        var i = 0;
        while (cur != null)
        {
            map.Add(cur, i);
            var node = new Node(cur.val)
            {
                random = cur.random
            };
            arr.Add(node);
            copyCur.next = node;

            copyCur = copyCur.next;
            cur = cur.next;
            i++;
        }

        copyCur = dummy.next;
        while (copyCur != null)
        {
            if (copyCur.random != null)
            {
                var index = map[copyCur.random];
                copyCur.random = arr[index];
            }
            copyCur = copyCur.next;
        }

        // LinkedListHelper.PrintArray(LinkedListHelper.ToArray(dummy.next));

        return dummy.next;
    }
}