public static class SearchRotatedArray
{
    public static int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var midValue = nums[mid];
            var rightValue = nums[right];
            if (midValue == target) return mid;
            if (rightValue == target) return right;

            if (midValue < rightValue)
            {
                if (midValue < target && target < rightValue)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            else
            {
                if (target > midValue || target < rightValue)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }
        return -1;
    }
}