using PharmacyAPI.Models.Prescriber;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IGetPrescriberByPrescriberID
    {
        public PrescriberResponse GetPrescriber(int prescriberID);
    }
}
