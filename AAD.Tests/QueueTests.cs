namespace AAD.Tests;

public class QueueTests
{
    [Fact]
    public void Queue()
    {
        var q = new Queue<string>();
        
        q.Enqueue("A");
        
        Assert.Equal("A", q.Peek());
        
        Assert.Equal("A", q.Dequeue());
        
        Assert.Empty(q);
    }
}