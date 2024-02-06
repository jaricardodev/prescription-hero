using Core.Aggregates;

namespace Core.Services
{
    public interface IIndicationsService
    {
        Task<Indication> PrescribeIndication(Indication indication);

        Task CancelIndication(Indication indication);

        Task<Indication[]> ShowIndications();
    }
}
