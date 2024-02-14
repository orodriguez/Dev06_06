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
}