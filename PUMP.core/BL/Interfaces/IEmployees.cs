using PUMP.models;

namespace PUMP.core.BL.Interfaces;

public interface IEmployees
{
    Task<bool> Create(models.Employees employees);
    Task<List<models.Employees>> Read();
    Task<bool> Update(models.Employees employees);
    Task<bool> Delete(models.Employees employees);
}