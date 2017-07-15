using System.Collections.Generic;
using System.Diagnostics;

namespace LibAtem.Util
{
    public class UniqueQueue<TKey, TVal>
    {
        private readonly Queue<TKey> idQueue;
        private readonly Dictionary<TKey, TVal> entries;

        public UniqueQueue()
        {
            idQueue = new Queue<TKey>();
            entries = new Dictionary<TKey, TVal>();
        }

        public int Count => idQueue.Count;
        public bool IsEmpty => Count == 0;

        // TODO return false if item was replaced
        public void Enqueue(TKey key, TVal item)
        {
            lock (idQueue)
            {
                if (!entries.ContainsKey(key))
                    idQueue.Enqueue(key);

                entries[key] = item;
            }
        }

        public TVal Dequeue()
        {
            lock (idQueue)
            {
                if (idQueue.Count == 0)
                    return default(TVal);

                TKey key = idQueue.Dequeue();
                TVal val;
                if (entries.TryGetValue(key, out val))
                {
                    entries.Remove(key);
                    return val;
                }

                // recurse until we find one that isnt corrupt
                Debug.Fail("Failed to find entry for key");
                return Dequeue();
            }
        }
    }
}
