using PharmacyAPI.EF;
using PharmacyAPI.Models.Prescriber;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescriber
{
    public class CreatePrescriberService : ICreatePrescriberService
    {
        public CreatePrescriberService()
        {

        }

        public PrescriberResponse CreatePrescriber(PrescriberCreateRequest request)
        {
            PharmacyContext context = new PharmacyContext();
            EF.Prescriber prescriber = new EF.Prescriber()
            {
                Name = request.Name,
                TypeOfPrescriber = request.TypeOfPrescriber,
                PrescriberAddress = request.PrescriberAddress
            };

            context.Prescribers.Add(prescriber);
            context.SaveChanges();

            PrescriberResponse prescriberResponse = new PrescriberResponse()
            {
                PrescriberId = prescriber.PrescriberId,
                Name = prescriber.Name,
                TypeOfPrescriber = prescriber.TypeOfPrescriber,
                PrescriberAddress = prescriber.PrescriberAddress
            };

            return prescriberResponse;
        }
    }
}
