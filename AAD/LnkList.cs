namespace AAD;

public class LnkList<T> {
    
    public static LnkList<T> From(params T[] values)
    {
        throw new NotImplementedException();
    }

    private LnkNode<T>? _head;

    private LnkNode<T>? _last;

    private int _count;

    public LnkList() : this(head: null, last: null)
    {
    }

    private LnkList(LnkNode<T>? head, LnkNode<T>? last)
    {
        _head = head;
        _last = last;
        _count = 0;
    }

    // O(1)
    public void Add(T element)
    {
        throw new NotImplementedException();
    }

    // O(n)
    public void Insert(int index, T value)
    {
        throw new NotImplementedException();
    }

    // O(1)
    public int Count()
    {
        throw new NotImplementedException();
    }

    // O(n)
    public T[] ToArray()
    {
        throw new NotImplementedException();
    }
}