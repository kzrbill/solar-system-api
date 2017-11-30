using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LiteDB;
using SolarSystemApi.Services;

namespace SolarSystemApi.Tests
{
    public class TestDBCollection<EntityType> : IDBCollectionProxy<EntityType>
    {
        List<EntityType> _docs;
        public TestDBCollection() {
            _docs = new List<EntityType>();
        }

        public bool EnsureIndex<K>(Expression<Func<EntityType, K>> property, bool unique = false)
        {
            return true;
        }

        public IEnumerable<EntityType> Find(Expression<Func<EntityType, bool>> predicateExp, int skip = 0, int limit = int.MaxValue)
        {
            Func<EntityType, bool> predicate = predicateExp.Compile();
            return _docs.FindAll(e => predicate(e));
        }

        public BsonValue Insert(EntityType document)
        {
            _docs.Add(document);
            return _docs.Count;
        }
    }
}
