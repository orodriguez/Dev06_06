namespace AAD.Tests;

public class LnkListTests
{
    [Fact]
    public void Prepend_EmptyList()
    {
        var ll = new LnkList<string>();

        ll.Prepend("A");
        
        Assert.Equal(new[] { "A" }, ll.ToArray());
    }
    
    [Fact]
    public void Prepend_Many()
    {
        var ll = LnkList<int>.From(1, 2, 3);

        ll.Prepend(4);
        
        Assert.Equal(new[] { 4, 1, 2, 3 }, ll.ToArray());
    }

    [Fact]
    public void Add_Empty()
    {
        var ll = new LnkList<string>();

        ll.Add("One");
        
        Assert.Equal(new[] { "One" }, ll.ToArray());
    }

    [Fact]
    public void Add_Many()
    {
        var ll = LnkList<int>.From(1, 2, 3);

        ll.Add(4);
        
        Assert.Equal(new[] { 1, 2, 3, 4 }, ll.ToArray());
    }

    [Fact]
    public void Insert_Empty()
    {
        var ll = new LnkList<string>();

        ll.Insert(0, "Juan");
        
        Assert.Equal(Array.Empty<string>(), ll.ToArray());
    }

    [Fact]
    public void Insert_OneElement()
    {
        var ll = LnkList<string>.From("Pablo");

        ll.Insert(0, "Juan");
        
        Assert.Equal(new[] { "Juan", "Pablo" }, 
            ll.ToArray());
    }

    [Fact]
    public void Insert_Many()
    {
        var ll = LnkList<string>.From("Juan", "Duarte");

        ll.Insert(1, "Pablo");
        
        Assert.Equal(new[] { "Juan", "Pablo", "Duarte" }, 
            ll.ToArray());
    }

    [Fact]
    public void Count_Empty()
    {
        var ll = new LnkList<int>();
        
        Assert.Equal(0, ll.Count());
    }

    [Fact]
    public void Count_Many()
    {
        var ll = LnkList<int>.From(1, 2, 3, 4);
        
        Assert.Equal(4, ll.Count());
    }

    [Fact]
    public void From()
    {
        var ll = LnkList<int>.From(1, 2, 3);
        
        Assert.Equal(new[] { 1, 2, 3 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_Empty()
    { 
        var ll = new LnkList<int>();

        Assert.Equal(Array.Empty<int>(), ll.ToArray());
    }

    [Fact]
    public void ToArray_OneElement()
    {
        var ll = LnkList<int>.From(1);;

        Assert.Equal(new[] { 1 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_TwoElements()
    {
        var ll = LnkList<int>.From(1, 2);;

        Assert.Equal(new[] { 1, 2 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_Many()
    {
        var ll = LnkList<int>.From(1, 2, 3, 4);

        Assert.Equal(new[] { 1, 2, 3, 4 }, ll.ToArray());
    }
}