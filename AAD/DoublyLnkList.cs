namespace AAD;

    public class DoublyLnkListNode<T>
    {
    public DoublyLnkListNode<T>? Next {get; set;}
    public DoublyLnkListNode<T>? Prev{ get; set; }
    public T? Dato{get; set;}

        public DoublyLnkListNode(T dato, DoublyLnkListNode<T>? next = null){
            Dato = dato;
            Next = next;
            Prev = null;
        }
    } 
public class DoublyLnkList<T> where T : notnull
{
    private  DoublyLnkListNode<T>? _head;
    private DoublyLnkListNode<T>? _last;
    private int _count;

    public DoublyLnkList(){
        _head = null;
        _last = null;
        _count = 0;
    }
    public static DoublyLnkList<T> From(params T[] values)
    {
        var ll = new DoublyLnkList<T>();

        foreach(var dato in values){
            ll.Add(dato);
        }
        return  ll;
    
    }


    public T this[int index] => throw new NotImplementedException();

    public void Prepend(T value)
    {
          if (_head == null)
        {
            _head = new DoublyLnkListNode<T>(value);
            _last = _head;
        }else
        {
            var newNode = new DoublyLnkListNode<T>(value);
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }

        
    }

    public int Count() => _count;

    public void Add(T value)
    {
            
       var newNode = new DoublyLnkListNode<T>(value);

       if(_head == null)
       {
            _head = newNode;
            _last = newNode;

       }else
       {
            _last.Next = newNode;
            newNode.Prev = _last;
            _last = newNode;
            _count ++;
       }

       

    }

    public void Insert(int index, T value)
    {
        if (index == 0) {
            var newNode = new DoublyLnkListNode<T>(value, _head);
            _head = newNode;
            return;
        }
        
    }

    public bool Remove(T value)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T Last()
    {
        throw new NotImplementedException();
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }

    public T[] ToReversedArray()
    {
        throw new NotImplementedException();
    }
}

