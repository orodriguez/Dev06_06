using System;
using System.Collections.Generic;

namespace AAD
{
    public class LnkList<T> where T : notnull
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? _head;
        private int _count;

        public static LnkList<T> From(params T[] values)
        {
            var ll = new LnkList<T>();
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
            _head = newNode;
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
                var current = _head;
                while (current!.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
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

            var newNode = new Node(value);
            var current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current!.Next;
            }

            newNode.Next = current!.Next;
            current.Next = newNode;
            _count++;
        }

        public bool Remove(T value)
        {
            if (_head == null)
                return false;

            if (EqualityComparer<T>.Default.Equals(_head.Value, value))
            {
                _head = _head.Next;
                _count--;
                return true;
            }

            var current = _head;
            while (current!.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Next.Value, value))
                {
                    current.Next = current.Next.Next;
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

            if (index == 0)
            {
                _head = _head!.Next;
            }
            else
            {
                var current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }
                current!.Next = current.Next!.Next;
            }
            _count--;
        }

        public T Last()
        {
            if (_head == null)
                throw new InvalidOperationException("The list is empty");

            var current = _head;
            while (current!.Next != null)
            {
                current = current.Next;
            }
            return current.Value;
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
    }
}
