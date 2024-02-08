namespace AAD;

public class LnkList<T> {
    
    public static LnkList<T> From(params T[] values)
    {
       
        var ll = new LnkList<T>();

        foreach (var value in values)
            ll.Add(value);

        return ll;

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
        var newNode= new LnkNode<T>(element);
        
        if(_head == null)
            _head =  _last = newNode;
        else
            _last = _last.Next = newNode;
        
        _count++;

    }

    // O(n)
    public void Insert(int index, T value)
    {
        var newNode = new LnkNode<T>(value);

        if(index == 0){
            newNode.Next = _head;
            _head = newNode;
            _count++;
            return;
        }

        if(index < 0 || index > _count - 1)
            throw new IndexOutOfRangeException();

        int iterator = 1;
        var currentNode = _head;

        while(currentNode.Next != null){
            if(iterator == index){
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
                _count++;
                return;
            }

            iterator++;
            currentNode = currentNode.Next;
        }
    }

    // O(1)
    public int Count()
    {
        return _count;
    }

    public T[] ToArray()
    {
        var elementArray = new List<T>();

        if(_head == null)
            return Array.Empty<T>();

        var currentNode = _head;
        
        while(currentNode != null){
            elementArray.Add(currentNode.Value);
            currentNode = currentNode.Next;
        }

        return elementArray.ToArray();
    }
}
