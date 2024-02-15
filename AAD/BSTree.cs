namespace AAD;

public class BSTree
{
    private BSTreeNode? _root;
    public BSTree() => _root = null;

    public BSTree(int value) =>
        _root = new BSTreeNode(value);

    public BSTree(BSTreeNode root) => _root = root;

    public void Add(int newValue)
    {
        if (_root == null)
        {
            _root = new BSTreeNode(newValue);
            return;
        }

        _root.Add(newValue);
    }

    public int Count() =>
        _root?.Count() ?? 0;

    public bool Contains(int searchedValue) =>
        _root != null && _root.Contains(searchedValue);

    public void Delete(int valueToDelete) => 
        _root = _root?.Delete(valueToDelete);

    public int[] ToArray()
    {
        var result = new List<int>();

        if (_root == null)
            return Array.Empty<int>();
        
        _root.TraverseInOrder(node => result.Add(node.Value));

        return result.ToArray();
    }

    public static BSTree From(int[] values)
    {
        var root = BSTreeNode.From(values);
        return new BSTree(root);
    }

    public int Min()
    {
        if (_root == null)
            throw new InvalidOperationException();

        return _root.Min();
    }
}