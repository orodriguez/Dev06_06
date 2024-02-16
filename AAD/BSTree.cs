namespace AAD;

public class BSTree
{
    private BSTreeNode? _root;

    public BSTree() : this(null)
    {
    }

    private BSTree(BSTreeNode? root) =>
        _root = root;

    public void Add(int value)
    {
        if (_root == null)
        {
            _root = new BSTreeNode(value);
            return;
        }
        
        _root.Add(value);
    }

    public int Count()
    {
        if (_root == null)
            return 0;
        
        var count = 0;
        _root.TraverseInOrder(_ => count++);
        return count;
    }

    public bool Contains(int value)
    {
        if (_root == null)
            return false;
        
        return _root.Contains(value);
    }
}