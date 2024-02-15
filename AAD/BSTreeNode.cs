namespace AAD;

public class IbsTree : IBSTree
{
    public int Value { get; set; }
    public IbsTree? Left { get; set; }
    public IbsTree? Right { get; set; }
    public int? LeftValue => Left?.Value;
    public int? RightValue => Right?.Value;

    public IbsTree(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    public void Add(int newValue)
    {
        if (Value == newValue)
            return;

        if (Left != null && Value > newValue)
        {
            Left.Add(newValue);
            return;
        }

        if (Value > newValue)
        {
            Left = new IbsTree(newValue);
            return;
        }

        if (Right != null)
        {
            Right.Add(newValue);
            return;
        }

        Right = new IbsTree(newValue);
    }

    public static IbsTree From(int[] values)
    {
        var root = new IbsTree(values.First());

        foreach (var value in values.Skip(1))
            root.Add(value);

        return root;
    }

    public int Count()
    {
        var result = 0;
        TraverseInOrder(_ => result++);
        return result;
    }

    // O(log n)
    public bool Contains(int searchedValue)
    {
        if (Value == searchedValue)
            return true;

        if (Value > searchedValue && Left == null)
            return false;

        if (Value > searchedValue && Left != null)
            return Left.Contains(searchedValue);

        return Right != null && Right.Contains(searchedValue);
    }

    // O(n)

    public void TraverseInOrder(Action<IbsTree> action)
    {
        Left?.TraverseInOrder(action);
        action(this);
        Right?.TraverseInOrder(action);
    }

    public void TraversePreOrder(Action<IbsTree> action)
    {
        action(this);
        Left?.TraversePreOrder(action);
        Right?.TraversePreOrder(action);
    }

    public void TraversePostOrder(Action<IbsTree> action)
    {
        Left?.TraversePostOrder(action);
        Right?.TraversePostOrder(action);
        action(this);
    }
}