using System.Linq;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class GroupAggregationPipelineTestFixture : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pipeline;

        public GroupAggregationPipelineTestFixture(DatabaseType databaseType) : base(databaseType)
        {
            _pipeline = new EmptyPipelineDefinition<BasicDocument>();
        }

        [Test]
        public void Group_Push()
        {
            var item = BasicDocument.Generate();
            var item2 = BasicDocument.Generate();
            item2.Name = item.Name;
            Insert(item, item2, BasicDocument.Generate());

            var result = Aggregate(_pipeline.Group(x => x.Name, x => new { Id = x.Key, AllInnerDocuments = x.Select(s => s.Inner) }));
            result.Count.Should().Be(2);

            var grouped = result.FirstOrDefault(x => x.Id == item.Name);
            grouped.Should().NotBeNull();
            grouped.AllInnerDocuments.Count().Should().Be(2);
            grouped.AllInnerDocuments.Should().OnlyContain(x => new[] { item.Inner.Value, item2.Inner.Value }.Contains(x.Value));
        }
    }
}
