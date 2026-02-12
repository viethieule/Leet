public static class Search2DMatrix
{
    public static bool Search(int[][] matrix, int target)
    {
        var left = 0;
        var right = matrix.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var midValue = matrix[mid][0];
            if (midValue < target)
            {
                left = mid + 1;
            }
            else if (midValue > target)
            {
                right = mid - 1;
            }
            else if (midValue == target)
            {
                return true;
            }
        }

        if (right < 0)
        {
            return false;
        }
        
        var i = right;
        left = 0;
        right = matrix[i].Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var midValue = matrix[i][mid];
            if (midValue < target)
            {
                left = mid + 1;
            }
            else if (midValue > target)
            {
                right = mid - 1;
            }
            else if (midValue == target)
            {
                return true;
            }
        }

        return false;
    }
}