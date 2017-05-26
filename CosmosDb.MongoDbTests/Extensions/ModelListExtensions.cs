using System.Collections.Generic;
using System.Linq;
using CosmosDb.MongoDbTests.Models;
using FluentAssertions;

namespace CosmosDb.MongoDbTests.Extensions
{
    public static class ModelListExtensions
    {
        public static void ShouldHaveOneResultMatching(this List<BasicDocument> result, BasicDocument expected)
        {
            result.Should().HaveCount(1);
            result.First().Id.Should().Be(expected.Id);
        }
    }
}
