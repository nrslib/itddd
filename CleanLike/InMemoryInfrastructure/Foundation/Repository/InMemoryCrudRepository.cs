using System.Collections.Generic;

namespace InMemoryInfrastructure.Foundation.Repository
{
    public abstract class InMemoryCrudRepository<TKey, TValue>
    {
        public Dictionary<TKey, TValue> Db { get; } = new Dictionary<TKey, TValue>();

        public virtual void Save(TValue value)
        {
            var id = GetKey(value);
            Db[id] = DeepClone(value);
        }

        public virtual TValue Find(TKey key)
        {
            if (Db.TryGetValue(key, out var value))
            {
                var instance = DeepClone(value);
                return instance;
            }
            else
            {
                return default(TValue);
            }
        }

        public virtual void Update(TValue value)
        {
            var id = GetKey(value);
            Db[id] = DeepClone(value);
        }

        public virtual void Delete(TValue value)
        {
            var id = GetKey(value);
            Db.Remove(id);
        }

        protected abstract TKey GetKey(TValue value);
        protected abstract TValue DeepClone(TValue value);
    }
}
