public static class MergeTwoSortedLinkedList
{
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var dummyHead = new ListNode();
        var cur = dummyHead;
        var cur1 = list1;
        var cur2 = list2;
        while (cur1 != null || cur2 != null)
        {
            if (cur1 == null)
            {
                cur.next = cur2;
                break;
            }
            if (cur2 == null)
            {
                cur.next = cur1;
                break;
            }
            if (cur1.val <= cur2.val)
            {
                cur.next = cur1;
                cur1 = cur1.next;
            }
            else
            {
                cur.next = cur2;
                cur2 = cur2.next;
            }
            cur = cur.next;
        }

        // cur = dummyHead.next;
        // while (cur != null)
        // {
        //     Console.WriteLine(cur.val);
        //     cur = cur.next;
        // }
        return dummyHead.next;
    }
}