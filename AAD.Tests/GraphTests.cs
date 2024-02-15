namespace AAD.Tests;

public class GraphTests
{
    [Fact]
    public void Paths_NodeNotFound()
    {
        var g = new Graph<string>();

        Assert.Empty(g.Paths("A", "B"));
    }

    [Fact]
    public void Paths_StartDoesNotExist()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        Assert.Empty(g.Paths("C", "B"));
    }

    [Fact]
    public void Paths_EndDoesNotExist()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        Assert.Empty(g.Paths("A", "C"));
    }

    [Fact]
    public void Paths_StartToStart()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        var path = Assert.Single(g.Paths("A", "A"));

        Assert.Equal(new[] { "A" }, path);
    }

    [Fact]
    public void Paths_OneSingleStepPath()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        var path = Assert.Single(g.Paths("A", "B"));

        Assert.Equal(new[] { "A", "B" }, path);
    }

    [Fact]
    public void Paths_One2StepPath()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");

        var path = Assert.Single(g.Paths("A", "C"));

        Assert.Equal(new[] { "A", "B", "C" }, path);
    }

    [Fact]
    public void Paths_TwoPaths()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("A", "C");

        var paths = g.Paths("A", "C");

        var expected = new[]
        {
            new[] { "A", "B", "C" }, 
            new[] { "A", "C" }
        };
        
        Assert.Equal(expected, paths);
    }
}