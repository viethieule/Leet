public static class MergeKSortedList
{
    public static ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0) return null;

        for (var i = 1; i < lists.Length; i++)
        {
            lists[i] = Merge(lists[i], lists[i - 1]);
        }
        return lists[lists.Length - 1];
    }

    private static ListNode Merge(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode();
        var cur = dummy;
        while (l1 != null || l2 != null)
        {
            if (l1 == null)
            {
                cur.next = l2;
                break;
            }
            if (l2 == null)
            {
                cur.next = l1;
                break;
            }
            if (l1.val <= l2.val)
            {
                cur.next = l1;
                l1 = l1.next;
            }
            else
            {
                cur.next = l2;
                l2 = l2.next;
            }
            cur = cur.next;
        }

        return dummy.next;
    }
}