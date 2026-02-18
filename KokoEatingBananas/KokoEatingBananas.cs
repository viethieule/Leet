public static class KokoEatingBananas
{
    public static int MinEatingSpeed(int[] piles, int h)
    {
        var left = 1;
        var right = piles.Max();
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            double times = 0;
            foreach (var pile in piles)
            {
                times += Math.Ceiling((double)pile / mid);
            }
            if (times <= h)
            {
                right = mid - 1;
            }
            else if (times > h)
            {
                left = mid + 1;
            }
        }
        return left;
    }
}