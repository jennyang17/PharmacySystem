using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescription
{
    public class DeletePrescriptionService : IDeletePrescriptionService
    {
        public DeletePrescriptionService()
        {

        }
        public void DeletePrescription(int prescriptionID)
        {
            PharmacyContext context = new PharmacyContext();
            var result = context.Prescriptions.FirstOrDefault(m => m.PrescriptionId == prescriptionID);

            if (result == null)
            {
                throw new NotFoundException($"Unable to find prescription with id {prescriptionID}");
            }

            result.IsDeleted = true;
            context.SaveChanges();

        }
    }

    
}
