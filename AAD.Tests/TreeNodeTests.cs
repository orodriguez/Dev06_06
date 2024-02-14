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

    [Fact]
    public void TraversePreOrder()
    {
        var sm = BuildSuperMarketNode();

        var result = new List<string>();

        sm.TraversePreOrder(node => result.Add(node.Value));

        var expected = new[]
        {
            "Super Market",
            "Vegetables",
            "Tomato",
            "Lettuce",
            "Personal Care",
            "Shampoo",
            "Tooth Paste"
        };
        
        Assert.Equal(expected, result.ToArray());
    }
    
    [Fact]
    public void TraversePostOrder()
    {
        var sm = BuildSuperMarketNode();

        var result = new List<string>();

        sm.TraversePostOrder(node => result.Add(node.Value));

        var expected = new[]
        {
            "Tomato",
            "Lettuce",
            "Vegetables",
            "Shampoo",
            "Tooth Paste",
            "Personal Care",
            "Super Market",
        };
        
        Assert.Equal(expected, result.ToArray());
    }
    
    [Fact]
    public void TraverseLevelOrder()
    {
        var sm = BuildSuperMarketNode();

        var result = new List<string>();

        sm.TraverseLevelOrder(node => result.Add(node.Value));

        var expected = new[]
        {
            "Super Market",
            "Vegetables",
            "Personal Care",
            "Tomato",
            "Lettuce",
            "Shampoo",
            "Tooth Paste",
        };
        
        Assert.Equal(expected, result.ToArray());
    }

    private static TreeNode<string> BuildSuperMarketNode()
    {
        var sm = new TreeNode<string>("Super Market");

        var v = sm.Add("Vegetables");
        v.Add("Tomato");
        v.Add("Lettuce");

        var pc = sm.Add("Personal Care");
        pc.Add("Shampoo");
        pc.Add("Tooth Paste");
        return sm;
    }
}