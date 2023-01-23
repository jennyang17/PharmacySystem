using PharmacyAPI.Models.Patient;

namespace PharmacyAPI.Services.Interfaces
{
    public interface ICreatePatientService
    {
        public PatientResponse CreatePatient(PatientCreateRequest request);
    }
}
