namespace AAD.Tests;

public class BSTreeNodeTest
{
    [Fact]
    public void Constructor()
    {
        var n = new BSTreeNode(value: 10);

        Assert.Equal(10, n.Value);
        Assert.Null(n.Left);
        Assert.Null(n.Right);
    }

    [Fact]
    public void Add_RepeatedValue()
    {
        var n = new BSTreeNode(value: 10);
        n.Add(10);

        Assert.Null(n.Left);
        Assert.Null(n.Right);
    }

    [Fact]
    public void Add_Left()
    {
        var n = new BSTreeNode(value: 10);
        n.Add(5);

        Assert.NotNull(n.Left);
        Assert.Equal(5, n.LeftValue);

        Assert.Null(n.Right);
    }

    [Fact]
    public void Add_LeftIsNotNull()
    {
        var n = new BSTreeNode(value: 10);
        n.Add(5);
        n.Add(3);

        Assert.Equal(5, n.LeftValue);
        var left = n.Left;

        Assert.NotNull(left);
        Assert.Equal(3, left.LeftValue);
    }

    [Fact]
    public void Add_Right()
    {
        var n = new BSTreeNode(value: 10);
        n.Add(15);

        Assert.Null(n.Left);

        Assert.NotNull(n.Right);
        Assert.Equal(15, n.RightValue);
    }

    [Fact]
    public void Add_RightIsNotNull()
    {
        var n = new BSTreeNode(value: 10);
        n.Add(15);
        n.Add(20);

        Assert.Equal(15, n.RightValue);
        var right = n.Right;

        Assert.NotNull(right);
        Assert.Equal(20, right.RightValue);
    }

    [Fact]
    public void Contains_OneNode()
    {
        var n = BSTreeNode
            .From(new[] { 15 });

        Assert.True(n.Contains(15));
    }

    [Fact]
    public void Contains_InLeft()
    {
        var n = BSTreeNode
            .From(new[] { 15, 5 });

        Assert.True(n.Contains(5));
    }

    [Fact]
    public void Contains_InRight()
    {
        var n = BSTreeNode
            .From(new[] { 15, 20 });

        Assert.True(n.Contains(20));
    }

    [Fact]
    public void Contains_DotNotExistInLeft()
    {
        var n = BSTreeNode
            .From(new[] { 15 });

        Assert.False(n.Contains(5));
    }

    [Fact]
    public void Contains_DotNotExistInRight()
    {
        var n = BSTreeNode
            .From(new[] { 15 });

        Assert.False(n.Contains(20));
    }

    [Fact]
    public void Min_One()
    {
        var n = new BSTreeNode(10);

        Assert.Equal(10, n.Min());
    }

    [Fact]
    public void Min_Many()
    {
        var n = BSTreeNode
            .From(new[] { 10, 5, 1, 3, 15, 8, 7 });
        ;

        Assert.Equal(1, n.Min());
    }

    [Fact]
    public void Max_Many()
    {
        var n = BSTreeNode
            .From(new[] { 10, 5, 1, 3, 15, 8, 7 });
        ;

        Assert.Equal(15, n.Max());
    }

    [Fact]
    public void Delete_OnlyRootLeaf()
    {
        var t = new BSTreeNode(10);
        var result = t.Delete(10);
        Assert.Null(result);
    }

    [Fact]
    public void Delete_LeftLeaf()
    {
        var t = BSTreeNode
            .From(new[] { 10, 5 });

        t.Delete(5);

        Assert.Null(t.Left);
    }
    
    [Fact]
    public void Delete_LeafInLeftChild()
    {
        var t = BSTreeNode
            .From(new[] { 10, 5, 3 });

        t.Delete(3);

        Assert.Equal(2, t.Count());
        Assert.False(t.Contains(3));
    }
    
    [Fact]
    public void Delete_LeftChildWithLeftChild()
    {
        var t = BSTreeNode
            .From(new[] { 10, 5, 3 });

        t.Delete(5);

        Assert.Equal(2, t.Count());
        Assert.False(t.Contains(5));
    }
    
    [Fact]
    public void Delete_LeafInRightChild()
    {
        var t = BSTreeNode
            .From(new[] { 10, 15 });

        t.Delete(15);

        Assert.Equal(1, t.Count());
        Assert.False(t.Contains(15));
    }
    
    [Fact]
    public void Delete_RightChildRightChild()
    {
        var t = BSTreeNode
            .From(new[] { 10, 15, 20 });

        t.Delete(15);

        Assert.Equal(2, t.Count());
        Assert.False(t.Contains(15));
    }
    
    [Fact]
    public void Delete_NotFoundInLeft()
    {
        var t = BSTreeNode
            .From(new[] { 10 });

        t.Delete(3);

        Assert.Equal(new[] { 10 }, t.ToArray());
    }
    
    [Fact]
    public void Delete_NotFoundInRight()
    {
        var t = BSTreeNode
            .From(new[] { 10 });

        t.Delete(15);

        Assert.Equal(new[] { 10 }, 
            t.ToArray());
    }
    
    [Fact]
    public void Delete_SubTreeWithChildrenLeftAndRight()
    {
        var t = BSTreeNode
            .From(new[] { 10, 5, 4, 8, 1, 7, 9 });

        t.Delete(5);

        Assert.Equal(
            new[] { 1, 4, 7, 8, 9, 10 }, 
            t.ToArray());
    }

    [Fact]
    public void TraverseInOrder_OneNode()
    {
        var root = BSTreeNode
            .From(new[] { 15 });

        var result = new List<int>();
        root.TraverseInOrder(node => result.Add(node.Value));

        Assert.Equal(
            new[] { 15 },
            result.ToArray());
    }

    [Fact]
    public void TraverseInOrder_OneNodeInLeft()
    {
        var root = BSTreeNode
            .From(new[] { 15, 12 });

        var result = new List<int>();
        root.TraverseInOrder(node => result.Add(node.Value));

        Assert.Equal(
            new[] { 12, 15 },
            result.ToArray());
    }

    [Fact]
    public void TraverseInOrder_Many()
    {
        var root = BSTreeNode
            .From(new[] { 15, 12, 27, 7, 14, 20, 88, 23 });

        var result = new List<int>();
        root.TraverseInOrder(node => result.Add(node.Value));

        Assert.Equal(
            new[] { 7, 12, 14, 15, 20, 23, 27, 88 },
            result.ToArray());
    }

    [Fact]
    public void TraversePreOrder_Many()
    {
        var root = BSTreeNode
            .From(new[] { 15, 12, 27, 7, 14, 20, 88, 23 });

        var result = new List<int>();
        root.TraversePreOrder(node => result.Add(node.Value));

        Assert.Equal(
            new[] { 15, 12, 7, 14, 27, 20, 23, 88 },
            result.ToArray());
    }

    [Fact]
    public void TraversePostOrder_Many()
    {
        var root = BSTreeNode
            .From(new[] { 15, 12, 27, 7, 14, 20, 88, 23 });

        var result = new List<int>();
        root.TraversePostOrder(node => result.Add(node.Value));

        Assert.Equal(
            new[] { 7, 14, 12, 23, 20, 88, 27, 15 },
            result.ToArray());
    }
}