using SolarSystemApi.Services;

namespace SolarSystemApi.Tests
{
    public class TestDBProxy : ILiteDatabase
    {
        public void Dispose()
        {
        }

        IDBCollectionProxy<EntityType> ILiteDatabase.GetCollection<EntityType>(string typeName)
        {
            throw new System.NotImplementedException();
        }
    }
}
