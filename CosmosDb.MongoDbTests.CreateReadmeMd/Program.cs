using System;
using System.IO;
using System.Xml.Linq;

namespace CosmosDb.MongoDbTests.CreateReadmeMd
{
    class Program
    {
        private const string Filename = "TestResult.xml";

        static void Main()
        {
            if (!File.Exists(Filename))
            {
                Console.WriteLine($"Cannot find file `{Filename}` in working directory");
                return;
            }
            
            var raw = XmlTestParser.Parse(XDocument.Load(Filename));
            MarkdownReporter.Report("README.md", TestComparer.Compare(raw));
        }
    }
}
