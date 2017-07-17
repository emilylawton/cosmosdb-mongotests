using System.Linq;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Aggregate
{
    public class ProjectArray : DatabaseTestFixture<BasicDocument>
    {
        private readonly EmptyPipelineDefinition<BasicDocument> _pl;
        private readonly BasicDocument _item;

        public ProjectArray(DatabaseType databaseType) : base(databaseType)
        {
            _pl = new EmptyPipelineDefinition<BasicDocument>();
            _item = BasicDocument.Generate();
            Insert(_item);
        }

        private static string ProjectToResult(string innerJson)
        {
            return $"{{ $project: {{ Result: {{ {innerJson} }} }} }}";
        }

        [Test]
        public void ArrayElemAt()
        {
            Aggregate(_pl.Project(x => new { Result = x.StringArray[1] }))
                .First()
                .Result.Should()
                .Be(_item.StringArray[1]);
        }

        // TODO $arrayToObject

        [Test]
        public void ConcatArrays()
        {
            Aggregate(_pl.Project(x => new { Result = x.IntArray.Concat(x.IntArray2) }))
                .First()
                .Result.Should()
                .HaveCount(_item.IntArray.Count + _item.IntArray2.Count);
        }

        [Test]
        public void Filter()
        {
            Aggregate(_pl.Project(x => new { Result = x.IntArray.Where(i => i == _item.IntArray[2]) }))
                .First()
                .Result.Should()
                .HaveCount(c => c > 0)
                .And
                .OnlyContain(i => i == _item.IntArray[2]);
        }

        [Test]
        public void In()
        {
            Aggregate(ProjectToResult($"$in: [ \"{_item.StringArray[3]}\", \"$StringArray\" ]"))
                .First()
                ["Result"].AsBoolean.Should()
                .Be(true);
        }

        [Test]
        public void IndexOfArray()
        {
            Aggregate(ProjectToResult($"$indexOfArray: [ \"$StringArray\", \"{_item.StringArray[1]}\" ]"))
                .First()
                ["Result"].AsInt32.Should()
                .Be(1);
        }

        [Test]
        public void IsArray()
        {
            Aggregate(ProjectToResult("$isArray: [ \"$StringArray\" ]"))
                .First()
                ["Result"].AsBoolean.Should()
                .Be(true);
        }

        [Test]
        public void Map()
        {
            Aggregate(_pl.Project(x => new { Result = x.IntArray.Select(s => s + 2) }))
                .First()
                .Result.Should()
                .HaveCount(_item.IntArray.Count);
        }

        // TODO: $objectToArray
//        [Test]
//        public void ObjectToArray()
//        {
//            Aggregate(ProjectToResult("$objectToArray: \"$Inner\""))
//                .First()
//                ["Result"]
//                .AsBsonArray.Should()
//                .HaveCount(1)
//                .And
//                .OnlyContain(x => x["v"].AsString == _item.Inner.Value);
//        }

        [Test]
        public void Range()
        {
            Aggregate(ProjectToResult("$range: [ 0, \"$Value\" ]"))
                .First()
                ["Result"]
                .AsBsonArray.Should()
                .HaveCount(_item.Value);
        }

        [Test]
        public void Reduce()
        {
            Aggregate(ProjectToResult("$reduce: { input: \"$IntArray\", initialValue: 0, in: { $add: [ \"$$value\", \"$$this\" ] } }"))
                .First()
                ["Result"].AsInt32.Should()
                .Be(_item.IntArray.Sum());
        }

        [Test]
        public void ReverseArray()
        {
            Aggregate(ProjectToResult("$reverseArray: \"$StringArray\""))
                .First()
                ["Result"]
                .AsBsonArray.First()
                .AsString
                .Should()
                .Be(_item.StringArray.Last());
        }

        [Test]
        public void Size()
        {
            Aggregate(_pl.Project(x => new { Result = x.StringArray.Count }))
                .First()
                .Result.Should()
                .Be(_item.StringArray.Count);
        }

        [Test]
        public void Slice()
        {
            Aggregate(_pl.Project(x => new { Result = x.StringArray.Skip(2).Take(1) }))
                .First()
                .Result.Should()
                .HaveCount(1);
        }

        // TODO: $zip
    }
}
