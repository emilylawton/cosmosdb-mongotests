using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class ProjectBoolean : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pipeline;

        public ProjectBoolean(DatabaseType databaseType) : base(databaseType)
        {
            _pipeline = new EmptyPipelineDefinition<BasicDocument>();
            Insert(BasicDocument.Generate(x => x.Value = 100, x => x.Name = "ABC123"));
        }

        [Test]
        public void And()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value > 50 && x.Value > 75 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Not()
        {
            Aggregate(_pipeline.Project(x => new { Result = !(x.Value > 50) }))
                .Should().Contain(x => !x.Result);
        }

        [Test]
        public void Or()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value > 50 || x.Value < 2 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Eq()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Name == "ABC123" }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Ne()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Name != "ABC123" }))
                .Should().Contain(x => !x.Result);
        }

        [Test]
        public void Gt()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value > 99 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Gte()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value >= 100 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Lt()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value < 101 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Lte()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value <= 100 }))
                .Should().Contain(x => x.Result);
        }
    }
}
