using Core.Aggregates;
using Core.Services;

namespace Application.Services
{
    public class IndicationService : IIndicationsService
    {
        public Task CancelIndication(Indication indication)
        {
            throw new NotImplementedException();
        }

        public Task<Indication> PrescribeIndication(Indication indication)
        {
            throw new NotImplementedException();
        }

        public Task<Indication[]> ShowIndications()
        {
            throw new NotImplementedException();
        }
    }
}
