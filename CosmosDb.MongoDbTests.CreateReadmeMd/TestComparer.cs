using System.Collections.Generic;
using System.Linq;

namespace CosmosDb.MongoDbTests.CreateReadmeMd
{
    public class TestComparer
    {
        private const string NATIVE_MONGO = "NativeMongoDb";
        private const string AZURE_COSMOS = "AzureCosmosDb";

        public static List<TestComparisonGroup> Compare(Dictionary<TestSuite, List<Test>> raw)
        {
            return raw.GroupBy(x => x.Key.Name)
                .Select(x => new TestComparisonGroup
                {
                    Name = x.Key,
                    Tests = CompareGroups(x.ToList())
                })
                .ToList();
        }

        private static List<TestComparison> CompareGroups(List<KeyValuePair<TestSuite, List<Test>>> testSuites)
        {
            var native = testSuites.First(x => x.Key.Type == NATIVE_MONGO).Value;
            var cosmos = testSuites.First(x => x.Key.Type == AZURE_COSMOS).Value;
            return native.Select((test, i) => TestComparison.Parse(test, cosmos[i])).ToList();
        }
    }
}
