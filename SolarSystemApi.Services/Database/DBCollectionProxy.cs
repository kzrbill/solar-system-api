using System;
using LiteDB;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SolarSystemApi.Services
{
    public interface IDBCollectionProxy<EntityType>
    {
        BsonValue Insert(EntityType document);
        bool EnsureIndex<K>(Expression<Func<EntityType, K>> property, bool unique = false);
        IEnumerable<EntityType> Find(Expression<Func<EntityType, bool>> predicate, int skip = 0, int limit = int.MaxValue);
        IEnumerable<EntityType> Find(Query query, int skip = 0, int limit = int.MaxValue);
    }

    public class DBCollectionProxy<EntityType> : IDBCollectionProxy<EntityType>
    {
        LiteCollection<EntityType> _liteCollection;
        public DBCollectionProxy(LiteCollection<EntityType> liteCollection)
        {
            _liteCollection = liteCollection;
        }

        public bool EnsureIndex<K>(Expression<Func<EntityType, K>> property, bool unique = false)
        {
            return _liteCollection.EnsureIndex(property, unique);
        }

        public IEnumerable<EntityType> Find(Expression<Func<EntityType, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {
            return _liteCollection.Find(predicate, skip, limit);
        }

        public IEnumerable<EntityType> Find(Query query, int skip = 0, int limit = int.MaxValue)
        {
            return _liteCollection.Find(query, skip, limit);
        }

        public BsonValue Insert(EntityType document)
        {
            return _liteCollection.Insert(document);
        }
    }
}
