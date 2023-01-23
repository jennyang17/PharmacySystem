using PharmacyAPI.EF;

namespace PharmacyAPI.Models.Prescription
{
    public class PrescriptionCreateRequest
    {
        public int PatientId { get; set; }
        public int PrescriberId { get; set; }
        public DateTime Date { get; set; }

        public List<PrescriptionItemRequest> PrescriptionItems { get; set; }
    }
}
