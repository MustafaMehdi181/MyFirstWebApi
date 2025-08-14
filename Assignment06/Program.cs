using Assignment06.Repositories;
using Assignment06.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClinicRoleRepository, ClinicRoleRepository>();
builder.Services.AddScoped<IClinicRoleService, ClinicRoleService>();


builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorServices, DoctorService>();


builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<IVisitTypeRepository, VisitTypeRepository>();
builder.Services.AddScoped<IVisitTypeService, VisitTypeService>();

builder.Services.AddScoped<IVisitDetailRepository, VisitDetailRepository>();
builder.Services.AddScoped<IVisitDetailService, VisitDetailService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
