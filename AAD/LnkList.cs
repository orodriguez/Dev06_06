namespace AAD;

public class LnkList<T> where T : notnull
{
    public static LnkList<T> From(params T[] values)
    {
        var ll = new LnkList<T>();
        foreach (var value in values)
            ll.Add(value);
        return ll;
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

    public T this[int index] => Get(index);

    public T Get(int index)
    {
        if (_head == null)
            throw new IndexOutOfRangeException();

        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException();

        var currentNode = _head;
        var currentIndex = 0;

        while (currentNode != null)
        {
            if (currentIndex == index)
                break;

            currentIndex++;
            currentNode = currentNode.Next;
        }

        return currentNode.Value;
    }

    // O(1)
    public void Prepend(T value)
    {
        if (_head == null)
        {
            _head = _last = new LnkNode<T>(value);
            _count++;

            return;
        }

        _head = new LnkNode<T>(value, next: _head);
        _count++;
    }


    // O(1)

    public void Add(T element)
    {
        var newNode = new LnkNode<T>(element);

        // O(1)
        if (_head == null)
            _head = _last = newNode;
        else // O(1)
        {
            _last.Next = newNode;
            _last = newNode;
        }

        _count++;
    }


    // O(n)

    public void Insert(int index, T value)
    {
        // O(1)
        if (_count == 0)
            return;

        // O(1)
        if (index == 0)
        {
            var newNode = new LnkNode<T>(value, _head);
            _head = newNode;
            _count++;
            return;
        }

        var currentIndex = 0;
        var current = _head;
        while (current != null)
        {
            if (currentIndex == index - 1)
            {
                var newNode = new LnkNode<T>(value, current.Next);
                newNode.Next = current.Next;
                current.Next = newNode;

                if (index == _count)
                {
                    _last = newNode;
                }

                _count++;

                return;
            }

            current = current.Next;
            currentIndex++;
        }
    }

    public bool Remove(T value)
    {
        if (_head == null)
            return false;

        if (_head.ValueEquals(value))
        {
            _head = _head.Next;
            _count--;
            return true;
        }

        var currentNode = _head;
        while (currentNode != null)
        {

            if (currentNode.NextValueEquals(value))
            {
                var nextNode = currentNode.Next;
                currentNode.Next = nextNode!.Next;
                _count--;

                if (nextNode == _last)
                {
                    _last = currentNode;
                }

                return true;
            }

            currentNode = currentNode.Next;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (_head == null)
            throw new IndexOutOfRangeException();

        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            _head = _last = _head.Next;
            _count--;
            return;
        }

        var currentIndex = 0;
        var currentNode = _head;

        while (currentNode != null)
        {
            if (currentIndex == index - 1)
            {
                currentNode.Next = currentNode.Next!.Next;

                if (index == _count - 1)
                {
                    _last = currentNode;
                }

                _count--;
                return;
            }

            currentIndex++;
            currentNode = currentNode.Next;
        }

    }

    // O(1)
    public int Count() =>
        _count;

    // O(n)
    public T[] ToArray()
    {
        if (_head == null)
            return Array.Empty<T>();

        var result = new List<T>();

        var current = _head;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return result.ToArray();
    }

    public T Last()
    {
        if (_last == null)
            throw new InvalidOperationException();

        return _last.Value;
    }
}