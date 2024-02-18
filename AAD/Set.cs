using System;
using System.Collections.Generic;

namespace AAD
{
    public class Set
    {
        private readonly HashSet<int> items;

        public Set()
        {
            items = new HashSet<int>();
        }

        public void Add(int item)
        {
            items.Add(item);
        }

        public bool Contains(int item)
        {
            return items.Contains(item);
        }

        public int[] ToArray()
        {
            int[] array = new int[items.Count];
            items.CopyTo(array);
            Array.Sort(array);
            return array;
        }
    }
}
