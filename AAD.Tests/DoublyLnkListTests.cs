namespace AAD.Tests;

public class DoublyDoublyLnkListTests
{
    [Fact]
    public void Prepend_EmptyList()
    {
        var ll = new DoublyLnkList<string>();

        ll.Prepend("A");

        AssertElementsCountAndLast(new[] { "A" }, ll);
    }

    [Fact]
    public void Prepend_Many()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3);

        ll.Prepend(4);

        AssertElementsCountAndLast(new[] { 4, 1, 2, 3 }, ll);
    }

    [Fact]
    public void Get_Empty()
    {
        var ll = new DoublyLnkList<string>();

        Assert.Throws<IndexOutOfRangeException>(() => ll[0]);
    }

    [Fact]
    public void Get_Many()
    {
        var ll = DoublyLnkList<string>.From("A", "B", "C");

        Assert.Equal("B", ll[1]);
    }

    [Fact]
    public void Get_OutOfRange()
    {
        var ll = DoublyLnkList<string>.From("A", "B", "C");

        Assert.Throws<IndexOutOfRangeException>(() => ll[10]);
        Assert.Throws<IndexOutOfRangeException>(() => ll[-2]);
    }

    [Fact]
    public void Add_Empty()
    {
        var ll = new DoublyLnkList<string>();

        ll.Add("One");

        AssertElementsCountAndLast(new[] { "One" }, ll);
    }

    [Fact]
    public void Add_Many()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3);

        ll.Add(4);

        AssertElementsCountAndLast(new[] { 1, 2, 3, 4 }, ll);
    }

    [Fact]
    public void Insert_Empty()
    {
        var ll = new DoublyLnkList<string>();

        ll.Insert(0, "Juan");

        AssertElementsCountAndLast(Array.Empty<string>(), ll);
    }

    [Fact]
    public void Insert_OneElement()
    {
        var ll = DoublyLnkList<string>.From("Pablo");

        ll.Insert(0, "Juan");

        AssertElementsCountAndLast(new[] { "Juan", "Pablo" }, ll);
    }

    [Fact]
    public void Insert_Many()
    {
        var ll = DoublyLnkList<string>.From("Juan", "Duarte");

        ll.Insert(1, "Pablo");

        AssertElementsCountAndLast(new[] { "Juan", "Pablo", "Duarte" }, ll);
    }

    [Fact]
    public void Remove_Empty()
    {
        var ll = new DoublyLnkList<string>();

        var result = ll.Remove("Random");

        Assert.False(result);
    }

    [Fact]
    public void Remove_FirstOfMany()
    {
        var ll = DoublyLnkList<string>.From("A", "B");

        Assert.True(ll.Remove("A"));

        AssertElementsCountAndLast(new[] { "B" }, ll);
    }

    [Fact]
    public void Remove_OneAndOnly()
    {
        var ll = DoublyLnkList<string>.From("A");

        Assert.True(ll.Remove("A"));

        AssertElementsCountAndLast(Array.Empty<string>(), ll);
    }

    [Fact]
    public void Remove_ManyRemoveInTheMiddle()
    {
        var ll = DoublyLnkList<string>.From("A", "B", "C");

        Assert.True(ll.Remove("B"));

        AssertElementsCountAndLast(new[] { "A", "C" }, ll);
    }

    [Fact]
    public void Remove_ManyRemoveLast()
    {
        var ll = DoublyLnkList<string>.From("A", "B", "C");

        Assert.True(ll.Remove("C"));

        AssertElementsCountAndLast(new[] { "A", "B" }, ll);
    }

    [Fact]
    public void Remove_ManyNotFound()
    {
        var ll = DoublyLnkList<string>.From("A", "B", "C");

        Assert.False(ll.Remove("D"));
    }

    [Fact]
    public void RemoveAt_Empty()
    {
        var ll = new DoublyLnkList<string>();

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.RemoveAt(0));
    }

    [Fact]
    public void RemoveAt_IndexOutOfRange()
    {
        var ll = DoublyLnkList<string>.From("A", "B");

        Assert.Throws<IndexOutOfRangeException>(() => ll.RemoveAt(-1));
        Assert.Throws<IndexOutOfRangeException>(() => ll.RemoveAt(1000));
    }

    [Fact]
    public void RemoveAt_OnlyOne()
    {
        var ll = DoublyLnkList<string>.From("One");

        ll.RemoveAt(0);

        AssertElementsCountAndLast(Array.Empty<string>(), ll);
    }

    [Fact]
    public void RemoveAt_Many()
    {
        var ll = DoublyLnkList<string>.From("A", "B", "C");

        ll.RemoveAt(1);

        AssertElementsCountAndLast(new[] { "A", "C" }, ll);
    }

    [Fact]
    public void RemoveAt_LastOfMany()
    {
        var ll = DoublyLnkList<string>.From("A", "B", "C");

        ll.RemoveAt(2);

        AssertElementsCountAndLast(new[] { "A", "B" }, ll);
    }

    [Fact]
    public void Count_Empty()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Equal(0, ll.Count());
    }

    [Fact]
    public void Count_Many()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3, 4);

        Assert.Equal(4, ll.Count());
    }

    [Fact]
    public void From()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3);

        Assert.Equal(new[] { 1, 2, 3 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_Empty()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Equal(Array.Empty<int>(), ll.ToArray());
    }

    [Fact]
    public void ToArray_OneElement()
    {
        var ll = DoublyLnkList<int>.From(1);
        ;

        Assert.Equal(new[] { 1 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_TwoElements()
    {
        var ll = DoublyLnkList<int>.From(1, 2);
        ;

        Assert.Equal(new[] { 1, 2 }, ll.ToArray());
    }

    [Fact]
    public void ToArray_Many()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3, 4);

        Assert.Equal(new[] { 1, 2, 3, 4 }, ll.ToArray());
    }

    [Fact]
    public void Last()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3);

        Assert.Equal(3, ll.Last());
    }

    [Fact]
    public void Last_Empty()
    {
        var ll = new DoublyLnkList<string>();

        Assert.Throws<InvalidOperationException>(() => ll.Last());
    }
    
    [Fact]
    public void ToReversedArray_Empty()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Equal(Array.Empty<int>(), ll.ToReversedArray());
    }
    
    [Fact]
    public void ToReversedArray_Many()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3);

        Assert.Equal(new[] { 3, 2, 1 }, ll.ToReversedArray());
    }

    private void AssertElementsCountAndLast<T>(T[] values, DoublyLnkList<T> ll) where T : notnull
    {
        Assert.Equal(values, ll.ToArray());
        Assert.Equal(values.Length, ll.Count());
        if (values.Length > 0)
            Assert.Equal(values.Last(), ll.Last());
    }
}