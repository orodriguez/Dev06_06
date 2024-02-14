public class LnkList<T> where T : notnull
{
    protected Node<T> _head;
    protected Node<T> _last;
    protected int _count;

    protected void UpdateCountAndLast(Node<T> prev, Node<T> newNode, bool added)
    {
        if (added)
        {
            _count++;
            if (_last == null || prev == _last)
            {
                _last = newNode;
            }
        }
        else
        {
            _count--;
            if (_last == newNode)
            {
                if (prev != null)
                {
                    _last = prev;
                }
                else
                {
                    _last = null;
                }
            }
        }
    }
//DOUBLYLNKLIST
    public class DoublyLnkList<T> : LnkList<T> where T : notnull
{
    private Node<T> _first;

    public DoublyLnkList() : base()
    {
    }

    public static DoublyLnkList<T> From(params T[] values)
    {
        var list = new DoublyLnkList<T>();
        foreach (var value in values)
        {
            list.Add(value);
        }
        return list;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException();
            }

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }

    public void Prepend(T value)
    {
        var newNode = new Node<T> { Value = value };
        if (_head == null)
        {
            _head = _last = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
        UpdateCountAndLast(null, newNode, true);
    }

    public int Count()
    {
        return _count;
    }

    public void Add(T value)
    {
        var newNode = new Node<T> { Value = value };
        if (_head == null)
        {
            _head = _last = newNode;
        }
        else
        {
            _last.Next = newNode;
            newNode.Prev = _last;
            _last = newNode;
        }
        UpdateCountAndLast(_last, newNode, true);
    }

    public void Insert(int index, T value)
    {
        if (index < 0 || index > Count())
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            Prepend(value);
            return;
        }

        var newNode = new Node<T> { Value = value };
        var prev = _head;
        for (int i = 0; i < index - 1; i++)
        {
            prev = prev.Next;
        }
        newNode.Next = prev.Next;
        if (prev.Next != null)
        {
            prev.Next.Prev = newNode;
        }
        prev.Next = newNode;
        newNode.Prev = prev;
        UpdateCountAndLast(prev, newNode, true);
    }
    
    
    public bool Remove(T value)
    {
        var current = _head;
        Node<T> prev = null; 
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                if (prev == null)
                {
                    _head = current.Next;
                    if (_head != null)
                    {
                        _head.Prev = null;
                    }
                }
                else
                {
                    prev.Next = current.Next;
                    if (current.Next != null)
                    {
                        current.Next.Prev = prev;
                    }
                }
                UpdateCountAndLast(prev, current, false);
                return true;
            }
            prev = current;
            current = current.Next;
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count())
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            if (_head != null)
            {
                _head = _head.Next;
                if (_head != null)
                {
                    _head.Prev = null;
                }
                else
                {
                    _last = null;
                }
                UpdateCountAndLast(null, _head, false);
            }
            return;
        }

        var prev = _head;
        for (int i = 0; i < index - 1; i++)
        {
            prev = prev.Next;
        }

        var removedNode = prev.Next;
        prev.Next = removedNode.Next;

        if (removedNode.Next != null)
        {
            removedNode.Next.Prev = prev;
        }

        UpdateCountAndLast(prev, removedNode, false);
    }

    
}

}

public class Node<T> where T : notnull
{
    public T Value { get; internal set; }
    public Node<T> Prev { get; internal set; }
    public Node<T> Next { get; internal set; }
}