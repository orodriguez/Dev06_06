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
    public void Get_Empty()
    {
        var ll = new LnkList<string>();

        Assert.Throws<IndexOutOfRangeException>(() => ll[0]);
    }
    
    [Fact]
    public void Get_Many()
    {
        var ll = LnkList<string>.From("A", "B", "C");

        Assert.Equal("B", ll[1]);
    }
    
    [Fact]
    public void Get_OutOfRange()
    {
        var ll = LnkList<string>.From("A", "B", "C");

        Assert.Throws<IndexOutOfRangeException>(() => ll[10]);
        Assert.Throws<IndexOutOfRangeException>(() => ll[-2]);
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
    public void Remove_Empty()
    {
        var ll = new LnkList<string>();

        var result = ll.Remove("Random");
        
        Assert.False(result);
    }
    [Fact]
    public void Remove_FirstOfMany()
    {
        var ll = LnkList<string>.From("A", "B");

        Assert.True(ll.Remove("A"));
        
        Assert.Equal(new[] { "B" }, ll.ToArray());
    }
    
    [Fact]
    public void Remove_OneAndOnly()
    {
        var ll = LnkList<string>.From("A");

        Assert.True(ll.Remove("A"));
        
        Assert.Equal(Array.Empty<string>(), ll.ToArray());
    }
    
    [Fact]
    public void Remove_ManyRemoveInTheMiddle()
    {
        var ll = LnkList<string>.From("A", "B", "C");

        Assert.True(ll.Remove("B"));
        
        Assert.Equal(new[] { "A", "C"}, ll.ToArray());
    }
    
    [Fact]
    public void Remove_ManyRemoveLast()
    {
        var ll = LnkList<string>.From("A", "B", "C");

        Assert.True(ll.Remove("C"));
        
        Assert.Equal(new[] { "A", "B"}, ll.ToArray());
    }
    
    [Fact]
    public void Remove_ManyNotFound()
    {
        var ll = LnkList<string>.From("A", "B", "C");

        Assert.False(ll.Remove("D"));
    }
    
    [Fact]
    public void RemoveAt_Empty()
    {
        var ll = new LnkList<string>();

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.RemoveAt(0));
    }
    
    [Fact]
    public void RemoveAt_IndexOutOfRange()
    {
        var ll = LnkList<string>.From("A", "B");

        Assert.Throws<IndexOutOfRangeException>(() => ll.RemoveAt(-1));
        Assert.Throws<IndexOutOfRangeException>(() => ll.RemoveAt(1000));
    }
    
    [Fact]
    public void RemoveAt_OnlyOne()
    {
        var ll = LnkList<string>.From("One");

        ll.RemoveAt(0);
        
        Assert.Equal(Array.Empty<string>(), ll.ToArray());
    }
    
    [Fact]
    public void RemoveAt_Many()
    {
        var ll = LnkList<string>.From("A", "B", "C");

        ll.RemoveAt(1);
        
        Assert.Equal(new[] { "A", "C" }, ll.ToArray());
    }
    
    [Fact]
    public void RemoveAt_LastOfMany()
    {
        var ll = LnkList<string>.From("A", "B", "C");

        ll.RemoveAt(2);
        
        Assert.Equal(new[] { "A", "B" }, ll.ToArray());
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