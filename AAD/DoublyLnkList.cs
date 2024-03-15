namespace AAD
{
    public class DoublyLnkListNode<T>
    {
        public DoublyLnkListNode<T>? Next { get; set; }
        public DoublyLnkListNode<T>? Prev { get; set; }
        public T Dato { get; }

        public DoublyLnkListNode(T dato, DoublyLnkListNode<T>? next = null)
        {
            Dato = dato;
            Next = next;
            Prev = null;
        }
    }

    public class DoublyLnkList<T> where T : notnull
    {
        private DoublyLnkListNode<T>? _head;
        private DoublyLnkListNode<T>? _last;
        private int _count;

        public DoublyLnkList()
        {
            _head = null;
            _last = null;
            _count = 0;
        }

        public static DoublyLnkList<T> From(params T[] values)
        {
            var ll = new DoublyLnkList<T>();

            foreach (var dato in values)
            {
                ll.Add(dato);
            }
            return ll;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }

                var current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current?.Next;
                }

                return current.Dato;
            }
        }

        public void Prepend(T value)
        {
            var newNode = new DoublyLnkListNode<T>(value);
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

            _count++;
        }

        public int Count() => _count;

        public void Add(T value)
        {
            var newNode = new DoublyLnkListNode<T>(value);

            if (_head == null)
            {
                _head = newNode;
                _last = newNode;
            }
            else
            {

                _last!.Next = newNode;
                newNode.Prev = _last;
                _last = newNode;

            }

            _count++;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > _count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Prepend(value);
            }
            else if (index == _count)
            {
                Add(value);
            }
            else
            {
                var current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current?.Next;
                }

                if (current != null)
                {
                    var nextNode = current.Next;
                    var newNode = new DoublyLnkListNode<T>(value);
                    newNode.Next = nextNode;
                    newNode.Prev = current;

                    if (nextNode != null)
                    {
                        nextNode.Prev = newNode;
                    }

                    current.Next = newNode;

                    _count++;
                }
            }
        }




        public bool Remove(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Dato, value))
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        _head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        _last = current.Prev;
                    }

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
            {
                throw new IndexOutOfRangeException();
            }

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current?.Next;
            }

            if (current?.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
            else
            {
                _head = current?.Next;
            }

            if (current?.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
            else
            {
                _last = current?.Prev;
            }

            _count--;
        }

        public T Last()
        {
            if (_last == null)
            {
                throw new InvalidOperationException();
            }

            return _last.Dato;
        }

        public T[] ToArray()
        {
            var array = new T[_count];
            var current = _head;
            for (int i = 0; i < _count; i++)
            {
                if (current != null)
                {
                    array[i] = current.Dato;
                    current = current.Next;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            return array;
        }

        public T[] ToReversedArray()
        {
            var array = new T[_count];
            var current = _last;
            for (int i = 0; i < _count; i++)
            {
                if (current != null)
                {
                    array[i] = current.Dato;
                    current = current.Prev;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            return array;
        }
    }
}