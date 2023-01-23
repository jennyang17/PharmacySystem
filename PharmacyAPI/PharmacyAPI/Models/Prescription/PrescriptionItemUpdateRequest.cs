namespace PharmacyAPI.Models.Prescription
{
    public class PrescriptionItemUpdateRequest
    {
        public int PrescriptionItemId { get; set; }
        public int MedicineId { get; set; }
        public string Dosage { get; set; }
        public int Quantity { get; set; }
    }
}
