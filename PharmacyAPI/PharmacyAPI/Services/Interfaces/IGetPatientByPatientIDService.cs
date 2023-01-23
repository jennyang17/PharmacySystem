using PharmacyAPI.Models.Patient;

namespace PharmacyAPI.Services.Interfaces
{
    public interface IGetPatientByPatientIDService
    {
        PatientResponse GetPatientByPatientID(int patientID);
    }
}
