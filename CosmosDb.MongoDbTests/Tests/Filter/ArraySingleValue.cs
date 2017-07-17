using System;
using System.Collections.Generic;
using CosmosDb.MongoDbTests.Extensions;
using CosmosDb.MongoDbTests.Models;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Filter
{
    public class ArraySingleValue : DatabaseTestFixture<BasicDocument>
    {
        private readonly BasicDocument _item;
        private readonly BasicDocument _item2;

        public ArraySingleValue(DatabaseType databaseType) : base(databaseType)
        {
            _item = BasicDocument.Generate(x => x.IntArray = new List<int> { 1, 2, 3 });
            _item2 = BasicDocument.Generate(x => x.IntArray = new List<int> { 4, 5, 6 });
            Insert(_item, _item2);
        }

        [Test]
        public void AnyEq_StringArray()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyEq(x => x.StringArray, _item.StringArray[1]))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void AnyNe_StringArray()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyNe(x => x.StringArray, _item.StringArray[1]))
                .ShouldHaveOneResultMatching(_item2);
        }

        [Test]
        public void AnyGt_IntArray()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyGt(x => x.IntArray, 5))
                .ShouldHaveOneResultMatching(_item2);
        }

        [Test]
        public void AnyGte_IntArray()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyGte(x => x.IntArray, 6))
                .ShouldHaveOneResultMatching(_item2);
        }

        [Test]
        public void AnyLt_IntArray()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyLt(x => x.IntArray, 2))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void AnyLte_IntArray()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyLte(x => x.IntArray, 1))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void AnyIn_StringArray()
        {
            var check = new[] { Guid.NewGuid().ToString("N"), _item.StringArray[1] };
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyIn(x => x.StringArray, check))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void AnyNin_StringArray()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().AnyNin(x => x.StringArray, _item.StringArray))
                .ShouldHaveOneResultMatching(_item2);
        }
    }
}
