using PUMP.models;

namespace PUMP.core.BL.Interfaces;

public interface IAuthentication
{
    Task<bool> Login(Employees employees);
}