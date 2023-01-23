using PharmacyAPI.Models.Prescription;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IUpdatePrescriptionService
    {
        public PrescriptionResponse UpdatePrescription(PrescriptionUpdateRequest request);
    }
}
