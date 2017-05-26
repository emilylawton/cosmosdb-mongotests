using MongoDB.Driver;

namespace CosmosDb.MongoDbTests.Extensions
{
    public static class PipelineDefinitionExtensions
    {
        public static PipelineDefinition<TIn, TOut> Json<TIn, TOut>(this PipelineDefinition<TIn, TIn> pipeline, string json)
        {
            return pipeline.AppendStage(new JsonPipelineStageDefinition<TIn, TOut>(json));
        }
    }
}