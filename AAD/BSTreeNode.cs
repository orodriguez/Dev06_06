namespace AAD;

public class BSTreeNode
{
    public int Value { get; set; }
    public BSTreeNode? Left { get; set; }
    public BSTreeNode? Right { get; set; }
    public int? LeftValue => Left?.Value;
    public int? RightValue => Right?.Value;
    public bool IsLeaf => Left == null && Right == null;

    public BSTreeNode(int value)
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
            Left = new BSTreeNode(newValue);
            return;
        }

        if (Right != null)
        {
            Right.Add(newValue);
            return;
        }

        Right = new BSTreeNode(newValue);
    }

    public static BSTreeNode From(int[] values)
    {
        var root = new BSTreeNode(values.First());

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

    public (bool deleted, BSTreeNode? newNode) Delete(int valueToDelete)
    {
        if (Value > valueToDelete && Left == null)
            return (false, this);
        
        if (Value > valueToDelete && Left != null)
        {
            var (deleted, newNode) = Left.Delete(valueToDelete);
            Left = newNode;
            return (deleted, this);
        }

        if (Value < valueToDelete && Right == null)
            return (false, this);

        if (Value < valueToDelete && Right != null)
        {
            var (deleted, newNode) = Right.Delete(valueToDelete);
            Right = newNode;
            return (deleted, this);
        }

        if (Left == null && Right == null)
            return (true, null);

        if (Right == null)
            return (true, Left);

        if (Left == null)
            return (true, Right);

        throw new NotImplementedException();
    }

    // O(n)
    public void TraverseInOrder(Action<BSTreeNode> action)
    {
        Left?.TraverseInOrder(action);
        action(this);
        Right?.TraverseInOrder(action);
    }

    public void TraversePreOrder(Action<BSTreeNode> action)
    {
        action(this);
        Left?.TraversePreOrder(action);
        Right?.TraversePreOrder(action);
    }

    public void TraversePostOrder(Action<BSTreeNode> action)
    {
        Left?.TraversePostOrder(action);
        Right?.TraversePostOrder(action);
        action(this);
    }

    public int Min() => 
        Left == null ? Value : Math.Min(Value, Left.Min());
}