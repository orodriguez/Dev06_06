namespace AAD;

public class HashMap<TKey, TValue>
{
    private readonly Bucket[] _buckets;
    private readonly int _capacity;

    public HashMap(int capacity = 4)
    {
        _capacity = capacity;
        
        _buckets = new Bucket[capacity];
        for (var i = 0; i < _buckets.Length; i++) 
            _buckets[i] = new Bucket();
    }

    public TValue this[TKey key]
    {
        get => Get(key);
        set => Add(key, value);
    }

    // O(1)
    private TValue Get(TKey key)
    {
        var index = Hash(key);
        
        var bucket = _buckets[index];
        return bucket.Get(key);
    }

    // O(1) ... to be continued
    private void Add(TKey key, TValue value)
    {
        var index = Hash(key);
        var bucket = _buckets[index];
        bucket.Add(key, value);
    }
    
    private int Hash(TKey key)
    {
        var hashCode = Math.Abs(key.GetHashCode());
        return hashCode % _capacity;
    }
    private class Bucket
    {
        private readonly List<KeyValuePair<TKey, TValue>> _values;
        private bool _isEmpty;
        public bool isEmpty => _isEmpty;

        public Bucket()
        {
            _values = new List<KeyValuePair<TKey, TValue>>();
            _isEmpty = true;
        }

        public TValue Get(TKey key)
        {
            var exists = _values.Any(pair => pair.Key.Equals(key));
            
            if (!exists)
                throw new KeyNotFoundException();
                
            var pair = _values.First(pair => pair.Key.Equals(key));

            return pair.Value;
        }

        public void Add(TKey key, TValue value)
        {
            _values.Add(
                new KeyValuePair<TKey, TValue>(key, value));
            
            _isEmpty = false;
        }
    }
}