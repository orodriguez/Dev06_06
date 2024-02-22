namespace AAD;

public class TreeNode<T>
{
    public T Value { get; }
    public TreeNode<T>? Parent { get; private set; }
    public List<TreeNode<T>> Children { get; }
    public int Level { get; }
    
    public TreeNode(T value, TreeNode<T>? parent = null)
    {
        Value = value;
        Parent = parent;
        Level = Parent == null ? 0 : Parent.Level + 1;
        Children = new List<TreeNode<T>>();
    }

    public bool IsRoot => Parent == null;
    
    public TreeNode<T> Add(T childValue) =>
        Add(new TreeNode<T>(childValue, parent: this));

    private TreeNode<T> Add(TreeNode<T> node)
    {
        Children.Add(node);
        return node;
    }

    public int Count() => ChildrenCount() + 1;

    private int ChildrenCount() =>
        Children
            .Select(child => child.Count())
            .Sum();

    public int Height()
    {
        if (IsLeaf)
            return Level + 1;
        
        return Children.Max(node => node.Height());
    }

    public bool IsLeaf => Children.Count == 0;

    // O(n)
    public void TraversePreOrder(Action<TreeNode<T>> action)
    {
        action(this);

        foreach (var child in Children) 
            child.TraversePreOrder(action);
    }
    
    // O(n)
    public void TraversePostOrder(Action<TreeNode<T>> action)
    {
        foreach (var child in Children) 
            child.TraversePostOrder(action);
        
        action(this);
    }
    
    // O(n)
    public void TraverseLevelOrder(Action<TreeNode<T>> action)
    {
        var levels = new Dictionary<int, List<TreeNode<T>>>();
        
        TraversePreOrder(node =>
        {
            if (!levels.ContainsKey(node.Level))
                levels[node.Level] = new List<TreeNode<T>>();
            
            levels[node.Level].Add(node);
        });

        foreach (var level in levels.Keys)
        foreach (var node in levels[level])
            action(node);
    }

    //Esto es un enumerable tipo char
    public IEnumerable<char> Print()
    {
        //imprimiendo cuando solo ahy 1 nodo, eso implica que root y isleaf, serian true, esto pasa, colo cuando el root
        //y el leaf son el mismo. Cuando no hay padre y Childre.Count es 0.
        if (IsRoot && IsLeaf)
        {
            foreach (char c in Value.ToString()) 
            {
                yield return c;
            }
        }
        else 
        {
            throw new InvalidOperationException("Print() method can only be called when there is only one node in the tree.");

        }

        
    }
}