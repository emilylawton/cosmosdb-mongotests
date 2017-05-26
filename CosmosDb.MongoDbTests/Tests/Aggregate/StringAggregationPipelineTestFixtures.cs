using System.Linq;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class StringAggregationPipelineTestFixture : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pipeline;

        public StringAggregationPipelineTestFixture(DatabaseType databaseType) : base(databaseType)
        {
            _pipeline = new EmptyPipelineDefinition<BasicDocument>();
        }

        [Test]
        public void Project_String_Concat()
        {
            Insert(BasicDocument.Generate(x => x.Name = "A", x => x.Body = "1"));
            Aggregate(_pipeline.Project(x => new { Result = x.Name + ":" + x.Body }))
                .First().Result.Should().Be("A:1");
        }

        [Test]
        public void Project_String_IndexOf()
        {
            Insert(BasicDocument.Generate(x => x.Name = "A", x => x.Body = "1A1"));
            Aggregate(_pipeline.Project(x => new { Result = x.Body.IndexOf(x.Name) }))
                .First().Result.Should().Be(1);
        }

        [Test]
        public void Project_String_Split()
        {
            Insert(BasicDocument.Generate(x => x.Name = "A.B.C"));
            Aggregate(_pipeline.Project(x => new { Result = x.Name.Split('.') }))
                .First().Result.Should().HaveCount(3).And.ContainInOrder("A", "B", "C");
        }

        [Test]
        public void Project_String_StringLength()
        {
            Insert(BasicDocument.Generate(x => x.Name = "A.B.C"));
            Aggregate(_pipeline.Project(x => new { Result = x.Name.Length }))
                .First().Result.Should().Be(5);
        }

        [Test]
        public void Project_String_Substring()
        {
            Insert(BasicDocument.Generate(x => x.Name = "ABCDE"));
            Aggregate(_pipeline.Project(x => new { Result = x.Name.Substring(0, 3) }))
                .First().Result.Should().Be("ABC");
        }

        [Test]
        public void Project_String_ToLower()
        {
            Insert(BasicDocument.Generate(x => x.Name = "ABCDE"));
            Aggregate(_pipeline.Project(x => new { Result = x.Name.ToLower() }))
                .First().Result.Should().Be("abcde");
        }

        [Test]
        public void Project_String_ToUpper()
        {
            Insert(BasicDocument.Generate(x => x.Name = "abcde"));
            Aggregate(_pipeline.Project(x => new { Result = x.Name.ToUpper() }))
                .First().Result.Should().Be("ABCDE");
        }
    }
}
