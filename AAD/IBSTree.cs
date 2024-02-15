namespace AAD;

public interface IBSTree
{
    void Add(int newValue);
    int Count();
    bool Contains(int searchedValue);
}