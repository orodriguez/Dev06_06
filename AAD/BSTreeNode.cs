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

    // Best: O(log n), Worst: O(n)
    public int Min() => 
        Left?.Min() ?? Value;
    
    // Best: O(log n), Worst: O(n)
    public int Max() => 
        Right?.Max() ?? Value;

    public BSTreeNode? Delete(int valueToDelete)
    {
        if (Value > valueToDelete && Left != null)
        {
            Left = Left.Delete(valueToDelete);
            return this;
        }

        if (Value < valueToDelete && Right != null)
        {
            Right = Right.Delete(valueToDelete);
            return this;
        }

        if (Value != valueToDelete)
            return this;
        
        // Value == value cases
        
        if (Left == null && Right == null)
            return null;
        
        if (Left == null)
            return Right;
        
        if (Right == null)
            return Left;

        var minRight = Right.Min();
        var newNode = new BSTreeNode(minRight)
        {
            Left = Left,
            Right = Right.Delete(minRight)
        };
        return newNode;
    }

    public int Count()
    {
        var count = 0;
        TraverseInOrder(_ => count++);
        return count;
    }

    public int[] ToArray()
    {
        var result = new List<int>();
        TraverseInOrder(node => result.Add(node.Value));
        return result.ToArray();
    }
}