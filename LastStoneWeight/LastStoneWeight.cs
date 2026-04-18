public class LastStoneWeightProblem
{
    public int LastStoneWeight(int[] stones)
    {
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        foreach (var stone in stones)
        {
            maxHeap.Enqueue(stone, stone);
        }

        while (maxHeap.Count > 1)
        {
            var s1 = maxHeap.Dequeue();
            var s2 = maxHeap.Dequeue();
            var remain = Math.Abs(s1 - s2);
            maxHeap.Enqueue(remain, remain);
        }

        return maxHeap.Dequeue();
    }
}