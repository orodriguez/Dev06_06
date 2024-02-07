using System.Runtime.CompilerServices;

namespace AAD;

public class LnkList<T> {
    
    public static LnkList<T> From(params T[] values)
    {
        int n = values.Length;
        LnkList<T> listaLink = new LnkList<T>();
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
    //add First, lo que haremos sera agregar al inicio de la lista por defecto con este metodo.
    public void Add(T element)
    {

            
        

        if (this._count == 0)
        {
            LnkNode<T> newNode = new LnkNode<T>(element);
            _head = newNode;
            this._count++;
        }
        else
        {
            LnkNode<T> oldNode = this._head;
            LnkNode<T> newNode = new LnkNode<T>(element, this._head);
            this._head = newNode;
            this._count++;
        }
            
    
    }

    // O(n)
    public void Insert(int index, T value)
    {
        throw new NotImplementedException();
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
        LnkNode<T> temp_node = _head;
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