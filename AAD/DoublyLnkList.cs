namespace AAD;

public class DoublyLnkList<T> where T : notnull
{
    private int _count;
    private LnkNode<T>? _head;
    private LnkNode<T>? _last;


    public static DoublyLnkList<T> From(params T[] values)
    {
        int n = values.Length;
        DoublyLnkList<T> dblList = new DoublyLnkList<T>();

        for (int i = 0; i < n; i++) 
        {
            dblList.Add(values[i]);
        }
        return dblList;
    }

    public T this[int index]
    {
        get 
        {
            //T data = null;

            if (index == 0 && this._head!=null)
            {
                return this._head.Value;
            }
            else if(index == this._count - 1 && this._last!=null)
            {
                return this._last.Value;
            }

            

            LnkNode<T> current = this._head;
            int counter = 0;
            while (current != null) 
            {
                if (counter == index) 
                {
                    return current.Value;
                }
                counter++;
                current = current.Next;
            }

            throw new IndexOutOfRangeException();

        }
    
    }

    public void Prepend(T value)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        return this._count;
    }

    public void Add(T value)
    {
        LnkNode<T> newNode = new LnkNode<T>(value);

        if (this._count == 0 && (this._head == null && this._last == null))
            {
                this._head = newNode;
                this._last = newNode;
                this._head.Next = this._last;
                this._last.Previous = this._head;    
                
                this._count++;
                return;
            }

        LnkNode<T> temp_Last = this._last;
        newNode.Previous = this._last;
        this._last.Next = newNode;
        this._last = newNode;
        this._count++;
        return;


    }

    public void Insert(int index, T value)
    {
        LnkNode<T> newNode = new LnkNode<T>(value);
        LnkNode<T> temp_Node = this._head;
        if (this._count == 0) 
        {
            return;
        }

        if (index == 0) 
        {
            newNode.Next = this._head;
            //this._head.Previous = newNode;
            this._head = newNode;
            this._count++;
            return;
        }

        int counter = 0;
        int n = this._count;

            

        for (int i = 0; i < n; i++)
        {
            if (counter == index) 
            {
                LnkNode<T> previous = temp_Node.Previous;
                previous.Next = newNode;
                newNode.Previous = previous;
                newNode.Next = temp_Node;
                this._count++;
                return;
            }

            temp_Node = temp_Node.Next;
            counter++;
        
        }
    }

    public bool Remove(T value)
    {
        LnkNode<T> currentNode = this._head;

        if (this._head == null && this._last == null) 
        {
            return false;
        }

        if(this._last.Value.Equals(value))
            {
               LnkNode<T> previous = this._last.Previous;
                previous.Next = null;
                this._last = previous;
                this._count--;
                return true;
        }

        while (currentNode != null) 
        {
            if(currentNode.Value.Equals(value))
            {
                LnkNode<T> previous = currentNode.Previous;
                LnkNode<T> next = currentNode.Next;

                previous.Next = next;
                next.Previous = previous;
                this._count--;
                return true;
            }
            currentNode = currentNode.Next;
        
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        
        LnkNode<T> currentNode = this._head;
        if (this._count == 0)
        {
            throw new IndexOutOfRangeException("Out of Rnage");
        }

        if (index >= this._count || index < 0)
        {
            throw new IndexOutOfRangeException("Index is Out of range");
        }

        if (index == 0)
        {
            this._head = null;
            this._last = null;
            this._count--;
            return;
        }

        
        if (index == this._count - 1) 
        {
            LnkNode<T> previous = this._last.Previous;
            previous.Next = null;
            this._last = previous;
            this._count--;
            return;
        }

        int counter = 0;
        int n = this._count;



        for (int i = 0; i < n-1; i++)
        {
            if (counter == index)
            {
                LnkNode<T> previous = currentNode.Previous;
                LnkNode<T> next = currentNode.Next;

                previous.Next = next;
                next.Previous = previous;
                this._count--;
                return;
            }

            currentNode = currentNode.Next;
            counter++;

        }
    }

    public T Last()
    {
        if (this._count==0 && this._last == null)
        {
            throw new InvalidOperationException();
        }
        return this._last.Value;
    }

    public T[] ToArray()
    {
        /*if (this._head == null) 
        {
            return new T[0];
        }*/
        LnkNode<T> tempNode = this._head;
        T[] tempArray = new T[this._count];
        for (int i = 0; i < this._count; i++)
        {
            tempArray[i] = tempNode.Value;
            tempNode = tempNode.Next;
        
        }

        return tempArray;
    }

    public T[] ToReversedArray()
    {
        throw new NotImplementedException();
    }
}