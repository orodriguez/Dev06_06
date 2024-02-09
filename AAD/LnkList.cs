namespace AAD
{
    public class LnkList<T>
    {
        private class LnkNode<T>
        {
            public T Value { get; set; }
            public LnkNode<T>? Next { get; set; }

            public LnkNode(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private LnkNode<T>? _head;
        private LnkNode<T>? _last;
        private int _count;

        public static LnkList<T> From(params T[] values)
        {
            LnkList<T> list = new LnkList<T>();
            foreach (var value in values)
            {
                list.Add(value);
            }
            return list;
        }

        public LnkList()
        {
            _head = null;
            _last = null;
            _count = 0;
        }

        // O(1)
        public void Add(T element)
        {
            LnkNode<T> newNode = new LnkNode<T>(element);

            if (_head == null)
            {
                _head = newNode;
                _last = newNode;
            }
            else
            {
                _last!.Next = newNode;
                _last = newNode;
            }

            _count++;
        }

        // O(n)
        public void Insert(int index, T value)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            LnkNode<T> newNode = new LnkNode<T>(value);

            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;

                if (_last == null)
                {
                    _last = newNode;
                }
            }
            else
            {
                LnkNode<T>? current = _head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }

                newNode.Next = current!.Next;
                current.Next = newNode;

                if (index == _count)
                {
                    _last = newNode;
                }
            }

            _count++;
        }

        // O(1)
        public int Count()
        {
            return _count;
        }

        // O(n)
        public T[] ToArray()
        {
            T[] array = new T[_count];
            LnkNode<T>? current = _head;

            for (int i = 0; i < _count; i++)
            {
                array[i] = current!.Value;
                current = current!.Next;
            }

            return array;
        }
    }
}
