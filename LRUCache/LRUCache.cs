public class LRUCache
{
    private readonly LinkedList<int> list;
    private readonly Dictionary<int, int> map;
    public LRUCache(int capacity)
    {
        list = new LinkedList<int>();
        map = new Dictionary<int, int>(capacity);
    }

    public int Get(int key)
    {
        if (!map.TryGetValue(key, out int value))
        {
            return -1;
        }
        list.AddLast(key);
        return value;
    }

    public void Put(int key, int value)
    {

    }
}
