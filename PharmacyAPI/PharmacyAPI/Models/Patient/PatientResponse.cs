namespace PharmacyAPI.Models.Patient
{
    public class PatientResponse
    {
        public int PatientId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Address { get; set; } = null!;
        public string Nhsnumber { get; set; } = null!;
        public string Exemption { get; set; } = null!;
    }
}
