public static class TrappingRainWaterProblem
{
    public static int Trap(int[] height)
    {
        int l = 0, r = height.Length - 1;
        int maxLeft = height[l], maxRight = height[r];
        int res = 0;
        while (l < r)
        {
            if (maxLeft < maxRight)
            {
                l++;
                maxLeft = Math.Max(maxLeft, height[l]);
                res += maxLeft - height[l];
            }
            else
            {
                r--;
                maxRight = Math.Max(maxRight, height[r]);
                res += maxRight - height[r];
            }
        }
        return res;
    }
}