using Xunit.Sdk;

namespace AAD.Tests;

public class HashMapTests
{
    [Fact]
    public void Get()
    {
        var hm = new HashMap<string, int>
        {
            ["A"] = 1
        };

        Assert.Equal(1, hm["A"]);
    }
    
    [Fact]
    public void Get_KeyNotFound()
    {
        var hm = new HashMap<string, int>();

        Assert.Throws<KeyNotFoundException>(() => hm["A"]);
    }
    
    [Fact]
    public void Get_Collision()
    {
        var hm = new HashMap<string, int>(capacity: 2);

        hm["A"] = 1;
        hm["B"] = 2;
        hm["C"] = 3;

        Assert.Equal(1, hm["A"]);
        Assert.Equal(2, hm["B"]);
        Assert.Equal(3, hm["C"]);
    }
    
    [Fact]
    public void Set_ReplaceKey()
    {
        var hm = new HashMap<string, int>(capacity: 2);

        hm["A"] = 1;
        hm["A"] = 2;

        Assert.Equal(2, hm["A"]);
    }
}