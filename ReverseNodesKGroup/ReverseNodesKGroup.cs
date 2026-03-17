public static class ReverseNodesKGroup
{
    public static ListNode ReverseKGroup(ListNode head, int k)
    {
        var count = 0;
        ListNode prev = null;
        var dummy = new ListNode();
        ListNode currentTail = null;
        ListNode nextTail = null;
        var cur = head;
        while (cur != null && count < k)
        {
            var tmp = cur.next;
            cur.next = prev;
            if (prev == null)
            {
                nextTail = cur;
            }
            prev = cur;
            cur = tmp;
            count++;
            if (count >= k)
            {
                if (dummy.next == null)
                {
                    dummy.next = prev;
                }
                if (currentTail != null)
                {
                    currentTail.next = prev;
                }
                currentTail = nextTail;
                prev = null;
                count = 0;
            }
        }

        if (count < k)
        {
            ListNode prev2 = null;
            var cur2 = prev;
            while (cur2 != null)
            {
                var tmp = cur2.next;
                cur2.next = prev2;
                prev2 = cur2;
                cur2 = tmp;
            }
            currentTail.next = prev2;
        }

        return dummy.next;
    }
}