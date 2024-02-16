namespace AAD.Tests;

public class GraphTests
{
    [Fact]
    public void Paths_EmptyGraph()
    {
        var g = new Graph<string>();
        var paths = g.Paths("A", "B");
        Assert.Empty(paths);
    }
    
    [Fact]
    public void Paths_StartEqualsEnd()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        
        var paths = g.Paths("A", "A");
        Assert.Empty(paths);
    }
    
    [Fact]
    public void Paths_OneEdge()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        
        var paths = g.Paths("A", "B");
        var path = Assert.Single(paths);
        
        Assert.Equal(new[] { "A", "B" }, 
            path.ToArray());
    }
}