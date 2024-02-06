using Core.Aggregates;

namespace Core.Repsositories
{
    public interface IIndicationRepostory
    {
        Task<Indication> Create(Indication indication);

        Task Delete(Indication indication);

        Task<Indication[]> GetIndications();
    }
}
