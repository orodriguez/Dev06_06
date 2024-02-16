namespace AAD;

public class Set
{
    private BSTreeNode bst_data;
    private bool _flag = false; // to verify if first time adding
    

    public void Add(int value)
    {
        if (!_flag)
        {
            bst_data = new BSTreeNode(value);
            this._flag = true;
        }
        else
        {
            
            bst_data.Add(value);            


        }
        
    }

    public int[] ToArray()
    {
        var result = new List<int>();
        this.bst_data.TraverseInOrder(node => result.Add(node.Value));

        return result.ToArray();
    }

    public bool Contains(int value)
    {
        return this.bst_data.Contains(value); 
    }
}