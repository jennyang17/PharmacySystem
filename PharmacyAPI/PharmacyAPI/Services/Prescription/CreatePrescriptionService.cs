using PharmacyAPI.EF;
using PharmacyAPI.Models.Prescriber;
using PharmacyAPI.Models.Prescription;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescription
{
    public class CreatePrescriptionService : ICreatePrescriptionService
    {
        public CreatePrescriptionService()
        {

        }

        public PrescriptionResponse CreatePrescription(PrescriptionCreateRequest request)
        {
            PharmacyContext context = new PharmacyContext();

            List<PrescriptionItem> items = new List<PrescriptionItem>();
            foreach (var item in request.PrescriptionItems)
            {
                items.Add(new PrescriptionItem()
                {
                    MedicineId = item.MedicineId,
                    Dosage = item.Dosage,
                    Quantity = item.Quantity
                });
            }

            EF.Prescription prescription = new EF.Prescription()
            {
                PatientId = request.PatientId,
                PrescriberId = request.PrescriberId,
                Date = request.Date,
                PrescriptionItems = items
            };

            context.Prescriptions.Add(prescription);
            context.SaveChanges();

            PrescriptionResponse response = new PrescriptionResponse()
            {
                PrescriptionId = prescription.PrescriptionId,
                PatientId = prescription.PatientId,
                PrescriberId = prescription.PrescriberId,
                Date = prescription.Date,
                PrescriptionItems = new List<PrescriptionItemResponse>()
            };
            foreach (var item in prescription.PrescriptionItems)
            {
                response.PrescriptionItems.Add(new PrescriptionItemResponse()
                {
                    PrescriptionId = item.PrescriptionId,
                    PrescriptionItemId = item.PrescriptionItemId,
                    Dosage = item.Dosage,
                    MedicineId = item.MedicineId,
                    Quantity = item.Quantity
                });
            }

            return response;

        }
    }
}
