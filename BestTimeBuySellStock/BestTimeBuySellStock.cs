public static class BestTimeBuySellStockProblem
{
    public static int MaxProfit(int[] prices)
    {
        var maxProfit = 0;
        var minBuy = prices[0];

        foreach (var price in prices)
        {
            maxProfit = Math.Max(maxProfit, price - minBuy);
            minBuy = Math.Min(price, minBuy);
        }

        return maxProfit;
    }

    public static int MaxProfitSlidingWindow(int[] prices)
    {
        int i = 0, j = 1;
        int max = 0;
        while (j < prices.Length)
        {
            var profit = prices[j] - prices[i];
            if (profit < 0)
            {
                i = j;
            }

            max = Math.Max(max, profit);
            j++;
        }
        return max;
    }
}