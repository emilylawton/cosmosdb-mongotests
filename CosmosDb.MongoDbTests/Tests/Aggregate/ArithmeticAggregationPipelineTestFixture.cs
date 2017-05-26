using System;
using CosmosDb.MongoDbTests.Extensions;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class ArithmeticAggregationPipelineTestFixture : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pipeline;

        public ArithmeticAggregationPipelineTestFixture(DatabaseType databaseType) : base(databaseType)
        {
            _pipeline = new EmptyPipelineDefinition<BasicDocument>();
        }

        [Test]
        public void Project_Arithmetic_Abs()
        {
            Insert(BasicDocument.Generate(x => x.Value = -10));
            Aggregate(_pipeline.Project(x => new {Result = Math.Abs(x.Value)}))
                .Should().Contain(x => x.Result == 10);
        }

        [Test]
        public void Project_Arithmetic_Add()
        {
            Insert(BasicDocument.Generate(x => x.Value = 8));
            Aggregate(_pipeline.Project(x => new {Result = x.Value + 5}))
                .Should().Contain(x => x.Result == 13);
        }

        [Test]
        public void Project_Arithmetic_Ceiling()
        {
            Insert(BasicDocument.Generate(x => x.Value = 0));
            Aggregate(_pipeline.Project(x => new {Result = Math.Ceiling(x.Value + 8.75f)}))
                .Should().Contain(x => x.Result == 9f);
        }

        [Test]
        public void Project_Arithmetic_Floor()
        {
            Insert(BasicDocument.Generate(x => x.Value = 0));
            Aggregate(_pipeline.Project(x => new {Result = Math.Floor(x.Value + 8.75f)}))
                .Should().Contain(x => x.Result == 8f);
        }

        [Test]
        public void Project_Arithmetic_Divide()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new {Result = x.Value / 2}))
                .Should().Contain(x => x.Result == 5);
        }

        [Test]
        public void Project_Arithmetic_Exp()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new {Result = Math.Exp(x.Value)}))
                .Should().Contain(x => x.Result == Math.Exp(10));
        }

        [Test]
        public void Project_Arithmetic_Log()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new {Result = Math.Log(x.Value)}))
                .Should().Contain(x => x.Result == Math.Log(10));
        }

        [Test]
        public void Project_Arithmetic_Log10()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new {Result = Math.Log10(x.Value)}))
                .Should().Contain(x => x.Result == Math.Log10(10));
        }

        [Test]
        public void Project_Arithmetic_Ln()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Json<BasicDocument, BsonDocument>("{ $project: { _id:0, Result: { $ln: \"$Value\" } } }"))
                .Should().Contain(x => x["Result"].AsDouble == Math.Log(10, Math.E));
        }

        [Test]
        public void Project_Arithmetic_Mod()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new { Result = x.Value % 3 }))
                .Should().Contain(x => x.Result == 1);
        }

        [Test]
        public void Project_Arithmetic_Multiply()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new { Result = x.Value * 3 }))
                .Should().Contain(x => x.Result == 30);
        }

        [Test]
        public void Project_Arithmetic_Pow()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new { Result = Math.Pow(x.Value, 2) }))
                .Should().Contain(x => x.Result == Math.Pow(10, 2));
        }

        [Test]
        public void Project_Arithmetic_Sqrt()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new { Result = Math.Sqrt(x.Value) }))
                .Should().Contain(x => x.Result == Math.Sqrt(10));
        }

        [Test]
        public void Project_Arithmetic_Subtract()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new { Result = x.Value - 5 }))
                .Should().Contain(x => x.Result == 5);
        }

        [Test]
        public void Project_Arithmetic_Trunc()
        {
            Insert(BasicDocument.Generate(x => x.Value = 10));
            Aggregate(_pipeline.Project(x => new { Result = Math.Truncate((float)x.Value) }))
                .Should().Contain(x => x.Result == Math.Truncate(10f));
        }
    }
}
