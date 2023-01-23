using PharmacyAPI.Models.Medicine;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IGetMedicineByPatientID
    {
        public List<MedicineResponse> GetMedicineByPatientIDMethod(int patientID);
    }
}
