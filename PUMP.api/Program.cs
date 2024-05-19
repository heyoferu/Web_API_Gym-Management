using PUMP.core.BL.Interfaces;
using PUMP.core.BL.Services;
using PUMP.helpers;
using PUMP.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// // Get string connection
Settings.ConnectionString = builder.Configuration.GetConnectionString("path");

// Add dependency injection
builder.Services.AddTransient<IAccesses, AccessesServices>();
builder.Services.AddTransient<ICategory, CategoryServices>();
builder.Services.AddTransient<IEmployees, EmployeesServices>();
builder.Services.AddTransient<IMembers, MembersServices>();
builder.Services.AddTransient<IProducts, ProductsServices>();
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
