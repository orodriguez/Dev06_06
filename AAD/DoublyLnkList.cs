namespace AAD;

public class DoublyLnkList<T> where T : notnull
{
    private DLnkNode<T>? _head;
    private DLnkNode<T>? _last;
    private int _count;
    public DoublyLnkList() :this(head:null, last:null)
    {
    }
    public DoublyLnkList(DLnkNode<T>? head, DLnkNode<T>? last)
    {
        _head = head;
        _last = last;
        _count = 0;
    }
    public static DoublyLnkList<T> From(params T[] values)
    {
        var ll = new DoublyLnkList<T>();
        foreach (var value in values)
            ll.Add(value);
        return ll;
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
    public void Prepend(T value)
    {
        _head = new DLnkNode<T>(value, _head);

        if (_head.IsLast)
            _last = _head;

        _count++;
    }

    public int Count() =>
        _count;

    public void Add(T element)
    {
        var newNode = new DLnkNode<T>(element);

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

    public void Insert(int index, T value)
    {
     if (_count == 0)
            return;

        // O(1)
        if (index == 0)
        {
            var newNode = new DLnkNode<T>(value, _head);
            _last = _head;
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
                var newNode = new DLnkNode<T>(value, current.Next);
                newNode.Next = current.Next;
                current.Next = newNode;
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
            var nextNode = currentNode.Next;

            if (nextNode != null && nextNode.ValueEquals(value))
            {
                currentNode.Link(nextNode.Next);
                nextNode.Prev = currentNode;
                if (currentNode.IsLast)
                    _last = currentNode;
                _count -= 1;
                return true;
            }

            currentNode = currentNode.Next;
        }

        return false;
    }

    public bool RemoveAt(int index)
    {
                if (_head == null)
            throw new IndexOutOfRangeException();

        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException();

        if (_head.Next == null)
        {
            _head = _last = null;
            _count--;
            return true;
        }

        var nodeBefore = GetNode(index - 1);
        var nodeToRemove = nodeBefore.Next;
        
        if (nodeToRemove.IsLast)
            _last = nodeBefore;
        
        nodeBefore.Link(nodeToRemove.Next);
        _count--;
        return true;
    }

    private DLnkNode<T>? GetNode(int index)
    {
        var currentIndex = 0;
        var currentNode = _head;
        while (currentNode != null)
        {
            if (currentIndex == index)
                return currentNode;
            
            currentIndex++;
            currentNode = currentNode.Next;
        }

        return null;
    }

    public T Last()
    {
        if (_last == null)
            throw new InvalidOperationException();
        
        return _last.Value;
    }

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

    public T[] ToReversedArray()
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

        result.Reverse();

        return result.ToArray();
    }
}