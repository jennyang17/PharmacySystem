using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescription
{
    public class DeletePrescriptionItemService : IDeletePrescriptionItemService
    {
        public DeletePrescriptionItemService()
        {

        }

        public void DeletePrescriptionItem(int prescriptionItemID)
        {
            PharmacyContext context = new PharmacyContext();
            var result = context.PrescriptionItems.FirstOrDefault(m => m.PrescriptionItemId == prescriptionItemID);

            if (result == null)
            {
                throw new NotFoundException($"Unable to find prescription item with id {prescriptionItemID}");
            }

            result.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
