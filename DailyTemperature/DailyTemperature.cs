public static class DailyTemperature
{
    public static int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<int>();
        var result = new int[temperatures.Length];
        for (var i = 0; i < temperatures.Length; i++)
        {
            if (i == 0)
            {
                stack.Push(0);
                continue;
            }

            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                var current = stack.Pop();
                result[current] = i - current;
            }
            stack.Push(i);
        }
        return result;
    }
}