using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Patient
{
    public class DeletePatientService : IDeletePatientService
    {
        public DeletePatientService()
        {

        }

        public void DeletePatient(int patientID)
        {
            PharmacyContext context = new PharmacyContext();
            var result = context.Patients.FirstOrDefault(m => m.PatientId == patientID);

            if (result == null)
            {
                throw new NotFoundException($"Unable to find patient with id {patientID}");
            }

            result.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
