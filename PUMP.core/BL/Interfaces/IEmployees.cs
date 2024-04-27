using PUMP.models;

namespace PUMP.core.BL.Interfaces;

public interface IEmployees
{
    Task<bool> SaveEmployees(models.Employees employees);
    Task<bool> DeleteEmployees(models.Employees employees);
    Task<bool> UpdateEmployees(models.Employees employees);
    Task<List<models.Employees>> GetEmployees();
}