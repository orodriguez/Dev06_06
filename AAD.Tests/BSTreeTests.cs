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
    
    [Fact]
    public void Delete_Empty()
    {
        var tree = new BSTree();

        Assert.False(tree.Delete(10));
    }

    [Fact]
    public void Delete_RootAndLeaf()
    {
        var tree = new BSTree(10);

        tree.Delete(10);
        
        Assert.Equal(0, tree.Count());
    }
    
    [Fact]
    public void Delete_LeftLeaf()
    {
        var tree = BSTree.From(new[] { 10, 5 });
        
        tree.Delete(5);
        
        Assert.Equal(new[] { 10 }, tree.ToArray());
    }
    
    [Fact]
    public void Delete_LeftNotFound()
    {
        var tree = BSTree.From(new[] { 10 });
        
        Assert.False(tree.Delete(5));
        
        Assert.Equal(new[] { 10 }, tree.ToArray());
    }
    
    [Fact]
    public void Delete_RightLeaf()
    {
        var tree = BSTree.From(new[] { 10, 15 });

        tree.Delete(15);
        
        Assert.Equal(new[] { 10 }, tree.ToArray());
    }
    
    [Fact]
    public void Delete_RightNotFound()
    {
        var tree = BSTree.From(new[] { 10 });
        
        Assert.False(tree.Delete(15));
        
        Assert.Equal(new[] { 10 }, tree.ToArray());
    }
}