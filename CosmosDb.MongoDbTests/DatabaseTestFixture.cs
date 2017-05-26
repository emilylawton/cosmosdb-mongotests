using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests
{
    [TestFixture(DatabaseType.AzureCosmosDb)]
    [TestFixture(DatabaseType.NativeMongoDb)]
    public abstract class DatabaseTestFixture<TDocument>
    {
        private readonly DatabaseType _databaseType;
        protected DatabaseTestWrapper<TDocument> Database;

        protected DatabaseTestFixture(DatabaseType databaseType)
        {
            _databaseType = databaseType;
        }

        [SetUp]
        public void SetUp()
        {
            Database = new DatabaseTestWrapper<TDocument>(_databaseType);
        }

        [TearDown]
        public void TearDown()
        {
            Database.Dispose();
            Database = null;
        }

        // Helpers
        protected void Insert(params TDocument[] docs)
        {
            Database.Collection().InsertMany(docs);
        }

        protected List<TDocument> Find(Expression<Func<TDocument, bool>> expr)
        {
            var query = new ExpressionFilterDefinition<TDocument>(expr);
            var serializer = BsonSerializer.LookupSerializer<TDocument>();
            Console.WriteLine(query.Render(serializer, BsonSerializer.SerializerRegistry).ToString());
            return Database.Collection().FindSync(expr).ToList();
        }

        protected List<TDocument> FindJson(string json)
        {
            var query = new JsonFilterDefinition<TDocument>(json);
            var serializer = BsonSerializer.LookupSerializer<TDocument>();
            Console.WriteLine(query.Render(serializer, BsonSerializer.SerializerRegistry).ToString());
            return Database.Collection().FindSync(query).ToList();
        }
    }
}
