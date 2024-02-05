namespace AAD;

public class LnkNode<T>
{
    public T Value { get; }
    public LnkNode<T>? Next { get; set; }

    public LnkNode(T value) : this(value, null) => 
        Value = value;

    public LnkNode(T value, LnkNode<T>? next)
    {
        Value = value;
        Next = next;
    }
}