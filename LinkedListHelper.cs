public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public static class LinkedListHelper
{
    public static ListNode CreateLinkedList(int[] nums, bool hasCycle = false)
    {
        if (nums == null || nums.Length == 0)
        {
            return null;
        }

        var head = new ListNode(nums[0]);
        var cur = head;
        for (var i = 1; i < nums.Length; i++)
        {
            cur.next = new ListNode(nums[i]);
            cur = cur.next;
        }

        if (hasCycle)
        {
            cur.next = head.next;
        }
        
        return head;

    }
}