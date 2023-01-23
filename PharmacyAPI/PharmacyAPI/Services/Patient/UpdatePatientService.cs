using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Patient;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Patient
{
    public class UpdatePatientService : IUpdatePatientService
    {
        public UpdatePatientService()
        {

        }

        public PatientResponse UpdatePatient(PatientResponse request)
        {
            PharmacyContext context = new PharmacyContext();
            var result = context.Patients.FirstOrDefault(p => p.PatientId == request.PatientId);

            if (result == null)
            {
                throw new NotFoundException($"Unable to find patient with id {request.PatientId}");
            }
            result.PatientId = request.PatientId;
            result.Nhsnumber = request.Nhsnumber;
            result.Address = request.Address;
            result.Name = request.Name;
            result.Dob = request.Dob;
            result.Exemption = request.Exemption;

            context.SaveChanges();

            PatientResponse response = new PatientResponse()
            {
                PatientId = result.PatientId,
                Nhsnumber = result.Nhsnumber,
                Address = result.Address,
                Name = result.Name,
                Dob = result.Dob,
                Exemption = result.Exemption
            };

            return response;
        }
        
    }
}
