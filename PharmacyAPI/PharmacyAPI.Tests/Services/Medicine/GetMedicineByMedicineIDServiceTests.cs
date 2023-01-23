using PharmacyAPI.EF;
using PharmacyAPI.Exceptions;
using PharmacyAPI.Models.Medicine;
using PharmacyAPI.Services.Interfaces;
using PharmacyAPI.Services.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyAPI.Tests.Services.Medicine
{
    public class GetMedicineByMedicineIDServiceTests
    {
        private EF.Medicine medicine = new EF.Medicine()
        {
            MedicineId = 100,
            Name = "medicineTest",
            Strength = "100mg",
            Formulation = "formulationTest",
            IsDeleted = false
        };
        public GetMedicineByMedicineIDServiceTests()
        {

        }

        [Fact]
        public void GetMedicineByMedicineID_NullResult()
        {
            //Arrange
            TestHelper helper = new TestHelper();
            PharmacyContext context = helper.PharmacyContext;
            context.Medicines.Add(medicine);
            context.SaveChanges();
            //Act
            GetMedicineByMedicineIDService getMedicineByMedicineID = new GetMedicineByMedicineIDService(context);
            //Assert
            Assert.Throws<NotFoundException>(() => getMedicineByMedicineID.GetMedicineByMedicineID(101)); 


        }

        [Fact]
        public void GetMedicineByMedicineID_IsDeleted()
        {
            //Arrange
            TestHelper helper = new TestHelper();
            PharmacyContext context = helper.PharmacyContext;
            medicine.IsDeleted = true;
            context.Medicines.Add(medicine);
            context.SaveChanges();
            //Act
            GetMedicineByMedicineIDService getMedicineByMedicineID = new GetMedicineByMedicineIDService(context);
            //Assert
            Assert.Throws<NotFoundException>(() => getMedicineByMedicineID.GetMedicineByMedicineID(100));
        }
        [Fact]
        public void GetMedicineByMedicineID_MedicineResponse()
        {
            //Arrange
            TestHelper helper = new TestHelper();
            PharmacyContext context = helper.PharmacyContext;
            context.Medicines.Add(medicine);
            context.SaveChanges();
            //Act
            GetMedicineByMedicineIDService getMedicineByMedicineID = new GetMedicineByMedicineIDService(context);
            MedicineResponse response = getMedicineByMedicineID.GetMedicineByMedicineID(100);
            //Assert
            Assert.Equal(medicine.Name, response.Name);
            Assert.Equal(medicine.Strength, response.Strength);
            Assert.Equal(medicine.Formulation, response.Formulation);
            Assert.Equal(medicine.MedicineId, response.MedicineID);
        }



    }
}
