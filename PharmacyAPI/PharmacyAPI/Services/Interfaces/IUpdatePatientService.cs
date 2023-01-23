using PharmacyAPI.Models.Patient;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IUpdatePatientService
    {
        public PatientResponse UpdatePatient(PatientResponse request);
    }
}
