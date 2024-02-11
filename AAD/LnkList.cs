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
    public void Prepend(T value)
    {
        LnkNode<T> newNode = new LnkNode<T>(value);
        if (this._head == null)
        {
            this._head = newNode;
            this._last = newNode;
            this._head.Next = this._last;
           
            this._count++;
            return;
        }

        this._head = new LnkNode<T>(value, next: _head);
        this._count++;
    }


    // O(1)

    public void Add(T element)
    {
        LnkNode<T> newNode = new LnkNode<T>(element);

        if (this._count == 0)
        {
            
            this._head = newNode;
            this._last = newNode;
            this._count++;
        }
        else
        {
            
            
            this._last.Next = newNode;
            this._last = newNode;
            this._count++;
        }
            
    
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
            this._count--;  // add this line to reduce the head, when element is actually the head
            return true;
        }

        var currentNode = _head;
        while (currentNode != null)
        {
            if (currentNode.NextValueEquals(value))
            {
                var nextNode = currentNode.Next;
                currentNode.Next = nextNode!.Next;
                this._count--; //add a line to be able to decrease count when remove a node
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
            this._count--;
            return;
        }

        if (index == this._count - 1) 
        {
            LnkNode<T> temp = this._head;
            while (temp!=this._last) 
            {
                if (temp.Next == this._last) 
                {
                    this._last = temp;
                    this._count--;
                    return;
                }
                temp = temp.Next;
            }
        }

        
        var currentIndex = 0;
        var currentNode = _head;
        
        while (currentNode != null)
        {
            if (currentIndex == index - 1)
            {
                currentNode.Next = currentNode.Next!.Next;
                this._count--;
                return;
            }
            
            currentIndex++;
            currentNode = currentNode.Next;
        }
    }

    // O(1)
    public int Count()
    {

        return this._count;
    }

    // O(n)
    public T[] ToArray()
    {
        T[] temp_Array = new T[this._count];
        LnkNode<T> temp_node = this._head;
        int array_Counter = 0;

        /*while (temp_node != null) 
        {
            temp_Array[array_Counter] = temp_node.Value;
            temp_node = temp_node.Next;
            array_Counter++;
        }*/

        for (int i = 0; i <= this._count - 1; i++)
        {
            temp_Array[i] = temp_node.Value;
            temp_node = temp_node.Next;
        }

        return temp_Array;
    }

    public T Last()
    {
        if (_last == null)
            throw new InvalidOperationException();
        
        return _last.Value;
    }
}