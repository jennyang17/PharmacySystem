using PharmacyAPI.Models.Prescription;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IGetPrescriptionByPrescriptionID
    {
        public PrescriptionResponse GetPrescriptionByID(int prescriptionID);
    }
}
