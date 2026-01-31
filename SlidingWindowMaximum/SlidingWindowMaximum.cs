public static class SlidingWindowMaximum
{
    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        var window = new LinkedList<int>();
        var result = new int[nums.Length - k + 1];
        int left = 0, right = 0;
        while (right < nums.Length)
        {
            var r = nums[right];
            while (window.Count > 0 && window.Last != null && nums[window.Last.Value] < r)
            {
                window.RemoveLast();
            }
            window.AddLast(right);
            right++;

            while (right - left >= k)
            {
                result[left] = nums[window.First.Value];
                if (left > window.First.Value)
                {
                    window.RemoveFirst();
                }
                left++;
            }
        }
        return result;
    }
}