namespace AAD;

public class LnkList<T>
{
    private LnkNode<T>? _head;
    private LnkNode<T>? _last;
    private int _count;

    public static LnkList<T> From(params T[] values)
    {
        LnkList<T> linkedList = new();
        foreach (var value in values)
            linkedList.Add(value);
        return linkedList;
    }


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
        LnkNode<T> newNode = new(element);

        if (_head == null)
        {
            _head = _last = newNode;
        }
        else
        {
            _last.Next = newNode;
            _last = newNode;
        }

        _count++;
    }

    // O(n)
    public void Insert(int index, T value)
    {
        if (_count == 0)
            return;

        if (index == 0)
        {
            var newNode = new LnkNode<T>(value, _head);
            _head = newNode;
            return;
        }

        var currentIndex = 0;
        var current = _head;
        while (current != null)
        {
            if (currentIndex == index - 1)
            {
                var newNode = new LnkNode<T>(value, current.Next)
                {
                    Next = current.Next
                };
                current.Next = newNode;
                return;
            }

            current = current.Next;
            currentIndex++;
        }
    }

    // O(1)
    public int Count() => _count;

    // O(n)
    public T[] ToArray()
    {
        if (_head == null)
            return [];

        var result = new List<T>();

        var current = _head;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return [.. result];
    }
}