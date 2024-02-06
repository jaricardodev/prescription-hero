using Core.Aggregates;
using Cosmos.Abstracts;

namespace Infrastructure.Entities
{
    public class IndicationDBEntity : CosmosEntity
    {
        public required Indication Indication { get; set; }
    }
}
