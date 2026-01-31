
static class TopKFrequentProblem
{
    public static int[] TopKFrequent(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
        var freqs = new Dictionary<int, HashSet<int>>(2001);
        var max = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (map.TryGetValue(num, out int value))
            {
                map[num] = ++value;
            }
            else
            {
                value = 1;
                map[num] = value;
            }

            if (freqs.TryGetValue(value, out var listNums))
            {
                listNums.Add(num);
            }
            else
            {
                freqs[value] = new HashSet<int> { num };
            }

            if (freqs.TryGetValue(value - 1, out var prevListNums))
            {
                prevListNums.Remove(num);
            }

            max = Math.Max(value, max);
        }

        var result = new List<int>();
        for (var i = 0; i < max; i++)
        {
            result.AddRange(freqs[max - i]);
            if (result.Count == k) break;
        }
        return result.ToArray();
    }

    public static int[] TopKFrequentPriorityQueue(int[] nums, int k)
    {
        var count = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (count.TryGetValue(num, out int value))
            {
                count[num] = ++value;
            }
            else
            {
                count[num] = 1;
            }
        }

        var heap = new PriorityQueue<int, int>();
        foreach (var entry in count)
        {
            heap.Enqueue(entry.Key, entry.Value);
            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        var rs = new int[k];
        for (var i = 0; i < k; i++)
        {
            rs[i] = heap.Dequeue();
        }

        return rs;
    }

    public static int[] TopKFrequentBucketSort(int[] nums, int k)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();

        // Frequency map
        List<int>[] freq = new List<int>[nums.Length + 1];
        for (int i = 0; i < freq.Length; i++)
        {
            freq[i] = new List<int>();
        }

        foreach (int n in nums)
        {
            if (count.ContainsKey(n))
            {
                count[n]++;
            }
            else
            {
                count[n] = 1;
            }
        }

        // Quite similar to bucket sort
        foreach (var entry in count)
        {
            freq[entry.Value].Add(entry.Key);
        }

        int[] res = new int[k];
        int index = 0;
        for (int i = freq.Length - 1; i > 0 && index < k; i--)
        {
            foreach (int n in freq[i])
            {
                res[index++] = n;
                if (index == k)
                {
                    return res;
                }
            }
        }
        return res;
    }
}