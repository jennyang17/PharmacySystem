using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Medicine;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Medicine
{
    public class GetMedicineByMedicineIDService : IGetMedicineByMedicineIDService
    {
        private PharmacyContext _context;
        public GetMedicineByMedicineIDService(PharmacyContext context)
        {
            _context= context;
        }

        public MedicineResponse GetMedicineByMedicineID(int medicineID)
        {
            EF.Medicine? result = _context.Medicines.FirstOrDefault(m => m.MedicineId == medicineID && !m.IsDeleted);

            
            if(result == null)
            {
                throw new NotFoundException($"Unable to find medicine with id {medicineID}");
            }

            MedicineResponse response = new MedicineResponse()
            {
                MedicineID = result.MedicineId,
                Name = result.Name,
                Strength = result.Strength,
                Formulation = result.Formulation
            };
            return response;
        }
    }
}
