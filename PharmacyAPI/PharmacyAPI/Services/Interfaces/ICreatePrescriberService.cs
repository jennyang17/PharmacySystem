using PharmacyAPI.Models.Prescriber;

namespace PharmacyAPI.Services.Interfaces
{
    public interface ICreatePrescriberService
    {
        public PrescriberResponse CreatePrescriber(PrescriberCreateRequest request);
    }
}
