using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Models.Patient;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private IGetPatientByPatientIDService _getPatientByPatientIDService;
        private ICreatePatientService _createPatientService;
        private IUpdatePatientService _updatePatientService;
        private IDeletePatientService _deletePatientService;

        public PatientController(IGetPatientByPatientIDService getPatientByPatientIDService, 
            ICreatePatientService createPatientService,
             IUpdatePatientService updatePatientService,
             IDeletePatientService deletePatientService)
        {
            _getPatientByPatientIDService = getPatientByPatientIDService;
            _createPatientService = createPatientService;
            _updatePatientService = updatePatientService;
            _deletePatientService = deletePatientService;
        }

        [HttpGet("PatientID")]
        public PatientResponse GetPatientByID(int patientID)
        {
            return _getPatientByPatientIDService.GetPatientByPatientID(patientID);
        }

        [HttpPost("Create")]
        public PatientResponse CreatePatient(PatientCreateRequest request)
        {
            return _createPatientService.CreatePatient(request);
        }

        [HttpPut("Update")]
        public PatientResponse UpdatePatient(PatientResponse request)
        {
            return _updatePatientService.UpdatePatient(request);
        }

        [HttpDelete("Delete")]
        public void DeletePatient(int patientID)
        {
            _deletePatientService.DeletePatient(patientID);
        }
    }
}
