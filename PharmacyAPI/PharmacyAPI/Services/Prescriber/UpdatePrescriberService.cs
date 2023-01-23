using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Patient;
using PharmacyAPI.Models.Prescriber;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescriber
{
    public class UpdatePrescriberService : IUpdatePrescriberService
    {
        public UpdatePrescriberService()
        {

        }

        public PrescriberResponse UpdatePrescriber(PrescriberResponse request)
        {

            PharmacyContext context = new PharmacyContext();
            var result = context.Prescribers.FirstOrDefault(p => p.PrescriberId == request.PrescriberId);

            if (result == null)
            {
                throw new NotFoundException($"Unable to find prescriber with id {request.PrescriberId}");
            }
            result.PrescriberId = request.PrescriberId;
            result.PrescriberAddress = request.PrescriberAddress;
            result.TypeOfPrescriber = request.TypeOfPrescriber;
            result.Name = request.Name;

            context.SaveChanges();

            PrescriberResponse response = new PrescriberResponse()
            {
                PrescriberId = result.PrescriberId,
                PrescriberAddress = result.PrescriberAddress,
                TypeOfPrescriber = result.TypeOfPrescriber,
                Name = result.Name
            };

            return response;
        }
    }
}
