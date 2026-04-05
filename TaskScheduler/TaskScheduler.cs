public class TaskScheduler
{
    public int LeastInterval(char[] tasks, int n)
    {
        var minHeap = new PriorityQueue<char, int>();
        var map = new Dictionary<char, int>();
        var cycle = 1;
        var i = 0;
        while (i < tasks.Length || minHeap.Count > 0)
        {
            if (minHeap.TryPeek(out var element, out var priority) && cycle - priority > n)
            {
                minHeap.Dequeue();
                cycle++;
            }
            else if (i < tasks.Length)
            {
                var task = tasks[i];
                if (map.TryGetValue(task, out int lastCycle))
                {
                    if (cycle - lastCycle > n)
                    {
                        map[task] = cycle;
                        cycle++;
                    }
                    else
                    {
                        minHeap.Enqueue(task, lastCycle);
                    }
                }
                else
                {
                    map[task] = cycle;
                    cycle++;
                }
                i++;
            }
            else
            {
                cycle++;
            }
        }
        return cycle;
    }
}