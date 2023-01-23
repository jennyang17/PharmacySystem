using Microsoft.EntityFrameworkCore;
using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Services.Interfaces;
using PharmacyAPI.Services.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyAPI.Tests.Services.Medicine
{
    
    public class DeleteMedicineServiceTests
    {
        private EF.Medicine medicine = new EF.Medicine()
        {
            MedicineId = 100,
            Name = "medicineTest",
            Strength = "100mg",
            Formulation = "formulationTest",
            IsDeleted = false

        };
        public DeleteMedicineServiceTests() { }

        [Fact]
        public void DeleteMedicine_ParameterNotFound() 
        {
            //Arrange
            TestHelper helper = new TestHelper();
            PharmacyContext context = helper.PharmacyContext;
            context.Medicines.Add(medicine);
            context.SaveChanges();
            //Act
            DeleteMedicineService deleteMedicineService= new DeleteMedicineService(context);

            //Assert
            Assert.Throws<NotFoundException>(() => deleteMedicineService.DeleteMedicine(101));

        }

        [Fact]
        public void DeleteMedicine_IsDeletedTrue()
        {
            //Arrange
            TestHelper helper = new TestHelper();
            PharmacyContext context = helper.PharmacyContext;
            context.Medicines.Add(medicine);
            context.SaveChanges();
            //Act
            DeleteMedicineService deleteMedicineService = new DeleteMedicineService(context);
            deleteMedicineService.DeleteMedicine(100);
            //Assert
            Assert.True(medicine.IsDeleted);
        }
    }
}
