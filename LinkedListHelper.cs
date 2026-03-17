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

    public static Node CreateLinkedListWithRandomPointer(int?[][] arr)
    {
        if (arr == null || arr.Length == 0)
            return null;

        int n = arr.Length;

        // Step 1: Create all nodes
        Node[] nodes = new Node[n];
        for (int i = 0; i < n; i++)
        {
            nodes[i] = new Node(arr[i][0].Value);
        }

        // Step 2: Set next pointers
        for (int i = 0; i < n - 1; i++)
        {
            nodes[i].next = nodes[i + 1];
        }

        // Step 3: Set random pointers
        for (int i = 0; i < n; i++)
        {
            int? randomIndex = arr[i][1];

            if (randomIndex.HasValue)
            {
                nodes[i].random = nodes[randomIndex.Value];
            }
        }

        return nodes[0];
    }

    public static int?[][] ToArray(Node head)
    {
        if (head == null)
            return Array.Empty<int?[]>();

        // Step 1: Traverse list and collect nodes
        var nodes = new List<Node>();
        var current = head;

        while (current != null)
        {
            nodes.Add(current);
            current = current.next;
        }

        // Step 2: Map each node to its index
        var indexMap = new Dictionary<Node, int>();
        for (int i = 0; i < nodes.Count; i++)
        {
            indexMap[nodes[i]] = i;
        }

        // Step 3: Build result array
        var result = new int?[nodes.Count][];

        for (int i = 0; i < nodes.Count; i++)
        {
            int val = nodes[i].val;
            int? randomIndex = null;

            if (nodes[i].random != null)
            {
                randomIndex = indexMap[nodes[i].random];
            }

            result[i] = new int?[] { val, randomIndex };
        }

        return result;
    }

    public static void PrintNodes(ListNode head)
    {
        var cur = head;
        while (cur != null)
        {
            Console.WriteLine(cur.val);
            cur = cur.next;
        }
    }

    public static void PrintArray(int?[][] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.Write("[");

        for (int i = 0; i < arr.Length; i++)
        {
            var val = arr[i][0];
            var randomIndex = arr[i][1];

            Console.Write("[" + val + "," +
                (randomIndex.HasValue ? randomIndex.Value.ToString() : "null") + "]");

            if (i < arr.Length - 1)
                Console.Write(",");
        }

        Console.WriteLine("]");
    }
}