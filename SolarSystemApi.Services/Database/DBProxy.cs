using System;
using LiteDB;

namespace SolarSystemApi.Services
{
    public interface ILiteDatabase : IDisposable
    {
        IDBCollectionProxy<EntityType> GetCollection<EntityType>(string typeName);
    }

    public class DBProxy : ILiteDatabase
    {
        private LiteDatabase _db;
        public DBProxy(string connectionString)
        {
            _db = new LiteDatabase(connectionString);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IDBCollectionProxy<EntityType> GetCollection<EntityType>(string typeName)
        {
            return new DBCollectionProxy<EntityType>(_db.GetCollection<EntityType>(typeName));
        }
    }
}
