namespace AAD;

public class Graph<T> where T : notnull
{
    private readonly Dictionary<T, List<T>> _edges;

    public Graph() => _edges = new Dictionary<T, List<T>>();

    public IEnumerable<IEnumerable<T>> Paths(T from, T to) => 
        Paths(Array.Empty<T>(), from, to);

    private IEnumerable<IEnumerable<T>> Paths(IEnumerable<T> prefix, T from, T to)
    {
        if (!_edges.ContainsKey(from))
            return Array.Empty<T[]>();

        if (from.Equals(to))
            return new[] { prefix.Concat(new[] { from }) };

        return _edges[from]
            .Select(node => Paths(prefix.Concat(new[] { from }), node, to))
            .SelectMany(paths => paths);
    }

    public void Add(T from, T to)
    {
        if (!_edges.ContainsKey(from))
            _edges[from] = new List<T>();

        if (!_edges.ContainsKey(to))
            _edges[to] = new List<T>();
        
        _edges[from].Add(to);
    }
}