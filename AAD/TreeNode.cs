public class TreeNode<T>
{
    public T Value { get; }
    public TreeNode<T>? Parent { get; private set; }
    public List<TreeNode<T>> Children { get; }

    public TreeNode(T value, TreeNode<T>? parent = null)
    {
        Value = value;
        Parent = parent;
        Children = new List<TreeNode<T>>();
    }

    public int Level
    {
        get
        {
            int level = 0;
            var current = this.Parent;

            while (current != null)
            {
                level++;
                current = current.Parent;
            }

            return level;
        }
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
        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            action(node);

            foreach (var child in node.Children)
                queue.Enqueue(child);
        }
    }
}
