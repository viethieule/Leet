public static class ValidParentheses
{
    public static bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var map = new Dictionary<char, char>(3)
        {
            { '[', ']'},
            { '{', '}'},
            { '(', ')'},
        };
        var openBrackets = map.Select(x => x.Key).ToHashSet();

        foreach (var c in s)
        {
            if (openBrackets.Contains(c))
            {
                stack.Push(c);
            }
            else if (stack.Count > 0)
            {
                var value = stack.Pop();
                if (map[value] == c)
                {
                    continue;
                }
                return false;
            }
            else
            {
                return false;
            }

        }
        return stack.Count == 0;
    }
}