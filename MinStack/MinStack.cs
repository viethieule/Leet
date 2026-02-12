namespace ConsoleApp.MinStack;

public class MinStack
{
    private readonly Stack<int> _stack;
    private readonly Stack<int> _minStack;
    public MinStack()
    {
        _stack = new Stack<int>();
        _minStack = new Stack<int>();
    }

    public void Push(int val)
    {
        _stack.Push(val);
        var minValue = _minStack.Count == 0 ? val : Math.Min(val, _minStack.Peek());
        _minStack.Push(minValue);
    }

    public void Pop()
    {
        _stack.Pop();
        _minStack.Pop();
    }

    public int Top()
    {
        return _stack.Peek();
    }

    public int GetMin()
    {
        return _minStack.Peek();
    }
}
