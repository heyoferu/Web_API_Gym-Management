using PUMP.core.BL.Interfaces;
using PUMP.core.BL.Services;
using PUMP.helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// // Get string connection
Settings.ConnectionString = builder.Configuration.GetConnectionString("path");

// Add dependency injection
builder.Services.AddTransient<IAuthentication, AuthenticationServices>();
builder.Services.AddTransient<IEmployees, EmployeesServices>();

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
