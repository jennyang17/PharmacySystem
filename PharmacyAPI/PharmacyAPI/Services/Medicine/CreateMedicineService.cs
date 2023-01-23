using PharmacyAPI.EF;
using PharmacyAPI.Models.Medicine;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Medicine
{
    public class CreateMedicineService : ICreateMedicineService
    {

        private PharmacyContext _context;

        public CreateMedicineService(PharmacyContext context)
        {
            _context = context;
        }

        public MedicineResponse CreateMedicine(MedicineCreateRequest request)
        {
            //Validation
            if(request == null)
            {
                throw new ArgumentException(nameof(request));
            }
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Invalid parameter " + nameof(request.Name));
            }
            if (string.IsNullOrEmpty(request.Formulation))
            {
                throw new ArgumentException("Invalid parameter " + nameof(request.Formulation));
            }
            if (string.IsNullOrEmpty(request.Strength))
            {
                throw new ArgumentException("Invalid parameter " + nameof(request.Strength));
            }

            EF.Medicine newMedicine = new EF.Medicine()
            {
                Formulation = request.Formulation,
                Name = request.Name,
                Strength = request.Strength
            };

            _context.Medicines.Add(newMedicine);

            _context.SaveChanges();

            MedicineResponse response = new MedicineResponse()
            {
                MedicineID = newMedicine.MedicineId,
                Name = newMedicine.Name,
                Strength = newMedicine.Strength,
                Formulation = newMedicine.Formulation,
            };

            return response;
        }
    }
}
