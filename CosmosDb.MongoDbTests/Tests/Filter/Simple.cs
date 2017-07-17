using System.Linq;
using System.Text.RegularExpressions;
using CosmosDb.MongoDbTests.Extensions;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Filter
{
    public class Simple : DatabaseTestFixture<BasicDocument>
    {
        private readonly BasicDocument _item;
        private readonly BasicDocument _item2;

        public Simple(DatabaseType databaseType) : base(databaseType)
        {
            _item = BasicDocument.Generate();
            _item2 = BasicDocument.Generate();
            Insert(_item, _item2);
        }

        [Test]
        public void Eq_TopLevel()
        {

            Find(new FilterDefinitionBuilder<BasicDocument>().Eq(x => x.Name, _item.Name))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void Eq_SubDocument()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().Eq(x => x.Inner.Value, _item.Inner.Value))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void Eq_ArrayOfSubDocuments()
        {
            Find(new ExpressionFilterDefinition<BasicDocument>(x => 
                x.DocumentArray.Any(sd => sd.Value == _item.DocumentArray[0].Value)))
                    .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void Ne_TopLevel()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().Ne(x => x.Name, _item.Name))
                .ShouldHaveOneResultMatching(_item2);
        }

        [Test]
        public void NotEq_TopLevel()
        {
            var fb = new FilterDefinitionBuilder<BasicDocument>();
            Find(fb.Not(fb.Eq(x => x.Name, _item.Name)))
                .ShouldHaveOneResultMatching(_item2);
        }

        // TODO: Near
        // TODO: NearSphere

        [Test]
        public void Regex_TopLevel()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().Regex(x => x.Name,
                new BsonRegularExpression("^" + _item.Name.Substring(0, 10))))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void Regex_SubDocument()
        {
            Find(new FilterDefinitionBuilder<BasicDocument>().Regex(x => x.Inner.Value,
                new BsonRegularExpression("^" + _item.Inner.Value.Substring(0, 10))))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void Regex_ArrayOfSubDocument()
        {
            var regex = new Regex("^" + _item.DocumentArray[0].Value.Substring(0, 10));
            Find(new ExpressionFilterDefinition<BasicDocument>(x => 
                x.DocumentArray.Any(sd => regex.IsMatch(sd.Value))))
                    .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void And()
        {
            var fb = new FilterDefinitionBuilder<BasicDocument>();
            Find(fb.And(fb.Eq(x => x.Id, _item.Id), fb.Eq(x => x.Name, _item.Name)))
                .ShouldHaveOneResultMatching(_item);
        }

        [Test]
        public void Or()
        {
            var fb = new FilterDefinitionBuilder<BasicDocument>();
            var result = Find(fb.Or(fb.Eq(x => x.Id, _item.Id), fb.Eq(x => x.Id, _item2.Id)));

            result.Count.Should().Be(2);
            result.Should().Contain(x => x.Id == _item.Id);
            result.Should().Contain(x => x.Id == _item2.Id);
        }
    }
}
