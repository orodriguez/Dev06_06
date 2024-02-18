using System.Collections;
using System.ComponentModel.Design.Serialization;

namespace AAD;

public class Set
{
    private BSTreeNode? Root;
    public void Add(int value)
    {
        if(Root == null)
            Root = new BSTreeNode(value);
        else
            Root.Add(value);
    }

    public int[] ToArray()
    {
        List<int> result= new List<int>();
        Root.TraverseInOrder(node => result.Add(node.Value));

        return result.ToArray();
    }

    public bool Contains(int value)
    {
        return Root.Contains(value);
    }
}