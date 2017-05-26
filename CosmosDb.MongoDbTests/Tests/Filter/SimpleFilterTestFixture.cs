using System.Linq;
using CosmosDb.MongoDbTests.Extensions;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;

namespace CosmosDb.MongoDbTests.Tests.Filter
{
    public class SimpleFilterTestFixture : DatabaseTestFixture<BasicDocument>
    {
        public SimpleFilterTestFixture(DatabaseType databaseType) : base(databaseType)
        {
        }

        [Test]
        public void Eq_TopLevel()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            Find(new FilterDefinitionBuilder<BasicDocument>().Eq(x => x.Name, item.Name))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void Eq_SubDocument()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            Find(new FilterDefinitionBuilder<BasicDocument>().Eq(x => x.Inner.Value, item.Inner.Value))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void Eq_ArrayOfSubDocuments()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            Find($"{{\"{nameof(BasicDocument.DocumentArray)}.{nameof(BasicSubDocument.Value)}\":\"{item.DocumentArray[0].Value}\"}}")
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void Ne_TopLevel()
        {
            var item = BasicDocument.Generate();
            var item2 = BasicDocument.Generate();
            Insert(item, item2);

            Find(new FilterDefinitionBuilder<BasicDocument>().Ne(x => x.Name, item.Name))
                .ShouldHaveOneResultMatching(item2);
        }

        [Test]
        public void NotEq_TopLevel()
        {
            var item = BasicDocument.Generate();
            var item2 = BasicDocument.Generate();
            Insert(item, item2);

            var fb = new FilterDefinitionBuilder<BasicDocument>();
            Find(fb.Not(fb.Eq(x => x.Name, item.Name)))
                .ShouldHaveOneResultMatching(item2);
        }

        // TODO: Near
        // TODO: NearSphere

        [Test]
        public void Regex_TopLevel()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            Find(new FilterDefinitionBuilder<BasicDocument>().Regex(x => x.Name,
                new BsonRegularExpression("^" + item.Name.Substring(0, 10))))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void Regex_SubDocument()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            Find(new FilterDefinitionBuilder<BasicDocument>().Regex(x => x.Inner.Value,
                new BsonRegularExpression("^" + item.Inner.Value.Substring(0, 10))))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void Regex_ArrayOfSubDocument()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            Find($"{{\"{nameof(BasicDocument.DocumentArray)}.{nameof(BasicSubDocument.Value)}\":/^{item.DocumentArray[0].Value.Substring(0, 10)}/}}")
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void And()
        {
            var item = BasicDocument.Generate();
            Insert(item, BasicDocument.Generate());

            var fb = new FilterDefinitionBuilder<BasicDocument>();
            Find(fb.And(fb.Eq(x => x.Id, item.Id), fb.Eq(x => x.Name, item.Name)))
                .ShouldHaveOneResultMatching(item);
        }

        [Test]
        public void Or()
        {
            var item = BasicDocument.Generate();
            var item2 = BasicDocument.Generate();
            Insert(item, item2);

            var fb = new FilterDefinitionBuilder<BasicDocument>();
            var result = Find(fb.Or(fb.Eq(x => x.Id, item.Id), fb.Eq(x => x.Id, item2.Id)));

            result.Count.Should().Be(2);
            result.Should().Contain(x => x.Id == item.Id);
            result.Should().Contain(x => x.Id == item2.Id);
        }
    }
}
