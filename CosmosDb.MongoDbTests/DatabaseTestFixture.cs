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

        protected List<TDocument> Find(FilterDefinition<TDocument> filter)
        {
            var serializer = BsonSerializer.LookupSerializer<TDocument>();
            Console.WriteLine(filter.Render(serializer, BsonSerializer.SerializerRegistry).ToString());
            return Database.Collection().FindSync(filter).ToList();
        }

        protected List<TDocument> Find(Expression<Func<TDocument, bool>> expr)
        {
            return Find(new ExpressionFilterDefinition<TDocument>(expr));
        }

        protected List<TDocument> Find(string json)
        {
            return Find(new JsonFilterDefinition<TDocument>(json));
        }

        protected List<TDocumentOut> Aggregate<TDocumentOut>(PipelineDefinition<TDocument, TDocumentOut> pipeline)
        {
            var serializer = BsonSerializer.LookupSerializer<TDocument>();
            Console.WriteLine(string.Join("\r\n", pipeline.Render(serializer, BsonSerializer.SerializerRegistry).Documents));
            return Database.Collection().Aggregate(pipeline).ToList();
        }

        protected IMongoCollection<TDocument> Collection()
        {
            return Database.Collection();
        }
    }
}
