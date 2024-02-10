namespace AAD.Tests;

public class ArraysTests
{
    [Fact]
    public void GetByIndex()
    {
        var a = new[] { "A", "B", "C" };

        // O(1)
        var first = a[0];

        var expect = "A";

        Assert.Equal(expect, first);
    }

    [Fact]
    public void Search_3Elements()
    {
        var a = new[] { "A", "B", "C" };

        // O(n)
        var element = a.First(element => element == "C");

        var expect = "C";

        Assert.Equal(expect, element);
    }

    [Fact]
    public void IndexOutOfRange()
    {
        var a = new string[2];

        a[0] = "Juan";
        a[1] = "Duarte";

        Assert.Throws<IndexOutOfRangeException>(() => a[2]);
    }

    [Fact]
    public void Insert()
    {
        // Dynamic Array
        var a = new List<string> { "Juan", "Duarte" };

        // O(n)
        a.Insert(1, "Pablo");

        Assert.Equal(new[] { "Juan", "Pablo", "Duarte" }, a);
    }

    [Fact]
    public void Delete()
    {
        var a = new List<string> { "Juan", "Pablo", "Duarte" };

        // O(n)
        a.Remove("Pablo");

        Assert.Equal(new[] { "Juan", "Duarte" }, a);
    }
}