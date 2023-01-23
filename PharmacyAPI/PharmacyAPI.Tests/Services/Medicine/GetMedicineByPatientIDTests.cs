using Microsoft.EntityFrameworkCore;
using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Services.Interfaces;
using PharmacyAPI.Services.Medicine;
using PharmacyAPI.Services.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyAPI.Tests.Services.Medicine
{
    public class GetMedicineByPatientIDTests :IDisposable
    {
        private PharmacyContext _context;

        public GetMedicineByPatientIDTests() 
        {
            _context = new TestHelper().PharmacyContext;


            //prescriptionItem.Medicine= TestValues.Medicine;
            //prescriptionItem.Prescription = TestValues.Prescription;
            //prescription.Patient = TestValues.Patient;
            //prescription.PrescriptionItems.Add(TestValues.PrescriptionItem);
            //prescriber.Prescriptions.Add(TestValues.Prescription);
            //patient.Prescriptions.Add(TestValues.Prescription);

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void GetMedicineByPatientID_MissingPatient()
        {
            //Arrange
            TestHelper helper = new TestHelper();
            PharmacyContext context = helper.PharmacyContext;
            context.Patients.Add(patient);
            context.SaveChanges();
            //Act
            GetMedicineByPatientID getMedicineByPatientIDService = new GetMedicineByPatientID(context);
            //Assert
            Assert.Throws<NotFoundException>(() => getMedicineByPatientIDService.GetMedicineByPatientIDMethod(2));
        }
        [Fact]
        public void GetMedicineByPatientID_IsDeleted()
        {
            //Arrange
            TestHelper helper = new TestHelper();
            PharmacyContext context = helper.PharmacyContext;
            //patient.IsDeleted = true;
            //context.Patients.Add(patient);
            context.SaveChanges();
            //Act
            GetMedicineByPatientID getMedicineByPatientIDService = new GetMedicineByPatientID(context);
            //Assert
            Assert.Throws<NotFoundException>(() => getMedicineByPatientIDService.GetMedicineByPatientIDMethod(1));
        }
        [Fact]
        public void GetMedicineByPatientID_Response()
        {
            //Arrange
            TestHelper helper = new TestHelper();
            PharmacyContext context = helper.PharmacyContext;
            //context.Patients.Add(patient);
            //context.SaveChanges();
            //Act
            GetMedicineByPatientID getMedicineByPatientIDService = new GetMedicineByPatientID(context);
            var result = getMedicineByPatientIDService.GetMedicineByPatientIDMethod(1);

            //Assert
            Assert.Equal(2, result.Count());

            //Assert.Equal(result[0].Name, medicine.Name);
            //Assert.Equal(result[0].MedicineID, medicine.MedicineId);
            //Assert.Equal(result[0].Strength, medicine.Strength);
            //Assert.Equal(result[0].Formulation, medicine.Formulation);

            //Assert.Equal(medicine.MedicineId, result[1].MedicineID);

        }
    }
}
