namespace AAD;

public class LnkNode<T>
{
    public T Value { get; }
    public LnkNode<T>? Next { get; set; }

    public LnkNode(T value, LnkNode<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}