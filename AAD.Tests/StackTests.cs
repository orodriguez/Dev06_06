namespace AAD.Tests;

public class StackTests
{
    [Fact]
    public void Push()
    {
        var s = new Stack<string>();
        
        // O(1)
        s.Push("A");
        s.Push("B");

        // O(1)
        var actual = s.Pop();
        Assert.Equal("B", actual);
    }
    
    [Fact]
    public void Pop_Empty()
    {
        var s = new Stack<string>();

        Assert.Throws<InvalidOperationException>(() => s.Pop());
    }
    
    [Fact]
    public void Peek()
    {
        var s = new Stack<string>();

        s.Push("A");
        s.Push("B");

        var p = s.Peek();
        
        Assert.Equal("B", p);
        
        Assert.Equal("B", s.Pop());
    }
}