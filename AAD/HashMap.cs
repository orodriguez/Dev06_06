namespace AAD;

public class HashMap<TKey, TValue> where TKey : notnull
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

    public void Remove(TKey key)
    {
        var index = Hash(key);
        var bucket = _buckets[index];
        bucket.Remove(key);
    }

    private class Bucket
    {
        private readonly List<KeyValuePair<TKey, TValue>> _pairs;
        private bool _isEmpty;
        public bool isEmpty => _isEmpty;

        public Bucket()
        {
            _pairs = new List<KeyValuePair<TKey, TValue>>();
            _isEmpty = true;
        }

        public TValue Get(TKey key)
        {
            var exists = _pairs.Any(pair => pair.Key.Equals(key));
            
            if (!exists)
                throw new KeyNotFoundException();
                
            var pair = _pairs.First(pair => pair.Key.Equals(key));

            return pair.Value;
        }

        public void Add(TKey key, TValue value)
        {
            var index = _pairs.FindIndex(
                pair => pair.Key.Equals(key));
            if (index != -1) 
                _pairs.RemoveAt(index);

            _pairs.Add(
                new KeyValuePair<TKey, TValue>(key, value));
            
            _isEmpty = false;
        }

        public void Remove(TKey key)
        {
            var index = _pairs.FindIndex(
                pair => pair.Key.Equals(key));
            
            _pairs.RemoveAt(index);
        }
    }
}