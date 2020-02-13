using System;
using System.Collections.Generic;
using System.Linq;

namespace _17
{
    public abstract class InMemoryRepository<TKey, TEntity>
        where TKey : IEquatable<TKey>
    {
        protected readonly Dictionary<TKey, TEntity> creates = new Dictionary<TKey, TEntity>();
        protected readonly Dictionary<TKey, TEntity> updates = new Dictionary<TKey, TEntity>();
        protected readonly Dictionary<TKey, TEntity> deletes = new Dictionary<TKey, TEntity>();
        protected Dictionary<TKey, TEntity> db = new Dictionary<TKey, TEntity>();

        protected Dictionary<TKey, TEntity> data => db
            .Except(deletes)
            .Concat(creates)
            .Concat(updates)
            .ToDictionary(x => x.Key, x => x.Value);

        public void Save(TEntity entity)
        {
            var id = GetId(entity);
            var targetMap = data.ContainsKey(id) ? updates : creates;
            targetMap[id] = Clone(entity);
        }

        public void Remove(TEntity entity)
        {
            var id = GetId(entity);
            deletes[id] = Clone(entity);
        }

        public void Commit()
        {
            db = data;
            creates.Clear();
            updates.Clear();
            deletes.Clear();
        }

        protected abstract TKey GetId(TEntity entity);
        protected abstract TEntity Clone(TEntity entity);
    }
}
