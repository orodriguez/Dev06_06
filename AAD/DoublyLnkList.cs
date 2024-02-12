using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DoublyLnkList<T> : IEnumerable<T> where T : notnull
{
    private class Node
    {
        public T Value { get; }
        public Node? Previous { get; set; }
        public Node? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node? head;
    private Node? last;
    private int count;

    public int Count => count;

    public void Prepend(T value)
    {
        var newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            last = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }

        count++;
    }

    public void Add(T value)
    {
        var newNode = new Node(value);

        if (last == null)
        {
            head = newNode;
            last = newNode;
        }
        else
        {
            last.Next = newNode;
            newNode.Previous = last;
            last = newNode;
        }

        count++;
    }

    public void Insert(int index, T value)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            Prepend(value);
            return;
        }

        if (index == count)
        {
            Add(value);
            return;
        }

        var newNode = new Node(value);
        var current = head;
        for (int i = 0; i < index - 1; i++)
        {
            current = current?.Next;
        }

        newNode.Next = current?.Next;
        newNode.Previous = current;
        current!.Next!.Previous = newNode;
        current.Next = newNode;

        count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current?.Next;
            }

            return current!.Value;
        }
    }

    public bool Remove(T value)
    {
        var current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                if (current.Previous == null)
                {
                    head = current.Next;
                    if (head != null)
                        head.Previous = null;
                }
                else
                {
                    current.Previous.Next = current.Next;
                }

                if (current.Next == null)
                {
                    last = current.Previous;
                    if (last != null)
                        last.Next = null;
                }
                else
                {
                    current.Next.Previous = current.Previous;
                }

                count--;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        var current = head;
        for (int i = 0; i < index; i++)
        {
            current = current?.Next;
        }

        if (current == null)
            return;

        if (current.Previous == null)
        {
            head = current.Next;
            if (head != null)
                head.Previous = null;
        }
        else
        {
            current.Previous.Next = current.Next;
        }

        if (current.Next == null)
        {
            last = current.Previous;
            if (last != null)
                last.Next = null;
        }
        else
        {
            current.Next.Previous = current.Previous;
        }

        count--;
    }

    public T Last()
    {
        if (last == null)
            throw new InvalidOperationException();

        return last.Value;
    }

    public T[] ToArray()
    {
        T[] array = new T[count];
        var current = head;
        int index = 0;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }
        return array;
    }

    public T[] ToReversedArray()
    {
        T[] array = new T[count];
        var current = last;
        int index = 0;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Previous;
        }
        return array;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
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
}