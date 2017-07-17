using System;
using CosmosDb.MongoDbTests.Extensions;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class ProjectArithmetic : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pipeline;

        public ProjectArithmetic(DatabaseType databaseType) : base(databaseType)
        {
            _pipeline = new EmptyPipelineDefinition<BasicDocument>();
            Insert(BasicDocument.Generate(x => x.Value = 10));
        }

        [Test]
        public void Abs()
        {
            Aggregate(_pipeline.Project(x => new {Result = Math.Abs(x.Value)}))
                .Should().Contain(x => x.Result == 10);
        }

        [Test]
        public void Add()
        {
            Aggregate(_pipeline.Project(x => new {Result = x.Value + 5}))
                .Should().Contain(x => x.Result == 15);
        }

        [Test]
        public void Ceiling()
        {
            Aggregate(_pipeline.Project(x => new {Result = Math.Ceiling(x.Value + 8.75f)}))
                .Should().Contain(x => x.Result == 19f);
        }

        [Test]
        public void Floor()
        {
            Aggregate(_pipeline.Project(x => new {Result = Math.Floor(x.Value + 8.75f)}))
                .Should().Contain(x => x.Result == 18f);
        }

        [Test]
        public void Divide()
        {
            Aggregate(_pipeline.Project(x => new {Result = x.Value / 2}))
                .Should().Contain(x => x.Result == 5);
        }

        [Test]
        public void Exp()
        {
            Aggregate(_pipeline.Project(x => new {Result = Math.Exp(x.Value)}))
                .Should().Contain(x => x.Result == Math.Exp(10));
        }

        [Test]
        public void Project_Arithmetic_Log()
        {
            Aggregate(_pipeline.Project(x => new {Result = Math.Log(x.Value)}))
                .Should().Contain(x => x.Result == Math.Log(10));
        }

        [Test]
        public void Log10()
        {
            Aggregate(_pipeline.Project(x => new {Result = Math.Log10(x.Value)}))
                .Should().Contain(x => x.Result == Math.Log10(10));
        }

        [Test]
        public void Ln()
        {
            Aggregate(_pipeline.Json<BasicDocument, BsonDocument>("{ $project: { _id:0, Result: { $ln: \"$Value\" } } }"))
                .Should().Contain(x => x["Result"].AsDouble == Math.Log(10, Math.E));
        }

        [Test]
        public void Mod()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value % 3 }))
                .Should().Contain(x => x.Result == 1);
        }

        [Test]
        public void Multiply()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value * 3 }))
                .Should().Contain(x => x.Result == 30);
        }

        [Test]
        public void Pow()
        {
            Aggregate(_pipeline.Project(x => new { Result = Math.Pow(x.Value, 2) }))
                .Should().Contain(x => x.Result == Math.Pow(10, 2));
        }

        [Test]
        public void Sqrt()
        {
            Aggregate(_pipeline.Project(x => new { Result = Math.Sqrt(x.Value) }))
                .Should().Contain(x => x.Result == Math.Sqrt(10));
        }

        [Test]
        public void Subtract()
        {
            Aggregate(_pipeline.Project(x => new { Result = x.Value - 5 }))
                .Should().Contain(x => x.Result == 5);
        }

        [Test]
        public void Trunc()
        {
            Aggregate(_pipeline.Project(x => new { Result = Math.Truncate((float)x.Value) }))
                .Should().Contain(x => x.Result == Math.Truncate(10f));
        }
    }
}
