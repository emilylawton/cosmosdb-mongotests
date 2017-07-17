using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CosmosDb.MongoDbTests.CreateReadmeMd
{
    public class XmlTestParser
    {
        private static readonly Regex TestName = new Regex("^([0-9a-z]+)\\(([0-9a-z]+)\\)$", RegexOptions.IgnoreCase);

        public static Dictionary<TestSuite, List<Test>> Parse(XDocument doc)
        {
            return Parse(doc.Element("test-run"));
        }

        private static Dictionary<TestSuite, List<Test>> Parse(XElement element)
        {
            var suites = element.Elements("test-suite");
            var dict = suites.SelectMany(Parse).ToDictionary(x => x.Key, x => x.Value);
            var tests = element.Elements("test-case").ToList();
            if (tests.Count <= 0) return dict;

            var name = element.Attribute("name")?.Value ?? "Unknown()";
            var parsedTests = tests.Select(ParseTest).ToList();
            dict.Add(GetDescriptor(name), parsedTests);
            return dict;
        }

        private static Test ParseTest(XElement element)
        {
            return new Test
            {
                Passed = element.Attribute("result")?.Value == "Passed",
                Name = element.Attribute("name")?.Value,
                Query = element.Element("output")?.Value
            };
        }

        private static TestSuite GetDescriptor(string fullName)
        {
            var result = TestName.Match(fullName);
            return new TestSuite
            {
                Name = result.Groups[1].Value,
                Type = result.Groups[2].Value
            };
        }
    }
}