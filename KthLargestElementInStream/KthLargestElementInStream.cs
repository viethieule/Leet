public class KthLargest
{
    private readonly PriorityQueue<int, int> _minHeap;
    private int _k;
    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _minHeap = new PriorityQueue<int, int>();
        foreach (var num in nums)
        {
            _minHeap.Enqueue(num, num);
            if (_minHeap.Count > k)
            {
                _minHeap.Dequeue();
            }
        }
    }

    public int Add(int val)
    {
        _minHeap.Enqueue(val, val);
        if (_minHeap.Count > _k)
        {
            _minHeap.Dequeue();
        }
        return _minHeap.Peek();
    }
}