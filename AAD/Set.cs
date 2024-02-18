public class Set
{
    private HashSet<int> elements;

    public Set()
    {
        elements = new HashSet<int>();
    }

    public void Add(int item)
    {
        elements.Add(item);
    }

    public bool Contains(int item)
    {
        return elements.Contains(item);
    }

    public int[] ToArray()
    {
        var array = new int[elements.Count];
        elements.CopyTo(array);
        Array.Sort(array); 
        return array;
    }
}