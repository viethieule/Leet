public static class EvaluateReversePolishNotation
{
    public static int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        foreach (var s in tokens)
        {
            if (int.TryParse(s, out int n))
            {
                stack.Push(n);
                continue;
            }

            var n1 = stack.Pop();
            var n2 = stack.Pop();

            var r = s switch
            {
                "+" => n2 + n1,
                "-" => n2 - n1,
                "*" => n2 * n1,
                "/" => n2 / n1,
                _ => throw new NotImplementedException(),
            };

            stack.Push(r);
        }
        return stack.Pop();
    }

    public static int EvalRPNRecursive(string[] tokens) {
        List<string> tokenList = new List<string>(tokens);
        return DFS(tokenList);
    }

    public static int DFS(List<string> tokens) {
        string token = tokens[tokens.Count - 1];
        tokens.RemoveAt(tokens.Count - 1);

        if (token != "+" && token != "-" &&
         token != "*" && token != "/") {
            return int.Parse(token);
        }

        int right = DFS(tokens);
        int left = DFS(tokens);

        if (token == "+") {
            return left + right;
        } else if (token == "-") {
            return left - right;
        } else if (token == "*") {
            return left * right;
        } else {
            return left / right;
        }
    }
}