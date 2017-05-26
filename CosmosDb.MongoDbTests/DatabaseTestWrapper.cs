using System;
using System.Configuration;
using MongoDB.Driver;

namespace CosmosDb.MongoDbTests
{
    public class DatabaseTestWrapper<TType> : IDisposable
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<TType> _collection;

        public DatabaseTestWrapper(DatabaseType type)
        {
            var connectionString = ConfigurationManager.AppSettings[type.ToString()];
            var client = new MongoClient(MongoUrl.Create(connectionString));
            _db = client.GetDatabase("test");
            _collection = _db.GetCollection<TType>(typeof(TType).Name);
        }

        public IMongoCollection<TType> Collection()
        {
            return _collection;
        }

        public void Dispose()
        {
            _db.DropCollection(typeof(TType).Name);
        }
    }
}
