using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CosmosDb.MongoDbTests.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests
{
    [TestFixture(DatabaseType.AzureCosmosDb)]
    [TestFixture(DatabaseType.NativeMongoDb)]
    public abstract class DatabaseTestFixture<TDocument> : IDisposable
    {
        protected DatabaseTestWrapper<TDocument> Database;

        protected DatabaseTestFixture(DatabaseType databaseType)
        {
            Database = new DatabaseTestWrapper<TDocument>(databaseType);
        }
        
        public void Dispose()
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
            Console.Write(filter.Render(serializer, BsonSerializer.SerializerRegistry).ToString());
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

        protected List<BsonDocument> Aggregate(string json)
        {
            var pl = new EmptyPipelineDefinition<TDocument>();
            return Aggregate(pl.Json<TDocument, BsonDocument>(json));
        }

        protected List<TDocumentOut> Aggregate<TDocumentOut>(PipelineDefinition<TDocument, TDocumentOut> pipeline)
        {
            var serializer = BsonSerializer.LookupSerializer<TDocument>();
            Console.Write(string.Join("\r\n", pipeline.Render(serializer, BsonSerializer.SerializerRegistry).Documents));
            return Database.Collection().Aggregate(pipeline).ToList();
        }

        protected IMongoCollection<TDocument> Collection()
        {
            return Database.Collection();
        }
    }
}
