
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

    internal bool ValueEquals<T>(T value) where T : notnull
    {
        throw new NotImplementedException();
    }

    internal bool NextValueEquals<T>(T value) where T : notnull
    {
        throw new NotImplementedException();
    }
}