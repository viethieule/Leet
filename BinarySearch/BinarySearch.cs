public static class BinarySearch
{
    public static int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            // When computing mid, you must avoid overflow. 
            // In the code, left + (right - left) / 2 is the same as (left + right) / 2 in result, but it prevents overflow when left and right are very large.
            var mid = left + (right - left) / 2;
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else if (nums[mid] == target)
            {
                return mid;
            }
        }
        return -1;
    }

    public static int SearchLeftBoundary(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else if (nums[mid] == target)
            {
                right = mid - 1;
            }
        }
        if (left < 0 || left >= nums.Length)
        {
            return -1;
        }
        if (nums[left] != target)
        {
            return -1;
        }
        return left;
    }

    public static int SearchRightBoundary(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else if (nums[mid] == target)
            {
                left = mid + 1;
            }
        }
        if (right < 0 || right >= nums.Length)
        {
            return -1;
        }
        if (nums[right] != target)
        {
            return -1;
        }
        return right;
    }
}