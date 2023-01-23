namespace PharmacyAPI.Models.Prescriber
{
    public class PrescriberResponse
    {
        public int PrescriberId { get; set; }
        public string Name { get; set; }
        public string TypeOfPrescriber { get; set; }
        public string PrescriberAddress { get; set; } 
    }
}
