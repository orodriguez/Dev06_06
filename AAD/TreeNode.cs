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
}