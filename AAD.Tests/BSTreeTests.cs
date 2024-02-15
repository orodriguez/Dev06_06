namespace AAD.Tests;

public class BSTreeTests
{
    [Fact]
    public void Constructor()
    {
        var tree = new BSTree();
        Assert.Equal(0, tree.Count());
    }
    
    [Fact]
    public void ConstructorWithValue()
    {
        var tree = new BSTree(10);
        Assert.Equal(1, tree.Count());
        Assert.True(tree.Contains(10));
    }
    
    [Fact]
    public void Contains_Empty()
    {
        var tree = new BSTree();
        Assert.False(tree.Contains(10));
    }
    
    [Fact]
    public void Add_Empty()
    {
        var tree = new BSTree();
        tree.Add(10);
        Assert.Equal(1, tree.Count());
        Assert.True(tree.Contains(10));
    }
    
    [Fact]
    public void Add_NotEmpty()
    {
        var tree = new BSTree();
        tree.Add(10);
        tree.Add(15);
        Assert.Equal(2, tree.Count());
        Assert.True(tree.Contains(10));
        Assert.True(tree.Contains(15));
    }
}