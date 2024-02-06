using Core.Entities;

namespace Core.Aggregates
{
    public record PatientPrescription(Patient Patient, Prescription Prescription);
}
