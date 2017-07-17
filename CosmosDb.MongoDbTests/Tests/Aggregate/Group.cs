using System.Linq;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class Group : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pl;
        private readonly BasicDocument _item;
        private readonly BasicDocument _item2;

        public Group(DatabaseType databaseType) : base(databaseType)
        {
            _pl = new EmptyPipelineDefinition<BasicDocument>();
            _item = BasicDocument.Generate();
            _item2 = BasicDocument.Generate(x => x.Name = _item.Name);
            Insert(_item, _item2, BasicDocument.Generate());
        }

        [Test]
        public void Push()
        {
            var result = Aggregate(_pl.Group(x => x.Name, x => new { Id = x.Key, AllInnerDocuments = x.Select(s => s.Inner) }));
            result.Count.Should().Be(2);

            var grouped = result.FirstOrDefault(x => x.Id == _item.Name);
            grouped.Should().NotBeNull();
            grouped.AllInnerDocuments.Count().Should().Be(2);
            grouped.AllInnerDocuments.Should().OnlyContain(x => new[] { _item.Inner.Value, _item2.Inner.Value }.Contains(x.Value));
        }
    }
}
