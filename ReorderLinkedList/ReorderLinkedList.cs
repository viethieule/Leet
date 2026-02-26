public static class ReorderLinkedList
{
    public static void ReorderList(ListNode head)
    {
        var list = new List<ListNode>();
        var cur = head;
        while (cur != null)
        {
            list.Add(cur);
            cur = cur.next;
        }
        if (list.Count <= 2)
        {
            return;
        }

        for (var i = 0; i < list.Count / 2; i++)
        {
            list[i].next = list[list.Count - 1 - i];
            if (list.Count - 1 - i != list.Count / 2)
            {
                list[list.Count - 1 - i].next = list[i + 1];
            }
        }
        list[list.Count / 2].next = null;

        cur = head;
        while (cur != null)
        {
            Console.WriteLine(cur.val);
            cur = cur.next;
        }
    }
}