using System;
using System.Linq;
using CosmosDb.MongoDbTests.Extensions;
using CosmosDb.MongoDbTests.Models;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Filter
{
    public class ArraySingleValueFilterTestFixture : DatabaseTestFixture<BasicDocument>
    {
        public ArraySingleValueFilterTestFixture(DatabaseType databaseType) : base(databaseType)
        {
        }

        [Test]
        public void AnyEq_StringArray()
        {
            var item = BasicDocument.Generate();
            Insert(item);

            Find(new FilterDefinitionBuilder<BasicDocument>().AnyEq(x => x.StringArray, item.StringArray[1]))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void AnyNe_StringArray()
        {
            var item = BasicDocument.Generate();
            var item2 = BasicDocument.Generate();
            Insert(item, item2);

            Find(new FilterDefinitionBuilder<BasicDocument>().AnyNe(x => x.StringArray, item.StringArray[1]))
                .ShouldHaveOneResultMatching(item2);
        }

        [Test]
        public void AnyGt_IntArray()
        {
            var item = BasicDocument.Generate();
            Insert(item);

            Find(new FilterDefinitionBuilder<BasicDocument>().AnyGt(x => x.IntArray, item.IntArray.Max() - 1))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void AnyGte_IntArray()
        {
            var item = BasicDocument.Generate();
            Insert(item);

            Find(new FilterDefinitionBuilder<BasicDocument>().AnyGte(x => x.IntArray, item.IntArray.Max()))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void AnyLt_IntArray()
        {
            var item = BasicDocument.Generate();
            Insert(item);

            Find(new FilterDefinitionBuilder<BasicDocument>().AnyLt(x => x.IntArray, item.IntArray.Min() + 1))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void AnyLte_IntArray()
        {
            var item = BasicDocument.Generate();
            Insert(item);

            Find(new FilterDefinitionBuilder<BasicDocument>().AnyLte(x => x.IntArray, item.IntArray.Min()))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void AnyIn_StringArray()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            var check = new[] { Guid.NewGuid().ToString("N"), item.StringArray[1] };
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyIn(x => x.StringArray, check))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void AnyNin_StringArray()
        {
            var item = BasicDocument.Generate();
            var item2 = BasicDocument.Generate();
            Insert(item, item2);
            
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyNin(x => x.StringArray, item.StringArray))
                .ShouldHaveOneResultMatching(item2);
        }
    }
}
