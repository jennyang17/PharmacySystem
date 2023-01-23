using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Models.Prescriber;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PrescriberController : ControllerBase
    {
        private ICreatePrescriberService _createPrescriberService;
        private IGetPrescriberByPrescriberID _getPrescriberByPrescriberID;
        private IUpdatePrescriberService _updatePrescriberService;
        private IDeletePrescriberService _deletePrescriberService;

        public PrescriberController(ICreatePrescriberService createPrescriberService, 
            IGetPrescriberByPrescriberID getPrescriberByPrescriberID,
            IUpdatePrescriberService updatePrescriberService,
            IDeletePrescriberService deletePrescriberService)
        {
            _createPrescriberService = createPrescriberService;
            _getPrescriberByPrescriberID = getPrescriberByPrescriberID;
            _updatePrescriberService = updatePrescriberService;
            _deletePrescriberService = deletePrescriberService;
        }

        [HttpGet("PrescriberID")]
        public PrescriberResponse GetPrescriberByPrescriberID(int prescriberID)
        {
            return _getPrescriberByPrescriberID.GetPrescriber(prescriberID);
        }


        [HttpPost("Create")]
        public PrescriberResponse CreatePrescriber(PrescriberCreateRequest request)
        {
            return _createPrescriberService.CreatePrescriber(request);
        }

        [HttpPut("Update")]
        public PrescriberResponse UpdatePrescriber(PrescriberResponse request)
        {
            return _updatePrescriberService.UpdatePrescriber(request);
        }

        [HttpDelete("Delete")]
        public void DeletePrescriber(int prescriberID)
        {
            _deletePrescriberService.DeletePrescriber(prescriberID);
        }
    }
}
