using System.Formats.Asn1;
using System.Runtime.InteropServices.Marshalling;

namespace AAD;

public class LnkList<T>
{

    public static LnkList<T> From(params T[] values)
    {
        var item = new LnkList<T>();
        foreach (var value in values)
            item.Add(value);
        return item;
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
        var newitem = new LnkNode<T>(element);

        if (_head == null)
            _head = _last = newitem;
        else
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _last.Next = newitem;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _last = newitem;
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
            var newitem = new LnkNode<T>(value, _head);
            _head = newitem;
            return;
        }

        var actual_index = 0;
        var position = _head;
        while (position != null)
        {
            if (actual_index == index - 1)
            {
                var newitem = new LnkNode<T>(value, position.Next);
                newitem.Next = position.Next;
                position.Next = newitem;
                return;
            }
            position = position.Next;
            actual_index++;
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

        var answers = new List<T>();

        var position = _head;
        while (position != null)
        {
            answers.Add(position.Value);
            position = position.Next;
        }

        return answers.ToArray();
    }
}