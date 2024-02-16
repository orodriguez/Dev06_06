namespace AAD;

public class Graph<T> where T : notnull
{
    private readonly Dictionary<T, List<Edge>> _edges;

    public Graph() => 
        _edges = new Dictionary<T, List<Edge>>();

    public IEnumerable<Path> Paths(T start, T end)
    {
        if (!_edges.ContainsKey(start))
            return Array.Empty<Path>();
        
        if (start.Equals(end))
            return Array.Empty<Path>();

        var edge = _edges[start]
            .FirstOrDefault(edge => edge.To.Equals(end));
        
        if (edge != null)
            return new[] { new Path(edge) };

        throw new NotImplementedException();
    }

    public void Add(T from, T to)
    {
        var edge = new Edge(from, to);

        if (!_edges.ContainsKey(from))
            _edges[from] = new List<Edge>();
        
        _edges[from].Add(edge);
    }

    public record Edge(T From, T To);

    public record Path(Edge[] Edges)
    {
        public Path(Edge edge) : this(new[] { edge })
        {
        }

        public T[] ToArray()
        {
            if (Edges.Length == 0)
                return Array.Empty<T>();

            return Edges
                .Select(edge => edge.From)
                .Concat(new[] { Edges.Last().To })
                .ToArray();
        }
    }
}