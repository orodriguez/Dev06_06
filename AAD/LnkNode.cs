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



public class DoublyLnkNode<T> where T : notnull
{
    public T Value { get; }
    public DoublyLnkNode<T>? Next { get; set; }
    public DoublyLnkNode<T>? Prev { get; set; }


    public DoublyLnkNode(T value, DoublyLnkNode<T>? next = null, DoublyLnkNode<T>? prev = null)
    {
        Value = value;
        Next = next;
        Prev = prev;
    }

    public bool ValueEquals(T value) => 
        Value.Equals(value);

    public bool NextValueEquals(T value) => 
        Next != null && Next.ValueEquals(value);

    public bool PreValueEquals(T value) => 
        Prev != null && Prev.ValueEquals(value);
}
