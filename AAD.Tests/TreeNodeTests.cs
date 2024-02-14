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

    [Fact]
    public void Count_OneNode()
    {
        var superMarketNode = new TreeNode<string>("Super Market");

        Assert.Equal(1, superMarketNode.Count());
    }

    [Fact]
    public void Count_Many()
    {
        var superMarket = new TreeNode<string>("Super Market");

        var vegetables = superMarket
            .Add("Vegetables");

        vegetables.Add("Tomato");
        vegetables.Add("Carrot");

        Assert.Equal(4, superMarket.Count());
    }

    [Fact]
    public void Level()
    {
        var superMarket = new TreeNode<string>("Super Market");

        Assert.Equal(0, superMarket.Level());
    }

    [Fact]
    public void Level_OneChild()
    {
        var child = new TreeNode<string>("A").Add("B");

        Assert.Equal(1, child.Level());
    }
    
    [Fact]
    public void Level_Two()
    {
        var leaf = new TreeNode<string>("A")
            .Add("B")
            .Add("C");

        Assert.Equal(2, leaf.Level());
    }
}

public class TreeNode<T>
{
    public T Value { get; }
    public TreeNode<T>? Parent { get; private set; }
    public List<TreeNode<T>> Children { get; }
    private int _level;
    public TreeNode(T value, TreeNode<T>? parent = null)
    {
        Value = value;
        Parent = parent;
        Children = new List<TreeNode<T>>();

        if (Parent != null)
        {
            this._level = Parent.Level() + 1;
        }
        else
        {
            this._level = 0;
        }
    }

    public bool IsRoot => Parent == null;

    public int Level()
    {
        return this._level;
    }

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
}