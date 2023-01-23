namespace PharmacyAPI.Models.Prescription
{
    public class PrescriptionItemResponse
    {
        public int PrescriptionItemId { get; set; }
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public string Dosage { get; set; } 
        public int Quantity { get; set; }
    }
}
