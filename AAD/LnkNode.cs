namespace AAD;

public class LnkNode<T> where T : notnull
{
    public T Value { get; }
    public LnkNode<T>? Next { get; set; }

    public LnkNode(T value, LnkNode<T>? next = null)
    {
        Value = value;
        Next = next;
    }

    public bool ValueEquals(T value) => 
        Value.Equals(value);

    public bool NextValueEquals(T value) => 
        Next != null && Next.ValueEquals(value);
}