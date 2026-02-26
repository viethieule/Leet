public static class RemoveNthNodeFromEnd
{
    public static ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var cur = head;
        var list = new List<ListNode>();
        while (cur != null)
        {
            list.Add(cur);
            cur = cur.next;
        }

        var index = list.Count - n;
        if (index == 0)
        {
            return head.next;
        }

        list[index - 1].next = index == list.Count - 1 ? null : list[index + 1];
        list[index].next = null;

        return head;
    }

    public static ListNode RemoveOnePass(ListNode head, int n)
    {
        var dummy = new ListNode(0, head);
        var slow = dummy;
        var fast = dummy;
        var distance = 0;
        while (fast != null && fast.next != null)
        {
            fast = fast.next;
            distance++;
            if (distance > n)
            {
                slow = slow.next;
                distance--;
            }
        }
        slow.next = slow.next.next;
        return dummy.next;
    }

    public static void PrintList(ListNode head)
    {
        var current = head;

        while (current != null)
        {
            Console.Write(current.val);

            if (current.next != null)
                Console.Write(" -> ");

            current = current.next;
        }

        Console.WriteLine();
    }
}