namespace AAD;

public class DoublyLnkList<T> where T : notnull
{
    public static DoublyLnkList<T> From(params T[] values)
    {
        var ll = new LnkList<T>();
        foreach (var value in values)
            ll.Add(value);
        return ll;
    }

    private DoubleLnkNode<T>? _head;

    private DoubleLnkNode<T>? _last;

    private int _count;



    public T this[int index] => throw new NotImplementedException();

    public void Prepend(T value)
    {
        if (_head == null)
            _last = _head = new DoubleLnkNode<T>(value);
        else
            _head = new DubleLnkNode<T>(value, next: _head);
            
        _count++;
        return;
    }

    public int Count() => _count;

    public void Add(T value)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T value)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T value)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T Last()
    {
        throw new NotImplementedException();
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }

    public T[] ToReversedArray()
    {
        throw new NotImplementedException();
    }
}
