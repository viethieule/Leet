public static class ReverseLinkedList
{
    public static ListNode ReverseList(ListNode head)
    {
        ListNode tail = null;
        ListNode before = null;;
        for (var cur = head; cur != null; cur = cur.next)
        {
            before = new ListNode(cur.val, tail);
            tail = before;
        }
        return tail;
    }
}