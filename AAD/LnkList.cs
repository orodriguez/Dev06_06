namespace AAD;

public class LnkList<T> {
    
    public static LnkList<T> From(params T[] values)
    {
        var LinkList = new LnkList<T>();
        foreach(var value in values){
           // var linkNode = new LnkNode<T>(value); 
            LinkList.Add(value);
            
        }
        return LinkList;
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
        var newNode = new LnkNode<T>(element);
        if(_head == null){
            _head = newNode;
            _last = _head;
        }else{
        _last.Next = newNode;
        _last = newNode;
        }
        _count++;
    }

    // O(n)
    public void Insert(int index, T value)
    {
        var newNode = new LnkNode<T>(value);
        if(_head == null){
            return;
        }
        if(index == 0){
            newNode.Next = _head;
            _head = newNode;
        }else{
            var iterator = 1;
        var currentNode = _head;
        while(iterator < _count){
            if(index == iterator){
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
            }
            currentNode = currentNode.Next;
            iterator++;
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
        var dinamyctList = new List<T>();
         if(_head == null)
            return Array.Empty<T>();

        var currentNode = _head;
        
        while(currentNode != null){
            dinamyctList.Add(currentNode.Value);
            currentNode = currentNode.Next;
        }

        return dinamyctList.ToArray();
    }
}