using System;
using System.Collections.Generic;

namespace AAD
{
    public class DoublyLnkList<T> where T : notnull
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }
            public Node? Previous { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }

        private Node? _head;
        private Node? _tail;
        private int _count;

        public static DoublyLnkList<T> From(params T[] values)
        {
            var ll = new DoublyLnkList<T>();
            foreach (var value in values)
                ll.Add(value);
            return ll;
        }

        public T this[int index]
        {
            get
            {
                if (_head == null || index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();

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
            var newNode = new Node(value);
            newNode.Next = _head;
            if (_head != null)
                _head.Previous = newNode;
            _head = newNode;
            if (_tail == null)
                _tail = newNode;
            _count++;
        }

        public int Count() => _count;

        public void Add(T value)
        {
            var newNode = new Node(value);
            if (_head == null)
                _head = newNode;
            else
            {
                _tail!.Next = newNode;
                newNode.Previous = _tail;
            }
            _tail = newNode;
            _count++;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > _count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                Prepend(value);
                return;
            }
            else if (index == _count)
            {
                Add(value);
                return;
            }

            var newNode = new Node(value);
            var current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current!.Next;
            }

            newNode.Next = current!.Next;
            current.Next!.Previous = newNode;
            current.Next = newNode;
            newNode.Previous = current;
            _count++;
        }

        public bool Remove(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        _head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        _tail = current.Previous;

                    _count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            if (current!.Previous != null)
                current.Previous.Next = current.Next;
            else
                _head = current.Next;

            if (current.Next != null)
                current.Next.Previous = current.Previous;
            else
                _tail = current.Previous;

            _count--;
        }

        public T Last()
        {
            if (_tail == null)
                throw new InvalidOperationException("The list is empty");

            return _tail.Value;
        }

        public T[] ToArray()
        {
            var result = new T[_count];
            var current = _head;
            for (int i = 0; i < _count; i++)
            {
                result[i] = current!.Value;
                current = current.Next;
            }
            return result;
        }

        public T[] ToReversedArray()
        {
            var result = new T[_count];
            var current = _tail;
            for (int i = 0; i < _count; i++)
            {
                result[i] = current!.Value;
                current = current.Previous;
            }
            return result;
        }
    }
}
