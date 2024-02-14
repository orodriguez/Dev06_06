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

        Assert.Equal(0, superMarket.Level);
    }

    [Fact]
    public void Level_OneChild()
    {
        var child = new TreeNode<string>("A").Add("B");

        Assert.Equal(1, child.Level);
    }
    
    [Fact]
    public void Level_Two()
    {
        var leaf = new TreeNode<string>("A")
            .Add("B")
            .Add("C");

        Assert.Equal(2, leaf.Level);
    }
    
    [Fact]
    public void Height_OneNode()
    {
        var t = new TreeNode<string>("A");
        
        Assert.Equal(1, t.Height());
    }
    
    [Fact]
    public void Height_TreeNodes()
    {
        var t = new TreeNode<string>("A");
        t.Add("X");
        
        var b = t.Add("B");
        b.Add("C");
        
        Assert.Equal(3, t.Height());
    }
}