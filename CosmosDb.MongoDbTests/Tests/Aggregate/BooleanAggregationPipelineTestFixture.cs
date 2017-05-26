using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class BooleanAggregationPipelineTestFixture : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pipeline;

        public BooleanAggregationPipelineTestFixture(DatabaseType databaseType) : base(databaseType)
        {
            _pipeline = new EmptyPipelineDefinition<BasicDocument>();
        }

        [Test]
        public void Project_Boolean_And()
        {
            Insert(BasicDocument.Generate(x => x.Value = 100));
            Aggregate(_pipeline.Project(x => new { Result = x.Value > 50 && x.Value > 75 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Project_Boolean_Not()
        {
            Insert(BasicDocument.Generate(x => x.Value = 100));
            Aggregate(_pipeline.Project(x => new { Result = !(x.Value > 50) }))
                .Should().Contain(x => !x.Result);
        }

        [Test]
        public void Project_Boolean_Or()
        {
            Insert(BasicDocument.Generate(x => x.Value = 100));
            Aggregate(_pipeline.Project(x => new { Result = x.Value > 50 || x.Value < 2 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Project_Boolean_Eq()
        {
            Insert(BasicDocument.Generate(x => x.Name = "ABC123"));
            Aggregate(_pipeline.Project(x => new { Result = x.Name == "ABC123" }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Project_Boolean_Ne()
        {
            Insert(BasicDocument.Generate(x => x.Name = "ABC123"));
            Aggregate(_pipeline.Project(x => new { Result = x.Name != "ABC123" }))
                .Should().Contain(x => !x.Result);
        }

        [Test]
        public void Project_Boolean_Gt()
        {
            Insert(BasicDocument.Generate(x => x.Value = 51));
            Aggregate(_pipeline.Project(x => new { Result = x.Value > 50 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Project_Boolean_Gte()
        {
            Insert(BasicDocument.Generate(x => x.Value = 50));
            Aggregate(_pipeline.Project(x => new { Result = x.Value >= 50 }))
                .Should().Contain(x => x.Result);
        }

        [Test]
        public void Project_Boolean_Lt()
        {
            Insert(BasicDocument.Generate(x => x.Value = 50));
            Aggregate(_pipeline.Project(x => new { Result = x.Value < 50 }))
                .Should().Contain(x => !x.Result);
        }

        [Test]
        public void Project_Boolean_Lte()
        {
            Insert(BasicDocument.Generate(x => x.Value = 49));
            Aggregate(_pipeline.Project(x => new { Result = x.Value < 50 }))
                .Should().Contain(x => x.Result);
        }
    }
}
