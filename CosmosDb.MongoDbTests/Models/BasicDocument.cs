using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosDb.MongoDbTests.Models
{
    public class BasicDocument
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public int Value { get; set; }

        public BasicSubDocument Inner { get; set; }

        public List<string> StringArray { get; set; } = new List<string>();

        public List<int> IntArray { get; set; } = new List<int>();

        public List<BasicSubDocument> DocumentArray { get; set; } = new List<BasicSubDocument>();

        public static BasicDocument Generate(params Action<BasicDocument>[] overrides)
        {
            var built = new BasicDocument
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString("N"),
                Body = "Bacon ipsum dolor amet short loin qui officia, voluptate incididunt jerky ullamco kevin " +
                       "minim burgdoggen nisi turkey salami turducken. Sed qui est enim pariatur. Eiusmod sed cupim " +
                       "reprehenderit boudin et alcatra irure. Nostrud venison pastrami in pork chop, turducken shank " +
                       "ball tip ut incididunt biltong corned beef meatball pork loin. Short loin chuck ex leberkas " +
                       "capicola porchetta tongue ribeye ham labore cupim ball tip. Do consequat aliquip excepteur beef.",
                Value = new Random().Next(1, 100),
                Inner = BasicSubDocument.Generate(),
                StringArray = Enumerable.Range(0, 5).Select(x => Guid.NewGuid().ToString("N")).ToList(),
                IntArray = Enumerable.Range(0, 5).Select(x => new Random(x).Next(1, 100)).ToList(),
                DocumentArray = Enumerable.Range(0, 3).Select(x => BasicSubDocument.Generate()).ToList()
            };

            foreach (var or in overrides)
            {
                or(built);
            }

            return built;
        }
    }
}
