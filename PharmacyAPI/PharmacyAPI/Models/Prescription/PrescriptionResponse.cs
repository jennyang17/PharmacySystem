
namespace PharmacyAPI.Models.Prescription
{
    public class PrescriptionResponse
    {
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public int PrescriberId { get; set; }
        public DateTime Date { get; set; }
        public List<PrescriptionItemResponse> PrescriptionItems { get; set; }
    }
}
