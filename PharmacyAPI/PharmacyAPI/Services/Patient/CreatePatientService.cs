using PharmacyAPI.EF;
using PharmacyAPI.Models.Patient;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Patient
{
    public class CreatePatientService : ICreatePatientService
    {
        public CreatePatientService()
        {

        }

        public PatientResponse CreatePatient(PatientCreateRequest request)
        {
            PharmacyContext context = new PharmacyContext();
            EF.Patient patient = new EF.Patient()
            {
                Name = request.Name,
                Dob = request.Dob,
                Address = request.Address,
                Nhsnumber = request.Nhsnumber,
                Exemption = request.Exemption
            };

            context.Patients.Add(patient);
            context.SaveChanges();

            PatientResponse patientResponse = new PatientResponse()
            {
                PatientId = patient.PatientId,
                Name = patient.Name,
                Dob = patient.Dob,
                Address = patient.Address,
                Nhsnumber = patient.Nhsnumber,
                Exemption = patient.Exemption
            };

            return patientResponse;
        }
    }
}
