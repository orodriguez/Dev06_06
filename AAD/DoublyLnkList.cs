using System;
using System.Collections.Generic;

public class DoublyLnkList<T> where T : notnull
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
    private Node? tail;
    private int count;

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
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }
            return current!.Value;
        }
    }

    public void Prepend(T value)
    {
        var newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        count++;
    }

    public int Count()
    {
        return count;
    }

    public void Add(T value)
    {
        var newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail!.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        count++;
    }

    public void Insert(int index, T value)
    {
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException(nameof(index));

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
            current = current!.Next;
        }
        newNode.Next = current!.Next;
        newNode.Previous = current;
        current.Next!.Previous = newNode;
        current.Next = newNode;

        count++;
    }

    public bool Remove(T value)
    {
        var current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                RemoveNode(current);
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    private void RemoveNode(Node node)
    {
        if (node == head)
        {
            head = head!.Next;
            if (head != null)
                head.Previous = null;
            else
                tail = null;
        }
        else if (node == tail)
        {
            tail = tail!.Previous;
            if (tail != null)
                tail.Next = null;
            else
                head = null;
        }
        else
        {
            node.Previous!.Next = node.Next;
            node.Next!.Previous = node.Previous;
        }
        count--;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));

        var current = head;
        for (int i = 0; i < index; i++)
        {
            current = current!.Next;
        }
        RemoveNode(current!);
    }

    public T Last()
    {
        if (tail == null)
            throw new InvalidOperationException("List is empty");
        return tail.Value;
    }

    public T[] ToArray()
    {
        var array = new T[count];
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
        var array = new T[count];
        var current = tail;
        int index = 0;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Previous;
        }
        return array;
    }
}
