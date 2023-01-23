using PharmacyAPI.Models.Medicine;

namespace PharmacyAPI.Services.Interfaces
{
    public interface ICreateMedicineService
    {
        MedicineResponse CreateMedicine(MedicineCreateRequest request);
    }
}
