using PharmacyAPI.Models.Prescription;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IGetPrescriptionByPatientID
    {
        public List<PrescriptionResponse> GetPrescriptionsByPatientIDMethod(int patientID);
    }
}
