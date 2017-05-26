using System.Collections.Generic;
using System.Linq;
using CosmosDb.MongoDbTests.Extensions;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class AggregationPipelineTestFixture : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pipeline;

        public AggregationPipelineTestFixture(DatabaseType databaseType) : base(databaseType)
        {
            _pipeline = new EmptyPipelineDefinition<BasicDocument>();
        }

        [Test]
        public void Project()
        {
            Insert(BasicDocument.Generate(x => x.Name = "ABC123"));
            Aggregate(_pipeline.Project(x => new { x.Name }))
                .First().Name.Should().Be("ABC123");
        }

        [Test]
        public void Match()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            Aggregate(_pipeline.Match(x => x.Name == item.Name))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void Limit()
        {
            Insert(BasicDocument.Generate(), BasicDocument.Generate(), BasicDocument.Generate());
            Aggregate(_pipeline.Limit(2)).Should().HaveCount(2);
        }

        [Test]
        public void Skip()
        {
            Insert(BasicDocument.Generate(), BasicDocument.Generate(), BasicDocument.Generate());
            Aggregate(_pipeline.Skip(1)).Should().HaveCount(2);
        }

        [Test]
        public void Unwind()
        {
            var item = BasicDocument.Generate();
            Insert(item);

            var result = Aggregate(_pipeline.Unwind(x => x.StringArray));
            result.Should().HaveCount(item.StringArray.Count);
            result.Should().OnlyContain(x => item.StringArray.Contains(x["StringArray"].AsString));
        }

        [Test]
        public void Sort()
        {
            var item = BasicDocument.Generate();
            var item2 = BasicDocument.Generate();
            Insert(item, item2);

            var expected = new[] {item, item2}.OrderBy(x => x.Name);
            var result = Aggregate(_pipeline.Sort(new JsonSortDefinition<BasicDocument>("{\"Name\": 1}")));

            result.Should().HaveCount(2);
            result.First().Name.Should().Be(expected.First().Name);
        }

        [Test]
        public void Sample()
        {
            Insert(BasicDocument.Generate(), BasicDocument.Generate(), BasicDocument.Generate());
            var result = Aggregate(_pipeline.Json<BasicDocument, BasicDocument>("{ \"$sample\": { size: 2 } }"));
            result.Should().HaveCount(2);
        }

        [Test]
        public void Count()
        {
            Insert(BasicDocument.Generate(), BasicDocument.Generate(), BasicDocument.Generate());
            var result = Aggregate(_pipeline.Count());
            result.First().Count.Should().Be(3);
        }
    }
}
