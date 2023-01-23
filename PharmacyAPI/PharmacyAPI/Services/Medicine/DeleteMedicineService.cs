using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Medicine
{
    public class DeleteMedicineService : IDeleteMedicineService
    {
        private PharmacyContext _context;
        public DeleteMedicineService(PharmacyContext context)
        {
            _context= context;
        }

        public void DeleteMedicine(int medicineID)
        {
            var result = _context.Medicines.FirstOrDefault(m => m.MedicineId == medicineID);

            if(result == null)
            {
                throw new NotFoundException($"Unable to find medicine with id {medicineID}");
            }

            result.IsDeleted = true;
            _context.SaveChanges();

        } 
    }
}
