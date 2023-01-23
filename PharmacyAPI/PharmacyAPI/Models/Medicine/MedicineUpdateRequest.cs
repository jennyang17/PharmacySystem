namespace PharmacyAPI.Models.Medicine
{
    public class MedicineUpdateRequest
    {
        public int MedicineID { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public string Formulation { get; set; }
    }
}
