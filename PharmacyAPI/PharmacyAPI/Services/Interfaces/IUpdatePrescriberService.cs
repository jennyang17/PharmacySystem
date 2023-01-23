using PharmacyAPI.Models.Prescriber;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IUpdatePrescriberService
    {
        public PrescriberResponse UpdatePrescriber(PrescriberResponse request);
    }
}
