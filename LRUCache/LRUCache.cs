public class LRUCache
{
    private readonly LinkedList<int> list;
    private readonly Dictionary<int, (int Value, LinkedListNode<int> Node)> map;
    private readonly int _capacity;
    public LRUCache(int capacity)
    {
        list = new LinkedList<int>();
        map = new Dictionary<int, (int Value, LinkedListNode<int> Node)>(capacity);
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (!map.TryGetValue(key, out var value))
        {
            return -1;
        }

        list.Remove(value.Node);
        var newNode = new LinkedListNode<int>(key);
        map[key] = (value.Value, newNode);
        list.AddLast(newNode);

        return value.Value;
    }

    public void Put(int key, int value)
    {
        var node = new LinkedListNode<int>(key);
        if (map.TryGetValue(key, out var currentValue))
        {
            list.Remove(currentValue.Node);
        }
        else if (map.Count >= _capacity)
        {
            map.Remove(list.First.Value);
            list.RemoveFirst();
        }
        map[key] = (value, node);
        list.AddLast(node);
    }
}
