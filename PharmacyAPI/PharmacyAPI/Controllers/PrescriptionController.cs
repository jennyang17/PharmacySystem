using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Models.Prescription;
using PharmacyAPI.Services.Interfaces;
using System.Transactions;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private ICreatePrescriptionService _createPrescriptionService;
        private IUpdatePrescriptionService _updatePrescriptionService;
        private IDeletePrescriptionService _deletePrescriptionService;
        private IDeletePrescriptionItemService _deletePrescriptionItemService;
        private IGetPrescriptionByPrescriptionID _getPrescriptionByPrescriptionID;
        private IGetPrescriptionByPatientID _getPrescriptionByPatientID;

        public PrescriptionController(ICreatePrescriptionService createPrescriptionService, 
            IUpdatePrescriptionService updatePrescriptionService,
            IDeletePrescriptionService deletePrescriptionService,
            IDeletePrescriptionItemService deletePrescriptionItemService,
            IGetPrescriptionByPrescriptionID getPrescriptionByPrescriptionID,
            IGetPrescriptionByPatientID getPrescriptionByPatientID)
        {
            _createPrescriptionService = createPrescriptionService;
            _updatePrescriptionService = updatePrescriptionService;
            _deletePrescriptionService = deletePrescriptionService;
            _deletePrescriptionItemService = deletePrescriptionItemService;
            _getPrescriptionByPrescriptionID = getPrescriptionByPrescriptionID;
            _getPrescriptionByPatientID = getPrescriptionByPatientID;
        }

        [HttpPost("Create")]
        public PrescriptionResponse CreatePrescription(PrescriptionCreateRequest request)
        {
            return _createPrescriptionService.CreatePrescription(request);
        }

        [HttpPut("Update")]
        public PrescriptionResponse UpdatePrescription(PrescriptionUpdateRequest request)
        {
            return _updatePrescriptionService.UpdatePrescription(request);
        }

        [HttpGet("PrescriptionID")]
        public PrescriptionResponse GetPrescriptionByPrescriptionID(int prescriptionID)
        {
            return _getPrescriptionByPrescriptionID.GetPrescriptionByID(prescriptionID);
        }

        [HttpGet("PatientID")]
        public List<PrescriptionResponse> GetPrescriptionByPatientID(int patientID)
        {
            return _getPrescriptionByPatientID.GetPrescriptionsByPatientIDMethod(patientID);
        }

        [HttpDelete("Prescription")]
        public void DeletePrescription(int prescriptionID)
        {
            _deletePrescriptionService.DeletePrescription(prescriptionID);
        }

        [HttpDelete("PrescriptionItem")]
        public void DeletePrescriptionItem(int prescriptionItemID)
        {
            _deletePrescriptionItemService.DeletePrescriptionItem(prescriptionItemID);
        }

    }
}
