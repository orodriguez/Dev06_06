namespace AAD;

public class DoublyLnkList<T> where T : notnull
{
    public static DoublyLnkList<T> From(params T[] values)
    {
        var ll = new DoublyLnkList<T>();
        foreach (var value in values)
            ll.Add(value);
        return ll;
    }

    private DoublyLnkNode<T>? _head;

    private DoublyLnkNode<T>? _last;

    private int _count = 0;


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
        if (_head == null)
            _last = _head = new DoublyLnkNode<T>(value);
        else
        {
            var newNode = new DoublyLnkNode<T>(value);
            newNode.Next = _head;
            _head = newNode;
        }
            
        _count++;
        return;
    }

    public int Count() => _count;

    public void Add(T value)
    {
        var newNode = new DoublyLnkNode<T>(value);

        // O(1)
        if (_head == null)
            _head =_last = newNode;
        else // O(1)
        {
            _last.Next = newNode;
            newNode.Prev = _last;
            _last = newNode;
        }

        _count++;
        return;
    }

    public void Insert(int index, T value)
    {
        // O(1)
        if (_count == 0 || index < 0 || index >= _count)
            return;

        // O(1)
        if (index == 0)
        {
            var newNode = new DoublyLnkNode<T>(value);
            _head.Prev = newNode;
            newNode.Next = _head;
            _head = newNode;
        }

        var currentIndex = 1;
        var current = _head.Next;
        while (current != null)
        {
            if (currentIndex == index)
            {
                var newNode = new DoublyLnkNode<T>(value);
                var previousNode = current.Prev;
                previousNode.Next = newNode;
                newNode.Next = current;
                current.Prev = newNode;
                newNode.Prev = previousNode;
                break;
            }

            current = current.Next;
            currentIndex++;
        }    
        
        _count++;
        return;
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
            _head = _head.Next;
            return;
        }
        
        var currentIndex = 0;
        var currentNode = _head;
        
        while (currentNode != null)
        {
            if (currentIndex == index - 1)
            {
                currentNode.Next = currentNode.Next!.Next;
                return;
            }
            
            currentIndex++;
            currentNode = currentNode.Next;
        }
    }

    public T Last()
    {
        if(_last == null)
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
        if (_last == null)
            return Array.Empty<T>();

        var result = new List<T>();

        var current = _last;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Prev;
        }

        return result.ToArray();
    }
}
