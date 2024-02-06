using Core.Aggregates;
using Core.Entities;
using Core.Repsositories;
using Cosmos.Abstracts;
using Infrastructure.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;

namespace Infrastructure.Repositories
{
    public class IndicationRepository : CosmosRepository<IndicationDBEntity>, IIndicationRepostory
    {
        public IndicationRepository(ILoggerFactory logFactory, IOptions<CosmosRepositoryOptions> repositoryOptions, ICosmosFactory databaseFactory) : base(logFactory, repositoryOptions, databaseFactory)
        {
        }

        public async Task<Indication> Create(Indication indication)
        {
            var entity = new IndicationDBEntity
            {
                Indication = indication
            };

            var container = await GetContainerAsync();
            var result = await container.CreateItemAsync(entity);

            return indication;
        }

        public Task Delete(Indication indication)
        {
            throw new NotImplementedException();
        }

        public Task<Indication[]> GetIndications()
        {
            throw new NotImplementedException();
        }
    }
}
