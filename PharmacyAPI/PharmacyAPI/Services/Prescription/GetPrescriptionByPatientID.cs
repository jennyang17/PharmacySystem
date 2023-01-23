using Microsoft.EntityFrameworkCore;
using PharmacyAPI.EF;
using PharmacyAPI.Models.Prescription;
using PharmacyAPI.Services.Interfaces;

namespace PharmacyAPI.Services.Prescription
{
    public class GetPrescriptionsByPatientID : IGetPrescriptionByPatientID
    {
        public GetPrescriptionsByPatientID()
        {

        }

        public List<PrescriptionResponse> GetPrescriptionsByPatientIDMethod(int patientID)
        {
            PharmacyContext context = new();
            List<EF.Prescription> prescriptions = context.Prescriptions.Include(pi => pi.PrescriptionItems)
                                                                       .Where(p => p.PatientId == patientID).ToList();
            List<PrescriptionResponse> prescriptionResponses = new();

            foreach(EF.Prescription prescription in prescriptions)
            {
                var pr = new PrescriptionResponse()
                {
                    PrescriptionId = prescription.PrescriptionId,
                    PatientId = prescription.PatientId,
                    PrescriberId = prescription.PrescriberId,
                    Date = prescription.Date,
                    PrescriptionItems = new List<PrescriptionItemResponse>()
                };

                foreach (var item in prescription.PrescriptionItems)
                {
                    pr.PrescriptionItems.Add(new PrescriptionItemResponse()
                    {
                        PrescriptionItemId = item.PrescriptionItemId,
                        PrescriptionId = item.PrescriptionId,
                        MedicineId = item.MedicineId,
                        Dosage = item.Dosage,
                        Quantity = item.Quantity
                    });
                }
                prescriptionResponses.Add(pr);
            }

            return prescriptionResponses;

        }
    }
}
