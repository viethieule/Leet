public static class FindMinimumInRotatedSort
{
    public static int FindMin(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var midValue = nums[mid];
            var rightValue = nums[right];
            if (midValue < rightValue)
            {
                right = mid;
            }
            else if (midValue > rightValue)
            {
                left = mid + 1;
            }
        }
        return nums[left];
    }
}