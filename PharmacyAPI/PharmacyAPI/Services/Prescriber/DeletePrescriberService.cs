using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescriber
{
    public class DeletePrescriberService : IDeletePrescriberService
    {
        public DeletePrescriberService()
        {

        }
        public void DeletePrescriber(int prescriberID)
        {
            PharmacyContext context = new PharmacyContext();
            var result = context.Prescribers.FirstOrDefault(m => m.PrescriberId == prescriberID);

            if (result == null)
            {
                throw new NotFoundException($"Unable to find prescriber with id {prescriberID}");
            }

            result.IsDeleted = true;
            context.SaveChanges();

        }
    }
}
