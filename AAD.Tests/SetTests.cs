namespace AAD.Tests;

public class SetTests
{
    [Fact]
    public void Add()
    {
        var s = new Set();
        s.Add(10);
        s.Add(5);
        s.Add(20);
        s.Add(4);
        
        Assert.Equal(new[] { 4, 5, 10, 20}, 
            s.ToArray());
    }
    
    [Fact]
    public void Add_Duplicated()
    {
        var s = new Set();
        s.Add(10);
        s.Add(10);
        s.Add(20);
        s.Add(20);
        
        Assert.Equal(new[] { 10, 20 }, 
            s.ToArray());
    }

    [Fact]
    public void Contains()
    {
        var s = new Set();
        s.Add(5);
        s.Add(8);
        s.Add(3);
        
        Assert.True(s.Contains(8));
    }
    
    [Fact]
    public void Contains_NotFound()
    {
        var s = new Set();
        s.Add(5);
        s.Add(8);
        s.Add(3);
        
        Assert.False(s.Contains(10));
    }
}