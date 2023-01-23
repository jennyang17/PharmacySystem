using Microsoft.EntityFrameworkCore;
using PharmacyAPI.EF;
using PharmacyAPI.Services.Interfaces;
using PharmacyAPI.Services.Medicine;
using PharmacyAPI.Services.Patient;
using PharmacyAPI.Services.Prescriber;
using PharmacyAPI.Services.Prescription;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IGetMedicineByMedicineIDService, GetMedicineByMedicineIDService>();
builder.Services.AddTransient<IGetPatientByPatientIDService, GetPatientByPatientIDService>();
builder.Services.AddTransient<ICreateMedicineService, CreateMedicineService>();
builder.Services.AddTransient<ICreatePatientService, CreatePatientService>();
builder.Services.AddTransient<ICreatePrescriberService, CreatePrescriberService>();
builder.Services.AddTransient<IGetPrescriberByPrescriberID, GetPrescriberByPrescriberID>();
builder.Services.AddTransient<ICreatePrescriptionService, CreatePrescriptionService>();
builder.Services.AddTransient<IUpdateMedicineService, UpdateMedicineService>();
builder.Services.AddTransient<IDeleteMedicineService, DeleteMedicineService>();
builder.Services.AddTransient<IUpdatePatientService, UpdatePatientService>();
builder.Services.AddTransient<IDeletePatientService, DeletePatientService>();
builder.Services.AddTransient<IUpdatePrescriberService, UpdatePrescriberService>();
builder.Services.AddTransient<IUpdatePrescriptionService, UpdatePrescriptionService>();
builder.Services.AddTransient<IDeletePrescriptionService, DeletePrescriptionService>();
builder.Services.AddTransient<IDeletePrescriptionItemService, DeletePrescriptionItemService>();
builder.Services.AddTransient<IGetPrescriptionByPrescriptionID, GetPrescriptionByPrescriptionID>();
builder.Services.AddTransient<IGetMedicineByPatientID, GetMedicineByPatientID>();
builder.Services.AddTransient<IGetPrescriptionByPatientID, GetPrescriptionsByPatientID>();

builder.Services.AddDbContext<PharmacyContext>(options => options.UseSqlServer("Server=.;Database=Pharmacy;Trusted_Connection=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
