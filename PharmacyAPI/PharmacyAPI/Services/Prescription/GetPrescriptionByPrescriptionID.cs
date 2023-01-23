using Microsoft.EntityFrameworkCore;
using PharmacyAPI.EF;
using PharmacyAPI.Models.Prescription;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescription
{
    public class GetPrescriptionByPrescriptionID : IGetPrescriptionByPrescriptionID
    {
        public GetPrescriptionByPrescriptionID()
        {

        }

        public PrescriptionResponse GetPrescriptionByID(int prescriptionID)
        {
            PharmacyContext context = new PharmacyContext();
            EF.Prescription? result = context.Prescriptions.
                Include(p => p.PrescriptionItems).
                FirstOrDefault(p => p.PrescriptionId == prescriptionID);

            PrescriptionResponse response = new PrescriptionResponse()
            {
                PrescriptionId = result.PrescriptionId,
                PatientId = result.PatientId,
                PrescriberId = result.PrescriberId,
                Date = result.Date,
                PrescriptionItems = new List<PrescriptionItemResponse>()
            };

            foreach (var item in result.PrescriptionItems)
            {
                response.PrescriptionItems.Add(new PrescriptionItemResponse()
                {
                    PrescriptionItemId = item.PrescriptionItemId,
                    PrescriptionId = item.PrescriptionId,
                    MedicineId = item.MedicineId,
                    Dosage = item.Dosage,
                    Quantity = item.Quantity
                });
            }
            

            return response;
        }
    }
}
