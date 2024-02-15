namespace AAD;

public class BSTree : IBSTree
{
    private readonly BSTreeNode? _root;
    public BSTree() => _root = null;

    public BSTree(int value) => 
        _root = new BSTreeNode(value);

    public void Add(int newValue)
    {
        throw new NotImplementedException();
    }

    public int Count() => 
        _root?.Count() ?? 0;

    public bool Contains(int searchedValue) => 
        _root != null && _root.Contains(searchedValue);
}