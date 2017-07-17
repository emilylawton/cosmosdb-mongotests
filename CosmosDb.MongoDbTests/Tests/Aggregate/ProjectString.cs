using System.Linq;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class ProjectString : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pl;

        public ProjectString(DatabaseType databaseType) : base(databaseType)
        {
            _pl = new EmptyPipelineDefinition<BasicDocument>();
            Insert(BasicDocument.Generate(x => x.Name = "A.b.C", x => x.Body = "1"));
        }

        [Test]
        public void Concat()
        {
            Aggregate(_pl.Project(x => new { Result = x.Name + ":" + x.Body }))
                .First().Result.Should().Be("A.b.C:1");
        }

        [Test]
        public void IndexOf()
        {
            Aggregate(_pl.Project(x => new { Result = x.Name.IndexOf("b") }))
                .First().Result.Should().Be(2);
        }

        [Test]
        public void Split()
        {
            Aggregate(_pl.Project(x => new { Result = x.Name.Split('.') }))
                .First().Result.Should().HaveCount(3).And.ContainInOrder("A", "b", "C");
        }

        [Test]
        public void StringLength()
        {
            Aggregate(_pl.Project(x => new { Result = x.Name.Length }))
                .First().Result.Should().Be(5);
        }

        [Test]
        public void Substring()
        {
            Aggregate(_pl.Project(x => new { Result = x.Name.Substring(0, 3) }))
                .First().Result.Should().Be("A.b");
        }

        [Test]
        public void ToLower()
        {
            Aggregate(_pl.Project(x => new { Result = x.Name.ToLower() }))
                .First().Result.Should().Be("a.b.c");
        }

        [Test]
        public void ToUpper()
        {
            Aggregate(_pl.Project(x => new { Result = x.Name.ToUpper() }))
                .First().Result.Should().Be("A.B.C");
        }
    }
}
