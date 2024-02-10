using System.Runtime.CompilerServices;

namespace AAD;

public class LnkList<T> where T : notnull
{
    public static LnkList<T> From(params T[] values)
    {
        int n = values.Length;
        LnkList<T> listaLink = new LnkList<T>();
        //Array.Reverse(values);
        for (int i = 0; i < n; i++)
        {
            listaLink.Add(values[i]);
        }
        return listaLink;
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

    // O(1)
<<<<<<< HEAD
   
=======
    public void Prepend(T value)
    {
        if (_head == null)
        {
            _head = new LnkNode<T>(value);
            return;
        }

        _head = new LnkNode<T>(value, next: _head);
    }


    // O(1)

>>>>>>> ae13e8da7ea86944360845aea1026c7fe0406eb9
    public void Add(T element)
    {
        LnkNode<T> newNode = new LnkNode<T>(element);

        if (this._count == 0)
        {
            
            this._head = newNode;
            this._last = newNode;
            this._count++;
        }
<<<<<<< HEAD
        else
        {
            
            
            this._last.Next = newNode;
            this._last = newNode;
            this._count++;
        }
            
    
=======

        _count++;
>>>>>>> ae13e8da7ea86944360845aea1026c7fe0406eb9
    }


    // O(n)

    public void Insert(int index, T value)
    {
        int index_counter = 0;
        LnkNode<T> temp_Node = this._head;
        LnkNode<T> newNode = new LnkNode<T>(value);


        if (this._count == 0)
        {
            return;
        }


        if (index == 0) 
        {
            newNode.Next = this._head;
            this._head = newNode;
            this._count++;
            return;
        }
            while (temp_Node != null)
            {   
                if (index - 1  == index_counter)
                {
                    
                    newNode.Next = temp_Node.Next;
                    temp_Node.Next = newNode;
                    
                    
                    this._count++;
                    
                }
                else 
                {
                    temp_Node = temp_Node.Next;
                }

                index_counter++;
            }
        
        
    }

    public bool Remove(T value)
    {
        if (_head == null)
            return false;

        if (_head.ValueEquals(value))
        {
            _head = _head.Next;
            return true;
        }

        var currentNode = _head;
        while (currentNode != null)
        {
            if (currentNode.NextValueEquals(value))
            {
                var nextNode = currentNode.Next;
                currentNode.Next = nextNode!.Next;
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

    // O(1)
<<<<<<< HEAD
    public int Count()
    {

        return this._count;
    }
=======
    public int Count() =>
        _count;
>>>>>>> ae13e8da7ea86944360845aea1026c7fe0406eb9

    // O(n)
    public T[] ToArray()
    {
        T[] temp_Array = new T[this._count];
        LnkNode<T> temp_node = this._head;
        int array_Counter = 0;

        while (temp_node != null) 
        {
            temp_Array[array_Counter] = temp_node.Value;
            temp_node = temp_node.Next;
            array_Counter++;
        }
        return temp_Array;
    }
}