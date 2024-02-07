using System.Runtime.CompilerServices;

namespace AAD;

public class LnkList<T> {
    
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

        while (temp_node != null) 
        {
            temp_Array[array_Counter] = temp_node.Value;
            temp_node = temp_node.Next;
            array_Counter++;
        }
        return temp_Array;
    }
}