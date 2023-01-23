using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Prescriber;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescriber
{
    public class GetPrescriberByPrescriberID : IGetPrescriberByPrescriberID
    {
        public GetPrescriberByPrescriberID()
        {

        }

        public PrescriberResponse GetPrescriber(int prescriberID)
        {
            PharmacyContext context = new PharmacyContext();
            EF.Prescriber? prescriber = context.Prescribers.FirstOrDefault(pr => pr.PrescriberId == prescriberID);

            if (prescriber == null)
            {
                throw new NotFoundException($"Unable to find prescriber item with id {prescriberID}");
            }

            PrescriberResponse response = new PrescriberResponse()
            {
                PrescriberId = prescriber.PrescriberId,
                Name = prescriber.Name,
                TypeOfPrescriber = prescriber.TypeOfPrescriber,
                PrescriberAddress = prescriber.PrescriberAddress
            };

            return response;
        }
    }
}
