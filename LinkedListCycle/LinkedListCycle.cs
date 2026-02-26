public static class LinkedListCycle
{
    public static bool HasCycle(ListNode head)
    {
        var set = new HashSet<ListNode>();
        var cur = head;
        while (cur != null)
        {
            if (!set.Add(cur))
            {
                return true;
            }

            cur = cur.next;
        }
        return false;
    }
}