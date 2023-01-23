using PharmacyAPI.EF;
using PharmacyAPI.Services.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit.Abstractions;

namespace PharmacyAPI.Tests.Services.Medicine
{
    public class CreateMedicineServiceTests
    {
        public CreateMedicineServiceTests()
        {

        }
        [Theory]
        [InlineData(null, "50mg", "tablet", "Name" ) ]
        [InlineData("", "50mg", "tablet", "Name")]
        [InlineData("Lisinopril", null, "tablet", "Strength")]
        [InlineData("Lisinopril", "", "tablet", "Strength")]
        [InlineData("Lisinopril", "5mg", null, "Formulation")]
        [InlineData("Lisinopril", "5mg", "", "Formulation")]

        public void CreateMedicineTheory(string name, string strength, string formulation, string expectedErrorParameter)
        {
            PharmacyContext context = new PharmacyContext();
            CreateMedicineService createMedicineService = new CreateMedicineService(context);

            var ex = Assert.Throws<ArgumentException>(() =>
                createMedicineService.CreateMedicine(new Models.Medicine.MedicineCreateRequest { Name = name, Strength = strength, Formulation = formulation }));

            Assert.Equal("Invalid parameter " + expectedErrorParameter, ex.Message);
        }

        [Fact]
        public void CreateMedicine_RequestAdded()
        {
            //Arrange
            TestHelper helper = new TestHelper();

            PharmacyContext context = helper.PharmacyContext;
            CreateMedicineService createMedicineService = new CreateMedicineService(context);

            //Act
            var response = createMedicineService.CreateMedicine(new Models.Medicine.MedicineCreateRequest { Name = "Lisinopril", Strength = "5mg", Formulation = "tablet" });
           
            //Assert
            var contains = Assert.Single(context.Medicines.Where(f => f.MedicineId == response.MedicineID));
            Assert.Equal("Lisinopril", contains.Name);
            Assert.Equal("5mg", contains.Strength);
            Assert.Equal("tablet", contains.Formulation);

            Assert.Equal("Lisinopril", response.Name);
            Assert.Equal("5mg", response.Strength);
            Assert.Equal("tablet", response.Formulation);
        }

        [Fact]
        public void CreateMedicine_NullParamater()
        {
            //Given
            PharmacyContext context= new PharmacyContext();
            CreateMedicineService createMedicineService = new CreateMedicineService(context);

            //When
            //Then
            Assert.Throws<ArgumentException>(() => createMedicineService.CreateMedicine(null));
        }

        //[Fact]
        //public void CreateMedicine_EmptyParamaters_Name()
        //{
        //    Given
        //    PharmacyContext context = new PharmacyContext();
        //    CreateMedicineService createMedicineService = new CreateMedicineService(context);

        //    When
        //    Then
        //    var ex = Assert.Throws<ArgumentException>(() => createMedicineService.CreateMedicine(new Models.Medicine.MedicineCreateRequest { Name = "" }));
        //    Assert.Equal("Invalid parameter Name", ex.Message);
        //}

        //[Fact]
        //public void CreateMedicine_NullParamaters_Name()
        //{
        //    Given
        //    PharmacyContext context = new PharmacyContext();
        //    CreateMedicineService createMedicineService = new CreateMedicineService(context);

        //    When
        //    Then
        //    var ex = Assert.Throws<ArgumentException>(() => createMedicineService.CreateMedicine(new Models.Medicine.MedicineCreateRequest { Name = null }));
        //    Assert.Equal("Invalid parameter Name", ex.Message);
        //}

        //[Fact]
        //public void CreateMedicine_EmptyParamaters_Formulation()
        //{
        //    Given
        //    PharmacyContext context = new PharmacyContext();
        //    CreateMedicineService createMedicineService = new CreateMedicineService(context);

        //    When
        //    Then
        //    var ex = Assert.Throws<ArgumentException>(() => createMedicineService.CreateMedicine(new Models.Medicine.MedicineCreateRequest { Name = "x", Formulation = "" }));
        //    Assert.Equal("Formulation", ex.Message);
        //}

        //[Fact]
        //public void CreateMedicine_NullParamaters_Formulation()
        //{
        //    Given
        //    PharmacyContext context = new PharmacyContext();
        //    CreateMedicineService createMedicineService = new CreateMedicineService(context);

        //    When
        //    Then
        //    var ex = Assert.Throws<ArgumentException>(() => createMedicineService.CreateMedicine(new Models.Medicine.MedicineCreateRequest { Name = "x", Formulation = null }));
        //    Assert.Equal("Formulation", ex.Message);
        //}
    }

}
