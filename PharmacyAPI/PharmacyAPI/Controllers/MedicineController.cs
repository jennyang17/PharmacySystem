using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Models.Medicine;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {
        private IGetMedicineByMedicineIDService _getMedicineByMedicineIDService;
        private ICreateMedicineService _createMedicineService;
        private IUpdateMedicineService _updateMedicineService;
        private IDeleteMedicineService _deleteMedicineService;
        private IGetMedicineByPatientID _getMedicineByPatientID;

        public MedicineController(IGetMedicineByMedicineIDService getMedicineByMedicineIDService, 
            ICreateMedicineService createMedicineService, 
            IUpdateMedicineService updateMedicineService,
            IDeleteMedicineService deleteMedicineService,
            IGetMedicineByPatientID getMedicineByPatientID)
        {
            _getMedicineByMedicineIDService = getMedicineByMedicineIDService;
            _createMedicineService = createMedicineService;
            _updateMedicineService = updateMedicineService;
            _deleteMedicineService= deleteMedicineService;
            _getMedicineByPatientID = getMedicineByPatientID;
        }

        [HttpGet("MedicineID")]
        public MedicineResponse GetByMedicineID(int medicineID)
        {
            return _getMedicineByMedicineIDService.GetMedicineByMedicineID(medicineID);
        }

        [HttpGet("PatientID")]
        public List<MedicineResponse> GetMedicineByPatientID(int patientID)
        {
            return _getMedicineByPatientID.GetMedicineByPatientIDMethod(patientID);
        }


        [HttpPost("Create")]
        public MedicineResponse CreateMedicine(MedicineCreateRequest request)
        {
            return _createMedicineService.CreateMedicine(request);
        }

        [HttpPut("Update")]
        public MedicineResponse UpdateMedicine(MedicineUpdateRequest request)
        {
            return _updateMedicineService.UpdateMedicine(request);
        }

        [HttpDelete("Delete")]
        public void DeleteMedicine(int medicineID)
        {
            _deleteMedicineService.DeleteMedicine(medicineID);
        }
    }
}
