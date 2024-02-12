using System.Collections;

namespace AAD.Tests;

public class TreeNodeTests
{
    [Fact]
    public void Constructor()
    {
        var t = new TreeNode<string>("Super Market");
        
        Assert.Equal("Super Market", t.Value);
        Assert.True(t.IsRoot);
        Assert.Empty(t.Children);
    }
    
    [Fact]
    public void Add()
    {
        var superMarketNode = new TreeNode<string>("Super Market");

        superMarketNode.Add("Vegetables");

        var vegetablesNode = Assert.Single(superMarketNode.Children);
        
        Assert.Equal("Vegetables", vegetablesNode.Value);
        Assert.Equal(superMarketNode, vegetablesNode.Parent);
        Assert.Empty(vegetablesNode.Children);
    }
}

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
    
    public bool IsRoot => Parent == null;

    public void Add(T childValue) => 
        Add(new TreeNode<T>(childValue, parent: this));

    private void Add(TreeNode<T> node) => 
        Children.Add(node);
}