using System;

namespace CosmosDb.MongoDbTests.Models
{
    public class BasicSubDocument
    {
        public string Value { get; set; }

        public static BasicSubDocument Generate()
        {
            return new BasicSubDocument
            {
                Value = Guid.NewGuid().ToString("N")
            };
        }
    }
}