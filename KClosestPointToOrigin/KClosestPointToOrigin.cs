public class KClosestPointToOrigin
{
    public int[][] KClosest(int[][] points, int k)
    {
        var minHeap = new PriorityQueue<int[], double>();
        foreach (var point in points)
        {
            var distance = Math.Sqrt(Math.Pow(point[0],  2) + Math.Pow(point[1], 2));
            minHeap.Enqueue(point, distance * -1);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }
        return minHeap.UnorderedItems.Select(x => x.Element).ToArray();
    }
}