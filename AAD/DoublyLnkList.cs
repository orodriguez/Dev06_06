namespace AAD;

public class DoublyLnkList<T> where T : notnull
{
    public static DoublyLnkList<T> From(params T[] values)
    {
        throw new NotImplementedException();
    }

    public T this[int index] => throw new NotImplementedException();

    public void Prepend(T value)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        throw new NotImplementedException();
    }

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