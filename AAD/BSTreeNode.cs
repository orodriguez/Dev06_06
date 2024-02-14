namespace AAD;

public class BSTreeNode
{
    public int Value { get; set; }
    public BSTreeNode? Left { get; set; }
    public BSTreeNode? Right { get; set; }
    public int? LeftValue => Left?.Value;
    public int? RightValue => Right?.Value;

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
}