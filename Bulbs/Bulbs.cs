public static class BulbsProblem
{
    public static int Solve(List<int> inputData)
    {
        var map = new Dictionary<int, int>();
        var times = 0;
        for (int i = 0; i < inputData.Count; i++)
        {
            var numi = inputData[i];
            var foundNext = map.TryGetValue(numi + 1, out var n);
            var foundPrev = map.TryGetValue(numi - 1, out var p);

            var len = n + p + 1;
            if (len == i + 1)
            {
                if (numi - 1 - p == 0)
                {
                    times++;
                }
            }

            if (foundNext) map[numi + n] = len;
            if (foundPrev && numi - 1 > 0) map[numi - p] = len;
            map[numi] = len;
        }
        return times;
    }

    public static int Solve2(List<int> inputData)
    {
        var max = 1;
        var times = 0;
        for (int i = 0; i < inputData.Count; i++)
        {
            max = Math.Max(max, inputData[i]);
            if (max == i + 1)
            {
                times++;
            }
        }
        return times;
    }
}