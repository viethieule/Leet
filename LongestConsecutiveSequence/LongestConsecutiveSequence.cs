public static class LongestConsecutiveSequenceProblem
{
    public static int LongestConsecutive(int[] nums)
    {
        var map = new Dictionary<int, int>(nums.Length);
        var max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var found = map.ContainsKey(num);
            map.TryGetValue(num + 1, out var n);
            map.TryGetValue(num - 1, out var p);

            if (!found)
            {
                var len = n + p + 1;
                map[num + n] = len;
                map[num - p] = len;
                map[num] = len;

                max = Math.Max(max, len);
            }
        }
        return max;
    }
}