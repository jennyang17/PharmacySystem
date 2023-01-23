using PharmacyAPI.Models.Prescription;

namespace PharmacyAPI.Services.Interfaces
{
    public interface ICreatePrescriptionService
    {
        public PrescriptionResponse CreatePrescription(PrescriptionCreateRequest request);
    }
}
