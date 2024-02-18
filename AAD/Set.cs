namespace AAD;

public class Set
{
    private HashSet<int> elements;

    public Set()
    {
        elements = new HashSet<int>();
    }
    public void Add(int value)
    {
        elements.Add(value);
    }

    public int[] ToArray()
    {
        var array = new int[elements.Count];
        elements.CopyTo(array);
        Array.Sort(array); 
        return array;
    }

    public bool Contains(int value)
    {
        return elements.Contains(value);
    }
}