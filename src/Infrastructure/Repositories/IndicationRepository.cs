using Core.Aggregates;
using Core.Repsositories;

namespace Infrastructure.Repositories
{
    public class IndicationRepository : IIndicationRepostory
    {
        public Task<Indication> Create(Indication indication)
        {
            throw new NotImplementedException();
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
