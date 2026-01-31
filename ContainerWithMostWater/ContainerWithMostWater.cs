public static class ContainerWithMostWaterProblem
{
    public static int MaxArea(int[] heights)
    {
        int l = 0, r = heights.Length - 1;
        int max = 0;
        while (l < r)
        {
            var len = r - l;
            var min = Math.Min(heights[l], heights[r]);
            max = Math.Max(min * len, max);

            if (heights[l] <= heights[r])
            {
                l++;
            }
            else
            {
                r--;
            }
        }

        return max;
    }
}