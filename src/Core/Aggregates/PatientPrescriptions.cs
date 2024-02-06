using Core.Entities;

namespace Core.Aggregates
{
    public record PatientPrescriptions(Patient Patient, Prescription[] Prescriptions);
}
