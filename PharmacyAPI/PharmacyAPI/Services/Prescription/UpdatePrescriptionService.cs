using Microsoft.EntityFrameworkCore;
using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Prescriber;
using PharmacyAPI.Models.Prescription;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescription
{
    public class UpdatePrescriptionService : IUpdatePrescriptionService
    {
        public UpdatePrescriptionService()
        {

        }

        public PrescriptionResponse UpdatePrescription(PrescriptionUpdateRequest request)
        {
            PharmacyContext context = new PharmacyContext();
            var prescription = context.Prescriptions
                .FirstOrDefault(p => p.PrescriptionId == request.PrescriptionId);

            if (prescription == null)
            {
                throw new NotFoundException($"Unable to find prescription with id {request.PrescriptionId}");
            }
            
            prescription.PrescriptionId = request.PrescriptionId;
            prescription.PatientId = request.PatientId;
            prescription.PrescriberId = request.PrescriberId;
            prescription.Date = request.Date;

            List<int> prescriptionItemIDsToUpdate = new List<int>();
            prescriptionItemIDsToUpdate = request.PrescriptionItems.Select(s => s.PrescriptionItemId).ToList();

            var prescriptionItems = context.PrescriptionItems
                                            .Where(w => w.PrescriptionId == request.PrescriptionId
                                                        && prescriptionItemIDsToUpdate.Contains(w.PrescriptionItemId))
                                            .ToList();

            foreach (var item in prescriptionItems)
            {
                item.MedicineId = item.MedicineId;
                item.Dosage = item.Dosage;
                item.Quantity = item.Quantity;
            }
            
            context.SaveChanges();

            PrescriptionResponse response = new PrescriptionResponse()
            {
                PrescriptionId = prescription.PrescriptionId,
                PatientId = prescription.PatientId,
                Date = prescription.Date,
                PrescriberId = prescription.PrescriberId,
                PrescriptionItems = new List<PrescriptionItemResponse>()
            };
            foreach (var item in prescription.PrescriptionItems)
            {
                response.PrescriptionItems.Add(new PrescriptionItemResponse()
                {
                    PrescriptionId = item.PrescriptionId,
                    PrescriptionItemId = item.PrescriptionItemId,
                    MedicineId = item.MedicineId,
                    Dosage = item.Dosage,
                    Quantity = item.Quantity
                });
            }

            return response;
        }
    }
    
}
