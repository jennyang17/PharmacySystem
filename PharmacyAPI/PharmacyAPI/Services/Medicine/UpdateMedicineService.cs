using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Medicine;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Medicine
{
    public class UpdateMedicineService : IUpdateMedicineService
    {
        public UpdateMedicineService()
        {

        }

        public MedicineResponse UpdateMedicine(MedicineUpdateRequest request)
        {
            PharmacyContext context = new PharmacyContext();
            EF.Medicine result = context.Medicines.FirstOrDefault(m => m.MedicineId == request.MedicineID);

            if (result == null)
            {
                throw new NotFoundException($"Unable to find medicine with id {request.MedicineID}");
            }

            result.MedicineId = request.MedicineID;
            result.Name = request.Name;
            result.Strength = request.Strength;
            result.Formulation = request.Formulation;
            context.SaveChanges();

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
