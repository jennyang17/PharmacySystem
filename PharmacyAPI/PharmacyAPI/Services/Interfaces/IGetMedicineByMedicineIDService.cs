using PharmacyAPI.Models.Medicine;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IGetMedicineByMedicineIDService
    {
        MedicineResponse GetMedicineByMedicineID(int medicineID);
    }
}
