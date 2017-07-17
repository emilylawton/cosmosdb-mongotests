using System.Linq;
using CosmosDb.MongoDbTests.Extensions;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class Aggregation : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pl;
        private readonly BasicDocument _item;
        private readonly BasicDocument _item2;
        private readonly BasicDocument _item3;

        public Aggregation(DatabaseType databaseType) : base(databaseType)
        {
            _pl = new EmptyPipelineDefinition<BasicDocument>();
            _item = BasicDocument.Generate();
            _item2 = BasicDocument.Generate();
            _item3 = BasicDocument.Generate();
            Insert(_item, _item2, _item3);
        }

        [Test]
        public void Project()
        {
            Aggregate(_pl.Project(x => new { x.Name }))
                .Should().Contain(x => x.Name == _item.Name);
        }

        [Test]
        public void Match()
        {
            Aggregate(_pl.Match(x => x.Name == _item.Name))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void Limit()
        {
            Aggregate(_pl.Limit(2)).Should().HaveCount(2);
        }

        [Test]
        public void Skip()
        {
            Aggregate(_pl.Skip(1)).Should().HaveCount(2);
        }

        [Test]
        public void Unwind()
        {
            var allItems = new[] {_item, _item2, _item3}.SelectMany(x => x.StringArray).ToArray();
            var result = Aggregate(_pl.Unwind(x => x.StringArray));
            result.Should().HaveCount(allItems.Length);
            result.Should().OnlyContain(x => allItems.Contains(x["StringArray"].AsString));
        }

        [Test]
        public void Sort()
        {
            var expected = new[] {_item, _item2, _item3}.OrderBy(x => x.Name).ToArray();
            var result = Aggregate(_pl.Sort(new JsonSortDefinition<BasicDocument>("{\"Name\": 1}")));

            result.Should().HaveCount(expected.Length);
            result.First().Name.Should().Be(expected.First().Name);
        }

        [Test]
        public void Sample()
        {
            var result = Aggregate(_pl.Json<BasicDocument, BasicDocument>("{ \"$sample\": { size: 2 } }"));
            result.Should().HaveCount(2);
        }

        [Test]
        public void Count()
        {
            var result = Aggregate(_pl.Count());
            result.First().Count.Should().Be(3);
        }
    }
}
