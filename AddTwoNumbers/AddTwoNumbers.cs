public static class AddTwoNumbers
{
    public static ListNode Add(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode();
        var cur = dummy;
        var cur1 = l1;
        var cur2 = l2;
        var carry = 0;
        while (cur1 != null || cur2 != null || carry != 0)
        {
            var val1 = cur1?.val ?? 0;
            var val2 = cur2?.val ?? 0;
            var val = val1 + val2 + carry;
            carry = val / 10;
            val %= 10;
            cur.next = new ListNode(val);
            cur = cur.next;
            cur1 = cur1?.next;
            cur2 = cur2?.next;
        }
        return dummy.next;
    }
}