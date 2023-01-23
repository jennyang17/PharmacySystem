namespace PharmacyAPI.Models.Prescription
{
    public class PrescriptionItemRequest
    {
        
        
        public int MedicineId { get; set; }
        public string Dosage { get; set; } 
        public int Quantity { get; set; }
    }
}
