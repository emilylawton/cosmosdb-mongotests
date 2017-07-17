using System.Collections.Generic;

namespace CosmosDb.MongoDbTests.CreateReadmeMd
{
    public class TestComparison
    {
        public string Name { get; set; }
        public string Query { get; set; }
        public bool NativePassed { get; set; }
        public bool CosmosPassed { get; set; }

        public static TestComparison Parse(Test native, Test cosmos)
        {
            return new TestComparison
            {
                Name = native.Name,
                Query = native.Query,
                CosmosPassed = cosmos.Passed,
                NativePassed = native.Passed
            };
        }
    }

    public class TestComparisonGroup
    {
        public string Name { get; set; }

        public List<TestComparison> Tests = new List<TestComparison>();
    }
}