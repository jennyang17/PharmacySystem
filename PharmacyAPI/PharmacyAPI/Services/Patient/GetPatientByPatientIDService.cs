using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Patient;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Patient
{
    public class GetPatientByPatientIDService : IGetPatientByPatientIDService
    {
        PharmacyContext _context;
        public GetPatientByPatientIDService(PharmacyContext context)
        {
            _context= context;
        }

        public PatientResponse GetPatientByPatientID(int patientID)
        {
            
            EF.Patient? patient = _context.Patients.FirstOrDefault(p => p.PatientId == patientID);

            if (patient.IsDeleted == true || patient == null)
            {
                throw new NotFoundException($"Unable to find patient with id {patientID}");
            }

            PatientResponse response = new PatientResponse()
            {
                Name = patient.Name,
                Dob = patient.Dob,
                Address = patient.Address,
                Nhsnumber = patient.Nhsnumber,
                Exemption = patient.Exemption
            };

            return response;
        }
    }
}
