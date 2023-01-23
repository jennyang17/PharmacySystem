using PharmacyAPI.Models.Medicine;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IUpdateMedicineService
    {
        public MedicineResponse UpdateMedicine(MedicineUpdateRequest request);
    }
}
