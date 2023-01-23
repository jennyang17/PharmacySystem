using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Medicine;
using PharmacyAPI.Models.Prescription;
using PharmacyAPI.Services.Interfaces;
using System.Linq;

namespace PharmacyAPI.Services.Medicine
{
    public class GetMedicineByPatientID : IGetMedicineByPatientID
    {
        private PharmacyContext _context;
        public GetMedicineByPatientID(PharmacyContext context)
        {
            _context = context;
        }

        public List<MedicineResponse> GetMedicineByPatientIDMethod(int patientID)
        {
            
            List<EF.Prescription> result = 
                _context.Prescriptions
                .Include(pi => pi.PrescriptionItems)
                .ThenInclude(m => m.Medicine)
                .Where(pi => pi.PatientId == patientID 
                    && !pi.IsDeleted && !pi.Patient.IsDeleted)
                .ToList();

            if(result == null || result.Count == 0)
            {
                throw new NotFoundException($"Unable to find patient with id {patientID}");
            }


            List<EF.Medicine> medicines = result.SelectMany(s => s.PrescriptionItems.Select(x => x.Medicine)).ToList();
            List<MedicineResponse> responses = new List<MedicineResponse>();
            
            foreach (EF.Medicine medicine in medicines)
            {
                if (!responses.Select(s=>s.MedicineID).Contains(medicine.MedicineId))
                {
                    responses.Add(new MedicineResponse()
                    {
                        MedicineID = medicine.MedicineId,
                        Name = medicine.Name,
                        Strength = medicine.Strength,
                        Formulation = medicine.Formulation
                    });
                }
            }
           
            return responses;
            
        }

    }
}
