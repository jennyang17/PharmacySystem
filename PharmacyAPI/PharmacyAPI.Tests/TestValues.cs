using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyAPI.Tests
{
    public class TestValues
    {
        public static EF.Patient Patient = new EF.Patient()
        {
            PatientId = 1,
            Name = "Test",
            Dob = DateTime.Now,
            Address = "Test Address",
            Nhsnumber = "12345",
            Exemption = "A",
            IsDeleted = false,
            Prescriptions = new List<EF.Prescription>()
        };
        public static EF.Prescription Prescription = new EF.Prescription()
        {
            PrescriptionId = 123,
            PatientId = 1,
            PrescriberId = 321,
            Date = DateTime.Now,
            IsDeleted = false,
            PrescriptionItems = new List<EF.PrescriptionItem>()

        };
        public static EF.PrescriptionItem PrescriptionItem = new EF.PrescriptionItem()
        {
            PrescriptionItemId = 22,
            PrescriptionId = 123,
            MedicineId = 100,
            Dosage = "one daily",
            Quantity = 28,
            IsDeleted = false,
        };
        public static EF.Medicine Medicine = new EF.Medicine()
        {
            MedicineId = 100,
            Name = "medicineTest",
            Strength = "100mg",
            Formulation = "formulationTest",
            IsDeleted = false
        };
        private EF.Prescriber prescriber = new EF.Prescriber()
        {
            PrescriberId = 321,
            Name = "Dr Test",
            TypeOfPrescriber = "Doctor",
            PrescriberAddress = "Test Dr Address",
            IsDeleted = false,
            Prescriptions = new List<EF.Prescription>()
        };

    }
}
