using System;
using System.Configuration;
using MongoDB.Driver;

namespace CosmosDb.MongoDbTests
{
    public class DatabaseTestWrapper<TType> : IDisposable
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<TType> _collection;
        private readonly string _collectionName;

        public DatabaseTestWrapper(DatabaseType type)
        {
            var connectionString = ConfigurationManager.AppSettings[type.ToString()];
            var client = new MongoClient(MongoUrl.Create(connectionString));
            _db = client.GetDatabase("test");
            _collectionName = typeof(TType).Name + "_" + Guid.NewGuid().ToString("N");
            _collection = _db.GetCollection<TType>(_collectionName);
        }

        public IMongoCollection<TType> Collection()
        {
            return _collection;
        }

        public void Dispose()
        {
            _db.DropCollection(_collectionName);
        }
    }
}
