using Core.Entities;

namespace Core.Aggregates
{
    public record Indication(Prescriber Prescriber, PatientPrescriptions[] indications);
}
