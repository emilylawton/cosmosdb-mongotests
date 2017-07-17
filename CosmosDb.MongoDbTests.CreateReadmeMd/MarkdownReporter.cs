using System.Collections.Generic;
using System.IO;

namespace CosmosDb.MongoDbTests.CreateReadmeMd
{
    public class MarkdownReporter
    {
        public static void Report(string filename, List<TestComparisonGroup> suites)
        {
            using (var fs = File.Open(filename, FileMode.Create, FileAccess.Write))
            using (var wr = new StreamWriter(fs))
            {
                // Tables
                foreach (var suite in suites)
                {
                    wr.WriteLine($"#### {suite.Name}");
                    wr.WriteLine("Test | Native | Cosmos | Query");
                    wr.WriteLine("--- | :---: | :---: | ---");
                    foreach (var test in suite.Tests)
                    {
                        wr.WriteLine($"{test.Name} | {GetIcon(test.NativePassed)} | {GetIcon(test.CosmosPassed)} | {test.Query}");
                    }
                    wr.WriteLine("<br/>");
                }
            }
        }

        private static string GetIcon(bool pass)
        {
            return $"![{(pass ? "Pass" : "Fail")}](/CosmosDb.MongoDbTests.CreateReadmeMd/" +
                   $"{(pass ? "pass" : "fail")}.png?raw=true)";
        }
    }
}
